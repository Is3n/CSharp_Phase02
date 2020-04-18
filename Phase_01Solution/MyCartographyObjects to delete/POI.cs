using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace MyCartographyObjects
{
    public class POI : Coordonnees
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
        #endregion
    }
}
