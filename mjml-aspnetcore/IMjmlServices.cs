using System;
using System.Threading.Tasks;

namespace Mjml.AspNetCore
{
    public interface IMjmlServices
    {
        Task<MjmlResponse> Render(string view);
    }
}
