'use strict';

module.exports = {
  entry: "./scripts/main/app",

  output: {
      path: './scripts/build',
      filename: "build.js"
  },

  devtool: "source-map",

  module: {
    loaders: [{
      test: /\.js$/,
      loader: 'babel-loader'
    }]
  }
};
