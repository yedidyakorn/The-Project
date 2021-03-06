﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit : IClonable
    {
        public HostingUnit()
        {
            Owner = new Host(){};
        }

        public long HostingUnitKey { get; set; }

        public Host Owner { get; set; }
       
        public string HostingUnitName { get; set; }

        [XmlIgnore]
        public bool[,] Diary { get; set; } = new bool[12,31];

        private bool[] _DiaryDto;

        [XmlArray("Diary")]
        public bool[] DiaryDto
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(12);
                _DiaryDto = value;
            } //5 is the number of roes in the matrix
        }

        public VecationAreas Area { get; set; }

        public bool HasPool { get; set; }

        public bool HasJacuzzi { get; set; }

        public int NumberOfBeds { get; set; }

        public bool HasGarden { get; set; }

        public HostingUnitTypes Type { get; set; }

        public bool HasChildrensAttractions { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
