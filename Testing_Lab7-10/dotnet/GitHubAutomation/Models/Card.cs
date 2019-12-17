using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    class Card
    {
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string p3 { get; set; }
        public string p4 { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string owner { get; set; }
        public string code { get; set; }

        public string invP1 { get; set; }
        public string invP2 { get; set; }
        public string invP3 { get; set; }
        public string invP4 { get; set; }


        public Card()
        {
            p1 = GetCard("p1");
            p2 = GetCard("p2");
            p3 = GetCard("p3");
            p4 = GetCard("p1");
            month = GetCard("month");
            year = GetCard("year");
            owner = GetCard("owner");
            code = GetCard("code");
            invP1 = GetCard("invP1");
            invP2 = GetCard("invP2");
            invP3 = GetCard("invP3");
            invP4 = GetCard("invP1");

        }

        string GetCard(string key)
        {
            return CardReader.GetData(key);
        }

    }
}
