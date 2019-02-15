using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;

namespace mjml.aspnetcore
{
    public class MjmlServices : IMjmlServices, IDisposable
    {
        private readonly INodeServices _nodeServices;
        private readonly MjmlServiceOptions _options;

        private readonly StringAsTempFile _script;

        public MjmlServices(INodeServices nodeServices, MjmlServiceOptions options)
        {
            _nodeServices = nodeServices;
            _options = options;

            _script = new StringAsTempFile(@"
const mjml2html = require('mjml');

module.exports = function (callback, view, options) {
    const result = mjml2html(view, options);
    if (result.error) {
        callback(result.error, result.html);
        return;
    }

        public Task<MjmlResponse> Render(string view)
};
", CancellationToken.None);
        }

        {
            return Render(view, CancellationToken.None);
        }

        public async Task<MjmlResponse> Render(string view, CancellationToken token)
        {
            var options = new MjmlRenderOptions()
            {
                KeepComments = _options.DefaultKeepComments,
                Beautify = _options.DefaultBeautify,
                Minify = _options.DefaultMinify,
            };

            var command = _script.FileName;
            var args = new object[] { view, options };
            var result = await _nodeServices.InvokeAsync<MjmlResponse>(token, command, args);

            return result;
        }

        public void Dispose()
        {
            _nodeServices?.Dispose();
            _script?.Dispose();
        }
    }
}
