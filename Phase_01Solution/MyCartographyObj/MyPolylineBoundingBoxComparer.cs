using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObj
{
    public class MyPolylineBoundingBoxComparer : IComparer<Polyline>
    {
        public int Compare(Polyline x, Polyline y)
        {
            double infLatitude1, supLatitude1, infLongitude1, supLongitude1;
            double infLatitude2, supLatitude2, infLongitude2, supLongitude2;
            double longueur1 = 0, largeur1 = 0, longueur2 = 0, largeur2 = 0;
            double surface1=0, surface2=0;

            infLatitude1 = double.PositiveInfinity;
            supLongitude1 = double.NegativeInfinity;
            supLatitude1 = double.NegativeInfinity;
            infLongitude1 = double.PositiveInfinity;

            infLatitude2 = double.PositiveInfinity;
            supLongitude2 = double.NegativeInfinity;
            supLatitude2 = double.NegativeInfinity;
            infLongitude2 = double.PositiveInfinity;

            foreach (Coordonnees temp1 in x.ListeCoord)
            {
                if (temp1.Latitude < infLatitude1)
                    infLatitude1 = temp1.Latitude;
                if (temp1.Latitude > supLatitude1)
                    supLatitude1 = temp1.Latitude;

                if (temp1.Longitude < infLongitude1)
                    infLongitude1 = temp1.Longitude;
                if (temp1.Longitude > supLongitude1)
                    supLongitude1 = temp1.Longitude;
            }

            foreach (Coordonnees temp2 in y.ListeCoord)
            {
                if (temp2.Latitude < infLatitude2)
                    infLatitude2 = temp2.Latitude;
                if (temp2.Latitude > supLatitude2)
                    supLatitude2 = temp2.Latitude;

                if (temp2.Longitude < infLongitude2)
                    infLongitude2 = temp2.Longitude;
                if (temp2.Longitude > supLongitude2)
                    supLongitude2 = temp2.Longitude;
            }

            /*Coordonnees HG1 = new Coordonnees(infLatitude1, infLongitude1);
            Coordonnees HD1 = new Coordonnees(infLatitude1, supLongitude1);
            Coordonnees BG1 = new Coordonnees(supLatitude1, infLongitude1);*/

            longueur1 = MathUtil.CalculLongueurSegment(infLatitude1, infLatitude1, infLongitude1, supLongitude1);
            largeur1 = MathUtil.CalculLongueurSegment(infLatitude1, supLatitude1, infLongitude1, infLongitude1);

            surface1 = longueur1 * largeur1;

            //Console.WriteLine("\t Surface 1 : " + surface1);

            /*Coordonnees HG2 = new Coordonnees(infLatitude2, infLongitude2);
            Coordonnees HD2 = new Coordonnees(infLatitude2, supLongitude2);
            Coordonnees BG2= new Coordonnees(supLatitude2, infLongitude2);*/

            longueur2 = MathUtil.CalculLongueurSegment(infLatitude2, infLatitude2, infLongitude2, supLongitude2);
            largeur2 = MathUtil.CalculLongueurSegment(infLatitude2, supLatitude2, infLongitude2, infLongitude2);

            surface2 = longueur2 * largeur2;

            //Console.WriteLine("\t Surface 2 : " + surface2);

            if (surface1 > surface2)
                return 1;
            else if (surface1 < surface2)
                return -1;
            else
                return 0;

        }
    }
}
