const path = require('path');
const webpack = require('webpack');
const webpackMerge = require('webpack-merge');
const baseConfig = require('./webpack.config.base');

module.exports = webpackMerge(baseConfig, {
  mode: 'development',
  output: {
    path: path.resolve(__dirname, 'build'),
    publicPath: '/'
  },
  devServer: {
    contentBase: path.resolve(__dirname, 'build'),
    historyApiFallback: true
  }
});
