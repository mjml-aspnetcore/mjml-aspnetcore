using System;

namespace Mjml.AspNetCore
{
    public class MjmlServiceOptions
    {
        public bool DefaultKeepComments { get; set; } = true;

        public bool DefaultBeautify { get; set; } = false;

        public bool DefaultMinify { get; set; } = false;

        public bool WarmUpRender { get; set; } = true;
    }
}
