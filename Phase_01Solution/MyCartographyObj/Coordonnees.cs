using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace MyCartographyObj
{
    [Serializable]
    public class Coordonnees : CartoObjs, IIsPointClose
    {
        #region VARIABLES MEMBRES
        protected double _latitude;
        protected double _longitude;
        #endregion

        #region SETTER / GETTER
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Coordonnees() : this(0,0)
        {
        }
        public Coordonnees(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.NbCoord = 1;
        }
        #endregion

        #region METHODES

        public override string ToString()
        {
            return base.ToString() + " // Latitude : " + Latitude.ToString(".###") + " // Longitude : " + Longitude.ToString(".###");
        }
        public override void Draw()
        {
            Console.WriteLine(ToString());
        }
        public bool IsPointClose(Coordonnees xy, double precision)
        {
            double Distance = Math.Sqrt(Math.Pow(xy.Longitude - this.Longitude, 2) + Math.Pow(xy.Latitude - this.Latitude, 2));

            Console.WriteLine("Point de base : " + this.Latitude + "," + this.Longitude);
            Console.WriteLine("Point choisit : " + xy.Latitude + "," + xy.Longitude);
            Console.WriteLine("Precision : " + precision);
            Console.WriteLine("Distance : " + Distance);

            if (Distance <= precision)
            {
                return true;
                //Console.WriteLine("Le point est proche\n");
            }
            else
            {
                return false;
                //Console.WriteLine("Le point n'est pas proche\n");
            }

        }

        #endregion
    }
}
