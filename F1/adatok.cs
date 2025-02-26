using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace F1
{
    internal class adatok
    {
        public string name { get; set; }
        public string country { get; set; }
        public string team { get; set; }
        public int position { get; set; }
        public double sec { get; set; }
        public int points { get; set; }

        public adatok(string name, string country, string team, int position, double sec, int points)
        {
            this.name = name;
            this.country = country;
            this.team = team;
            this.position = position;
            this.sec = sec;
            this.points = points;
        }

        public override string ToString()
        {
            return $"name: {name}, country: {country}, team: {team}, " +
                   $"position: {position}, sec: {sec}, points: {points}";
        }
    }
}
