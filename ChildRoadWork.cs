using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd3_PavlovMaksim
{
    public class ChildRoadWork : RoadWork
    {
        public int P { get; set; }
        public string Weather { get; set; }

        public ChildRoadWork(string name, double width, double length, double massPerSqM,
                            string surfaceType, int year, int p, string weather)
            : base(name, width, length, massPerSqM, surfaceType, year)
        {
            P = p;
            Weather = weather;
        }

        public override double Quality()
        {
            double q = base.Quality();

            if (P >= 5 && P <= 8)
                return q * 1.1;
            else if (P == 3 || P == 4 || P == 9 || P == 10)
                return q * 1.6;
            else
                return q * 1.9;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, P={P}, Qp={Quality():F2}";
        }
    }
}