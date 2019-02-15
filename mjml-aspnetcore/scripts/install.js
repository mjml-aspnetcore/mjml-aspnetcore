
module.exports = function(callback) {
    try {
        const cp = require('child_process');

        var options = { cwd: './scripts' };

        cp.exec('npm install mjml',
            options,
            (err, stdout, stderr) => {
                if (err) {
                    callback(err, false);
                    return;
                }
                console.log(stdout);
                callback(null, true);
            });
    } catch (err) {
        callback(err, false);
    }
};
