using System;
using System.Collections.Generic;
using System.Text;

namespace mjml.aspnetcore
{
    public class MjmlServiceOptions
    {
        public MjmlServiceOptions()
        {
            DefaultKeepComments = true;
            DefaultBeautify = false;
            DefaultMinify = false;
        }

        public bool DefaultKeepComments { get; set; }

        public bool DefaultBeautify { get; set; }

        public bool DefaultMinify { get; set; }
    }
}
