﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.XML_DATA
{
    public class BaseXML
    {

        public long lastSerial { get; set; }

        public DateTime lastUpdate { get; set; } = DateTime.Now.AddDays( -1);

    }

    public class OrdersXml : BaseXML { }

    public class GuestRequestsXml : BaseXML { }

    public class HostingUnitsXml : BaseXML { }
}
