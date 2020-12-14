const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

const rootPath = path.resolve(__dirname);

module.exports = {
  context: path.resolve(rootPath),
  entry: {
    client: ['./src/polyfills.ts', './src/main.ts'],
    base: [
      'rxjs',
      'tslib',
      'zone.js'
    ],
    angular: [
      '@angular/animations',
      '@angular/common',
      '@angular/compiler',
      '@angular/core',
      '@angular/forms',
      '@angular/platform-browser',
      '@angular/platform-browser-dynamic',
      '@angular/router'
    ]
  },
  output: {
    filename: 'index.js',
    publicPath: ''
  },
  optimization: {
    splitChunks: {
      cacheGroups: {
        base: {
          chunks: 'initial',
          name: 'base',
          test: 'base',
          enforce: true
        },
        angular: {
          chunks: 'initial',
          name: 'angular',
          test: 'angular',
          enforce: true
        },
      }
    },
    runtimeChunk: true
  },
  module: {
    rules: [
      {
        test: /\.ts$/,
        use: [
          {
            loader: 'awesome-typescript-loader',
            options: {
              configFileName: path.resolve(rootPath, 'tsconfig.json')
            }
          },
          'angular2-template-loader',
          'angular2-router-loader'
        ]
      },
      {
        test: /\.html?$/,
        use: [
          {
            loader: 'html-loader',
            options: {
              ignoreCustomFragments: [/\{\{.*?}}/]
            }
          }
        ]
      },
      {
        test: /\.css$/,
        use: [
          'to-string-loader',
          {
            loader: 'css-loader',
            options: {
                sourceMap: false
            }
          }
        ]
      },
      {
        test: /\.(sass|scss)$/,
        use: [
          'to-string-loader',
          {
            loader: 'css-loader',
            options: {
                sourceMap: false
            }
          },
          'sass-loader'
        ]
      },
      {
        test: /\.svg$/,
        include: [
          path.resolve(rootPath, 'src')
        ],
        exclude: [
        ],
        use: [
          '@svgr/webpack'
        ]
      },
      {
        test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/,
        include: [
          path.resolve(rootPath, 'node_modules')
        ],
        use: [
          {
            loader: 'file-loader',
            options: {
              outputPath: 'fonts'
            }
          }
        ]
      }
    ]
  },
  resolve: {
    extensions: [ '.js', '.ts' ]
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: './src/index.html',
      minify: {
        removeComments: true,
        collapseWhitespace: true,
        removeRedundantAttributes: true,
        useShortDoctype: true,
        removeEmptyAttributes: true,
        removeStyleLinkTypeAttributes: true,
        keepClosingSlash: true,
        minifyJS: true,
        minifyCSS: true,
        minifyURLs: true,
      },
      inject: true,
    })
  ]
}
