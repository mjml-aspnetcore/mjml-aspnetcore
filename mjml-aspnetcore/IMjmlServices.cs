using System;
using System.Threading.Tasks;

namespace mjml.aspnetcore
{
    public interface IMjmlServices
    {
        Task<MjmlResponse> Render(string view);
    }
}
