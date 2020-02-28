using System.Threading;
using System.Threading.Tasks;

namespace Mjml.AspNetCore
{
    public interface IMjmlServices
    {
        Task<MjmlResponse> Render(string view, CancellationToken token = default);

        Task<MjmlResponse> RenderFromJson(string json, CancellationToken token = default);
    }
}