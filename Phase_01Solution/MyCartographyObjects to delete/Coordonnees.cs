using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace MyCartographyObjects
{
    public class Coordonnees : CartoObjs
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
        #endregion
    }
}
