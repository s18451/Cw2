using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudiesName { get; set; }
        public string StudiesMode { get; set; }
        public string Index { get; set; }
        public string BirthDate { get; set; }
        public string Mail { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }

        public override string ToString()
        {
            return "FirstName: " + FirstName + ", LastName: " + LastName +", StudiesName: " + StudiesName + ", StudiesMode: " + StudiesMode + ", Index: " + Index;
        }
    }
}
