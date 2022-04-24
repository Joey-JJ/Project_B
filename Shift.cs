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
        public string name { get; set; }
        public string date { get; set; }
        public string duty { get; set; }


        public override string ToString()
        {
            return string.Format("Shift Information: \n\tname;{0}, \n\tdate;{1}, \n\tDuty; {2}, " +
                                         "\n\t", name, date, duty);
        }
        public Shift(string name1, string date1, string duty1)
        {
            name = name1;
            date = date1;
            duty = duty1;
        }
    }
}
    //class Shift2
    //{
    //    public string name2 { get; set; }
    //    public string day2 { get; set; }
    //    public string time2 { get; set; }
    //    public string duty2 { get; set; }


//    public override string ToString()
//     {
// .
//return string.Format("Shift Information: \n\tname;{0}, \n\tday;{1}, \n\tTime;{2}, \n\tDuty; {3}, " +
//  "\n\t", name2, day2, time2, duty2);
//    }

//   public Shift2(string naam, string datum, string tijd, string functie)
//    {
//       name2 = naam;
//       day2 = datum;
//       time2 = tijd;
//       duty2 = functie;

//   }

// }

//}

