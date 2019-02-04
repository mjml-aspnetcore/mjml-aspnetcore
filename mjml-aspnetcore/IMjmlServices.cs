using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mjml.aspnetcore
{
    public interface IMjmlServices
    {
        Task<string> Render(string view);
    }
}
