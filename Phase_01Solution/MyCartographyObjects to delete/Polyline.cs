using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Media;

namespace MyCartographyObjects
{
    public class Polyline : CartoObjs
    {
        #region VARIABLES MEMBRES
        public List<Coordonnees> _listeCoord;
        public Color _couleur;
        public int _epaisseur;
        #endregion

        #region SETTER / GETTER
        public Color Couleur
        {
            get { return _couleur; }
            set { _couleur = value; }
        }
        public int Epaisseur
        {
            get { return _epaisseur; }
            set { _epaisseur = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Polyline() :
        {
            
        }
        public Polyline() :
        {
            
        }
        #endregion

        #region METHODES

        public override string ToString()
        {
            return base.ToString() + ;
        }
        public override void Draw()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
