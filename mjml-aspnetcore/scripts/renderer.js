
module.exports = function (callback, view, options) {
    try {
        const mjml2html = require('mjml');

        console.log('parsing view');
        const result = mjml2html(view, options);
        console.log(result);

        if (result.errors && result.errors.length) {
            callback({ errors: result.errors }, {});
            return;
        }

        callback(null, {
            html: result.html,
        });
    } catch (err) {
        callback(err, null);
    }
}
