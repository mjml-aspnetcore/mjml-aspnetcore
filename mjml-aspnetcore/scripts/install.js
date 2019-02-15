const cp = require('child_process');

var options = { cwd: './scripts' };

module.exports = function (callback) {
    cp.exec('npm install', options, (err, stdout, stderr) => {
        if (err) {
            callback(err, false);
            return;
        }
        console.log(stdout);
        callback(null, true);
    });
};
