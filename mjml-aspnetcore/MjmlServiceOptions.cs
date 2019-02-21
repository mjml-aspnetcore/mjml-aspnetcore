using System;

namespace Mjml.AspNetCore
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
