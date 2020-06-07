// mjml-aspnetcore - Copyright (c) 2020 CaptiveAire

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Jering.Javascript.NodeJS;

namespace Mjml.AspNetCore
{
    public class MjmlServices : IMjmlServices, IDisposable
    {
        readonly INodeJSService _nodeServices;

        readonly MjmlServiceOptions _options;

        readonly StringAsTempFile _renderer;

        public MjmlServices(INodeJSService nodeServices, MjmlServiceOptions options)
        {
            _nodeServices = nodeServices;
            _options = options;

            _renderer = GetRenderer();

            if (options.WarmUpRender)
            {
                Warmup().Wait();
            }
        }

        public void Dispose()
        {
            _renderer?.Dispose();
            _nodeServices?.Dispose();
        }

        /// <summary>
        /// Deserializes the json string to an object before shipment to NodeServices
        /// </summary>
        /// <param name="json">Valid JSON object describing mjml tree view</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<MjmlResponse> RenderFromJson(string json, CancellationToken token = default)
        {
            var view = JsonSerializer.Deserialize<object>(json);

            return Render(view, token);
        }

        /// <summary>
        /// setup renderer script
        /// </summary>
        /// <returns></returns>
        static StringAsTempFile GetRenderer()
        {
            var assembly = typeof(MjmlServices).Assembly;
            using (var stream = assembly.GetManifestResourceStream("Mjml.AspNetCore.dist.renderer.js"))
            using (var reader = new StreamReader(stream ?? throw new InvalidOperationException("Unable to load embedded rendered")))
            {
                var result = reader.ReadToEnd();
                return new StringAsTempFile(result, CancellationToken.None);
            }
        }

        public Task<MjmlResponse> Render(string view, CancellationToken token = default)
        {
            return Render((object)view, token);
        }

        public async Task<MjmlResponse> Render(object view, CancellationToken token)
        {
            var options = new MjmlRenderOptions
            {
                KeepComments = _options.DefaultKeepComments,
                Beautify = _options.DefaultBeautify,
                Minify = false // unsupported until we can re-add uglify
            };

            var args = new[] { view, options };
            var result = await _nodeServices.InvokeFromFileAsync<MjmlResponse>(_renderer.FileName, null, args, token);

            return result;
        }

        Task Warmup()
        {
            var emptyView = "<mjml></mjml>";
            return Render(emptyView, CancellationToken.None);
        }
    }
}