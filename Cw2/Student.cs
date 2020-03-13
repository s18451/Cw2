using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Cw2
{

    [XmlType("student")]
    public class Student
    {

        [XmlElement("fname")]
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }
        [XmlElement("lname")]
        [JsonPropertyName("lname")]
        public string LastName { get; set; }
        [XmlAttribute("indexNumber")]
        [JsonPropertyName("indexNumber")]
        public string Index { get; set; }
        [XmlElement("birthdate")]
        [JsonPropertyName("birthdate")]
        public string BirthDate { get; set; }
        [XmlElement("email")]
        [JsonPropertyName("email")]
        public string Mail { get; set; }
        [XmlElement("mothersName")]
        [JsonPropertyName("mothersName")]
        public string Mother { get; set; }
        [XmlElement("fathersName")]
        [JsonPropertyName("fathersName")]
        public string Father { get; set; }
        [XmlElement("studies")]
        [JsonPropertyName("studies")]
        public Studies Studies { get; set; }

        //public override string ToString()
        //{
        //    return "FirstName: " + FirstName + ", LastName: " + LastName +", StudiesName: " + Studies.StudiesName + ", StudiesMode: " + Studies.StudiesMode + ", Index: " + Index;
        //}
    }
}
