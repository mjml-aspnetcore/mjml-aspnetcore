using System;

namespace Mjml.AspNetCore
{
    public class MjmlResponse
    {
        public MjmlResponseError[] Errors { get; set; }
        public string Html { get; set; }
    }

    public class MjmlResponseError
    {
        public int Line { get; set; }

        public string Message { get; set; }

        public string TagName { get; set; }

        public string FormattedMessage { get; set; }
    }
}
