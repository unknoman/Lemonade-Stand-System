﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Supplier
    {
        public int id { get; set; }
        public string? name { get; set; }

        public int tel { get; set; }

        public int suppliesOrder { get; set; }
        public string? email { get; set; }

        public List<SuppliesOrder>? oSuppliesO { get; set; }

    }
}
