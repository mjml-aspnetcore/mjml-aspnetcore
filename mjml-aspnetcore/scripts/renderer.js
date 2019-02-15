const mjml2html = require('mjml');

module.exports = function (callback, view, options) {
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
};
