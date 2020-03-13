using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Cw2
{
    public class Studies
    {
        [XmlElement("name")]
        [JsonPropertyName("name")]
        public string StudiesName { get; set; }
        [XmlElement("mode")]
        [JsonPropertyName("mode")]
        public string StudiesMode { get; set; }
    }
}
