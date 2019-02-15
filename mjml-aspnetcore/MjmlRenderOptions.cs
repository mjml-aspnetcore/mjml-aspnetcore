using System;
using System.Collections.Generic;
using System.Text;

namespace Mjml.AspNetCore
{
    public class MjmlRenderOptions
    {
        public bool KeepComments { get; set; }

        public bool Beautify { get; set; }

        public bool Minify { get; set; }
    }
}
