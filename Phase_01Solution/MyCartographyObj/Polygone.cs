using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace MyCartographyObj
{
    [Serializable]
    public class Polygone : CartoObjs, IPointy, IIsPointClose, ICartoObj
    {
        #region VARIABLES MEMBRES
        private List<Coordonnees> _listeCoord;
        private double _opacite;
        private string _description;
        [NonSerialized]
        private Color _remplissage;
        [NonSerialized]
        private Color _contour;
        private string _remplissageString;
        private string _contourString;
        #endregion

        #region SETTER / GETTER
        public List<Coordonnees> ListeCoord
        {
            get { return _listeCoord; }
            set { _listeCoord = value; }
        }
        public double Opacite
        {
            get { return _opacite; }
            set { _opacite = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Color Remplissage
        {
            get { return _remplissage; }
            set { _remplissage = value; _remplissageString = _remplissage.ToString(); }
        }
        public Color Contour
        {
            get { return _contour; }
            set { _contour = value; _contourString = _contour.ToString(); }
        }
        public string RemplissageString
        {
            get { return _remplissageString; }
            set { _remplissageString = value; }
        }
        public string ContourString
        {
            get { return _contourString; }
            set { _contourString = value; }
        }
        //Implémentation de IPointy
        public int NbPoints
        {
            get
            {
                int NbPoints = 0;
                bool test = false;

                for (int i = 0; i < ListeCoord.Count; i++)
                {
                    for (int j = i + 1; j < ListeCoord.Count && test == false; j++)
                    {
                        if (ListeCoord[i].Id != ListeCoord[j].Id)
                        {
                            test = false;
                        }
                        else
                            test = true;
                    }
                    if (test == false)
                        NbPoints++;
                    test = false;
                }
                return NbPoints;
            }
        }
        #endregion

        #region CONSTRUCTEURS
        public Polygone()
        {
            this.ListeCoord = new List<Coordonnees>();
            this.Remplissage = new Color();
            this.Contour = new Color();
            this.Opacite = 0;
            this.Description = "Description par défaut Polygone";
        }
        public Polygone(List<Coordonnees> listeCoord, Color remplissage, Color contour, double opacite, string description)
        {
            this.ListeCoord = listeCoord;
            this.Remplissage = remplissage;
            this.Contour = contour;
            if (opacite >= 0 && opacite <= 1)
                this.Opacite = opacite;
            else
                throw new ArgumentOutOfRangeException();
            this.Description = description;
        }
        #endregion

        #region METHODES
        public void AddCoord(Coordonnees Coord)
        {
            ListeCoord.Add(Coord);
            NbCoord++;
        }
        public override string ToString()
        {
            return base.ToString() + " // Remplissage : " + Remplissage + " // Contour : " + Contour + " // Opacite : " + Opacite + " // Description : " + Description;
        }
        public override void Draw()
        {
            Console.WriteLine(ToString());
            foreach (Coordonnees Coord in _listeCoord)
            {
                Console.WriteLine(Coord.ToString());
            }
            Console.WriteLine();
        }

        public bool IsPointClose(Coordonnees xy, double precision)
        {
            double infLatitude, supLongitude;
            double supLatitude, infLongitude;

            infLatitude = double.PositiveInfinity;
            supLongitude = double.NegativeInfinity;
            supLatitude = double.NegativeInfinity;
            infLongitude = double.PositiveInfinity;

            foreach (Coordonnees _temp in ListeCoord)
            {
                if (_temp.Latitude < infLatitude)
                    infLatitude = _temp.Latitude;
                if (_temp.Latitude > supLatitude)
                    supLatitude = _temp.Latitude;

                if (_temp.Longitude < infLongitude)
                    infLongitude = _temp.Longitude;
                if (_temp.Longitude > supLongitude)
                    supLongitude = _temp.Longitude;
            }

            Console.WriteLine("x1 : " + infLatitude);
            Console.WriteLine("x2 : " + supLatitude);
            Console.WriteLine("y1 : " + infLongitude);
            Console.WriteLine("y2 : " + supLongitude);
            Console.WriteLine("Point choisit : " + xy.Latitude + "," + xy.Longitude);

            if (infLatitude <= xy.Latitude && xy.Latitude <= supLatitude && infLongitude <= xy.Longitude && xy.Longitude <= supLongitude)
            {
                // Point is in bounding box
                //Console.WriteLine("Le point se trouve dans la bounding box\n");
                return true;
            }
            else
            {
                //Console.WriteLine("Le point ne se trouve pas dans la bounding box\n");
                return false;
            }

        }


        #endregion
    }
}
