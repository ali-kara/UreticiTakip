using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UreticiTakip_Web.Controllers.api
{
    public class VersionController : ApiController
    {
        public VersionController()
        {

        }

        public class AppVersion
        {
            public string Version { get; set; }
            public string Description { get; set; }
            public bool IsForcedUpdate { get; set; }

            public Platform Platform { get; set; }
        }

        public enum Platform
        {
            IOS = 0,
            Android = 1
        }

    }
}
