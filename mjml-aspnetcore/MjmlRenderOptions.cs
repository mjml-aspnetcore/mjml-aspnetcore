using System;
using System.Collections.Generic;
using System.Text;

namespace mjml.aspnetcore
{
    public class MjmlRenderOptions
    {
        public bool KeepComments { get; set; }

        public bool Beautify { get; set; }

        public bool Minify { get; set; }
    }
}
