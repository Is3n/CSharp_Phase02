using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObj
{
    public class MathUtil
    {
        public static double CalculLongueurSegment(double Latitude1, double Latitude2, double Longitude1, double Longitude2)
        {
            double Longueur = 0;
            Longueur = Math.Sqrt(Math.Pow((Latitude1 - Latitude2), 2) + Math.Pow((Longitude1 - Longitude2), 2));

            return Longueur;
        }


    }
}
