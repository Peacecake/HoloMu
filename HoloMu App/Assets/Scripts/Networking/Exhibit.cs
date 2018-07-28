using System.Collections.Generic;

namespace HoloMu.Networking
{
    public class Exhibit
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Year { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> AdditionalInformation { get; set; }

        public Exhibit()
        {
            ID = "";
            Name = "";
            Category = "";
            Year = "";
            Manufacturer = "";
            Description = "";
            AdditionalInformation = new Dictionary<string, string>();
        }
    }
}
