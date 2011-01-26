﻿using System.Web;

namespace Postal
{
    // Implement just enough HttpResponse junk to allow the view engine and views to work.
    // This allows the email rendering to occur on a non-web request thread, 
    // e.g. a background task.

    class EmailHttpResponse : HttpResponseBase
    {
        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath;
        }

        public override System.IO.TextWriter Output { get; set; }
    }
}
