using System;
using System.Collections.Generic;
using System.Text;

namespace placesFestFlowerJam.DomainObjects
{
    public class Fest : DomainObject
    {
        public string Address { get; set; }

        public string PeriodOf { get; set; }

        public string NumberTP { get; set; }

        public string WorkWeekdays { get; set; }

        public string WorkWeekend { get; set; }

        public string WebSite { get; set; }
    }
}
