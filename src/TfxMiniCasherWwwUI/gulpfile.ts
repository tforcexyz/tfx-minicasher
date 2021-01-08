// npm install del gulp@4 gulp-concat gulp-import-css gulp-clean-css gulp-less gulp-rename gulp-replace gulp-sass gulp-sourcemaps gulp-uglify
const { dest, parallel, src, series, task, watch } = require('gulp');
const del = require('del');
const gulp = require('gulp');
const concat = require('gulp-concat');
const importCss = require('gulp-import-css');
const minifyCss = require('gulp-clean-css');
const less = require('gulp-less');
const rename = require('gulp-rename');
const replace = require('gulp-replace');
const sass = require('gulp-sass');
const sassTildeImporter = require('./sass-tilde-support');
const sourcemaps = require('gulp-sourcemaps');
const minifyJs = require('gulp-uglify');
const minifyJsOptions = { output: { comments: function(node, comment) { return /v\d\.\d\.\d/g.test(comment.value); } } }
sass.compiler = require('sass');

const outputDir = process.env.NODE_ENV !== 'production' ? 'build' : 'dist';

task('app_css', function(callback) {
  src(`./src/styles.scss`)
    .pipe(sass({ includePaths: [
      `./src`,
      `./node_modules`,
    ],
    importer: sassTildeImporter }).on('error', sass.logError))
    .pipe(rename('app.css'))
    .pipe(dest(`./${outputDir}/css`))
    .pipe(rename(function (path) {
      path.basename += '.min';
    }))
    .pipe(sourcemaps.init())
    .pipe(minifyCss())
    .pipe(sourcemaps.write('.'))
    .pipe(dest(`./${outputDir}/css`));
  callback();
})

task('app_img', function(callback) {
  src([
    `./src/favicon.ico`,
    `./src/assets/**`,
    ])
    .pipe(dest(`./${outputDir}`));
  callback();
})

task('app_js', function(callback) {
  src([
    `node_modules/pace-js/pace.min.js`,
    `node_modules/tinymce/tinymce.min.js`,
    `node_modules/tinymce/themes/modern/theme.min.js`,
    `node_modules/tinymce/plugins/link/plugin.min.js`,
    `node_modules/tinymce/plugins/paste/plugin.min.js`,
    `node_modules/tinymce/plugins/table/plugin.min.js`,
    //`node_modules/echarts/dist/echarts.min.js`,
    //`node_modules/echarts/dist/extension/bmap.min.js`,
    //`node_modules/chart.js/dist/Chart.min.js`,
    ])
    .pipe(concat('app.js'))
    .pipe(dest(`./${outputDir}/js`))
    .pipe(rename(function (path) {
      path.basename += '.min';
    }))
    .pipe(sourcemaps.init())
    .pipe(minifyJs(minifyJsOptions))
    .pipe(sourcemaps.write('.'))
    .pipe(dest(`./${outputDir}/js`));
  callback();
})

//// MAINTAINANCE ////
task('remove_build', function(callback) {
  del('./build');
  callback();
})

task('watch', function(callback) {
  watch([
    `./src/styles.scss`
  ], {

  },
  parallel('app_js', 'app_css'))
  callback();
})

task('build', parallel('app_css', 'app_img', 'app_js'))
task('clean', series('remove_build'))
