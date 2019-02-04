const mjml2html = require('mjml');

module.exports = function (callback, view, options) {
    const result = mjml2html(view, options);
    if (result.error) {
        callback(result.error, result.html);
        return;
    }

    callback(null, result.html);
};
