using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace WerkRoosterProgram
{
    class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string dag { get; set; }
        public string werktijd { get; set; }
        public List<string> functies { get; set; }

        public override string ToString()
        {
            return string.Format("Shift Information: \n\tId:{0}, \n\tName:{1}, \n\tdag:{2}, \n\twerktijd: {3}, " +
                                         "\n\tfuncties: {4}", Id, Name, dag, werktijd, string.Join(",", functies.ToArray()));
        }

    }
}

