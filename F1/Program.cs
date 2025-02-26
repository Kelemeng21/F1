using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Globalization;

namespace F1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\Ny20Kelemeng\\source\\repos\\F1\\F1\\src\\melbourne2009.txt";

            List<adatok> verseny = new List<adatok>();

            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(';');
                    string name = parts[0];
                    string country = parts[1];
                    string team = parts[2];
                    if (!int.TryParse(parts[3], out int position))
                    {
                        continue;
                    }
                    if (!double.TryParse(parts[4], NumberStyles.Float, CultureInfo.InvariantCulture, out double sec))
                    {
                        continue;
                    }
                    if (!int.TryParse(parts[5], out int points))
                    {
                        continue;
                    }

                    verseny.Add(new adatok(name, country, team, position, sec, points));
                }
            }

            Console.WriteLine($"1. feladat: ennyi pilóta ért a célba {verseny.Count()}");

            var f2 = verseny.Sum(x => x.points);

            Console.WriteLine($"2. feladat: ennyi pont került kiosztásra {f2}");

            var f3 = verseny.Where(x => x.country == "germany");

            Console.WriteLine($"3. feladat: Ennyi német versenyző van {f3.Count()}");

            var f4 = verseny.Where(x => x.points > 0).Select(x => x.team).Distinct().ToList();
            Console.WriteLine("4. feladat azok a csapatok akik pontot szereztek");
            foreach (var item in f4)
            {
                Console.WriteLine($"\t{item} ");
            }

            var f5 = verseny.Min(x => x.sec);

            foreach (var item in verseny)
            {
                if (item.sec == f5)
                {
                    Console.WriteLine($"A versenyző neve {item.name}");
                    Console.WriteLine($"Az ideje 01:34:{item.sec}");
                }
            }
        }
    }
}
