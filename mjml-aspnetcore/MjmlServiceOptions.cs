using System;

namespace Mjml.AspNetCore
{
    public class MjmlServiceOptions
    {
        public MjmlServiceOptions()
        {
            RunNpmInstall = false;
            DefaultKeepComments = true;
            DefaultBeautify = false;
            DefaultMinify = false;
        }

        public bool RunNpmInstall { get; set; }

        public bool DefaultKeepComments { get; set; }

        public bool DefaultBeautify { get; set; }

        public bool DefaultMinify { get; set; }
    }
}
