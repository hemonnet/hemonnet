﻿using System;
using System.Collections.Generic;
using System.Text;

namespace N2.Addons.Wiki
{
    public class ViewContext
    {
        public IArticle Article { get; set; }
        public Fragment Fragment { get; set; }
        public IDictionary<string, object> State { get; set; }
    }
}
