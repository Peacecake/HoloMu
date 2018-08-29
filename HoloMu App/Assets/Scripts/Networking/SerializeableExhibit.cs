using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoloMu.Networking
{
    [Serializable]
    public class SerializeableExhibit
    {
        public int id;
        public string name;
        public string category;
        public string year;
        public string manufacturer;
        public string description;
        public MoreInfo[] moreinfos;

    }

    [Serializable]
    public class MoreInfo
    {
        public string name;
        public string datatype;
        public string[] data;
        public string text;
    }
}
