var path = require('path');
var findParentDir = require('find-parent-dir');
var fs = require('fs');

function resolve(targetUrl, source) {
  var packageRoot = findParentDir.sync(source, 'node_modules');
  if (!packageRoot) {
    return null;
  }

  var filePath = path.resolve(packageRoot, 'node_modules', targetUrl);
  var isPotentiallyDirectory = !path.extname(filePath);

  if (isPotentiallyDirectory) {
    if (fs.existsSync(filePath + '.scss')) {
      return filePath + '.scss';
    }

    let dirName = path.dirname(filePath);
    let fileName = path.basename(filePath);
    if (fs.existsSync(dirName + '/_' + fileName + '.scss')) {
      return dirName + '/_' + fileName + '.scss';
    }
    if (fs.existsSync(filePath + '.css')) {
      return filePath + '.css';
    }

    if (fs.existsSync(filePath)) {
      return path.resolve(filePath, 'index');
    }
  }

  if (fs.existsSync(path.dirname(filePath))) {
    return filePath;
  }

  return resolve(targetUrl, path.dirname(packageRoot));
}

module.exports = function importer (url, prev, done) {
  return (url[ 0 ] === '~') ? { file: resolve(url.substr(1), prev) } : null;
};
