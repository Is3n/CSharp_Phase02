using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace MyCartographyObj
{
    [Serializable]
    public class POI : Coordonnees, IIsPointClose, ICartoObj
    {
        #region VARIABLES MEMBRES
        private string _description;
        #endregion

        #region SETTER / GETTER
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public POI()
        {
            this.Latitude = 50.610945;
            this.Longitude = 5.510958;
            this.Description = "HEPL - Parc des Maret";
        }
        public POI(double latitude, double longitude, string description) : base(latitude, longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.NbCoord = 1;
            this.Description = description;
        }
        #endregion

        #region METHODES

        public override string ToString()
        {
            return base.ToString() + " // Description : " + Description;
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
