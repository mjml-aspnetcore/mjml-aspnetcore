module.exports = function(callback, view, options) {
    try {
        const mjml2html = require('mjml');

        console.log('parsing view');
        const result = mjml2html(view, options);
        console.log(result);

        callback(null, result);
    } catch (err) {
        console.error(err);
        callback(err, null);
    }
};
