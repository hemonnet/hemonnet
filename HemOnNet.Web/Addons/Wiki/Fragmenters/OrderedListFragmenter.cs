﻿using System;
using System.Collections.Generic;
using System.Text;

namespace N2.Addons.Wiki.Fragmenters
{
    public class OrderedListFragmenter : ListFragmenter
    {
        public OrderedListFragmenter()
            : base(@"^(?<Value>[#]+)\s*(?<Contents>[^\r\n]*)[\r\n]*")
        {
        }
    }
}
