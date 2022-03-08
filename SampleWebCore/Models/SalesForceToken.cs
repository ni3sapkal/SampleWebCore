﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebCore.Models
{
    public class SalesForceToken
    {
        public string access_token { get; set; }
        public string instance_url { get; set; }
        public string id { get; set; }
        public string token_type { get; set; }
        public string issued_at { get; set; }
        public string signature { get; set; }
    }
}
