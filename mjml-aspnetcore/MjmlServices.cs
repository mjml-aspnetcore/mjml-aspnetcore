using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;

namespace mjml.aspnetcore
{
    public class MjmlServices : IMjmlServices, IDisposable
    {
        private readonly INodeServices _nodeServices;
        private readonly MjmlServiceOptions _options;

        private StringAsTempFile _install;
        private StringAsTempFile _renderer;

        public MjmlServices(INodeServices nodeServices, MjmlServiceOptions options)
        {
            _nodeServices = nodeServices;
            _options = options;

            // setup scripts
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Mjml.AspNetCore.scripts.install.js"))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                _install = new StringAsTempFile(result, CancellationToken.None);
            }

            using (var stream = assembly.GetManifestResourceStream("Mjml.AspNetCore.scripts.renderer.js"))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                _renderer = new StringAsTempFile(result, CancellationToken.None);
            }

            // npm install
            var installResult = _nodeServices.InvokeAsync<string>(CancellationToken.None, _install.FileName, null).Result;
        }

        public Task<MjmlResponse> Render(string view)
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

            var args = new object[] { view, options };
            var result = await _nodeServices.InvokeAsync<MjmlResponse>(token, _renderer.FileName, args);

            return result;
        }

        public void Dispose()
        {
            _nodeServices?.Dispose();
        }
    }
}
