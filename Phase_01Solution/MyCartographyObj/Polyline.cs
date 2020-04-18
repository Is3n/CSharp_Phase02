using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace MyCartographyObj
{
    [Serializable]
    public class Polyline : CartoObjs, IPointy, IIsPointClose, IComparable<Polyline>, IEquatable<Polyline>, ICartoObj
    {
        #region VARIABLES MEMBRES
        private List<Coordonnees> _listeCoord;
        private int _epaisseur;
        private string _description;
        [NonSerialized]
        private Color _couleur;
        private string _couleurString;
        #endregion

        #region SETTER / GETTER
        public List<Coordonnees> ListeCoord
        {
            get { return _listeCoord; }
            set { _listeCoord = value; }
        }
        public int Epaisseur
        {
            get { return _epaisseur; }
            set { _epaisseur = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Color Couleur
        {
            get { return _couleur; }
            set { _couleur = value; _couleurString = _couleur.ToString(); }
        }
        public string CouleurString
        {
            get { return _couleurString; }
            set { _couleurString = value; }
        }
        // Implémentation de IPointy
        public int NbPoints
        {
            get
            {
                int NbPoints = 0;
                bool test = false;

                for(int i=0; i<ListeCoord.Count; i++)
                {
                    for(int j=i+1; j<ListeCoord.Count && test==false; j++)
                    {
                        if (ListeCoord[i].Id != ListeCoord[j].Id)
                        {
                            test = false;
                        }
                        else
                            test = true;
                    }
                    if(test==false)
                        NbPoints++;
                    test = false;
                }
                return NbPoints;
            }
        }
        #endregion

        #region CONSTRUCTEURS
        public Polyline()
        {
            this.ListeCoord = new List<Coordonnees>();
            this.Couleur = new Color();
            this.Epaisseur = 0;
            this.Description = "Description par défaut de Polyline";
        }
        public Polyline(List<Coordonnees> listeCoord, Color couleur, int epaisseur, string description)
        {
            this.ListeCoord = listeCoord;
            this.Couleur = couleur;
            this.Epaisseur = epaisseur;
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
            return base.ToString() + " // Couleur : " + Couleur + " // Epaisseur : " + Epaisseur + " // Description : " + Description;
        }
        public override void Draw()
        {
            Console.WriteLine(ToString());
            foreach(Coordonnees Coord in _listeCoord)
            {
                Console.WriteLine(Coord.ToString());
            }
            Console.WriteLine();
        }

        public bool IsPointClose(Coordonnees xy, double precision)
        {
            bool test = false;
            double Distance;

            Console.WriteLine("Point choisit : " + xy.Latitude + "," + xy.Longitude);
            Console.WriteLine("Precision : " + precision);
            Console.WriteLine("Points de la Polyline :");

            foreach (Coordonnees Coord in _listeCoord)
            {
                Distance = Math.Sqrt(Math.Pow(xy.Longitude - Coord.Longitude, 2) + Math.Pow(xy.Latitude - Coord.Latitude, 2));

                Console.WriteLine(Coord.ToString());
                Console.WriteLine("Distance : " + Distance);

                if (Distance <= precision)
                    test = true;
            }

            if (test == true)
            {
                //Console.WriteLine("Le point est proche\n");
                return true;
            }
            else
            {
                //Console.WriteLine("Le point n'est pas proche\n");
                return false;
            }
        }

        public int CompareTo(Polyline other)
        {
            double longueur1 = 0, longueur2 = 0;

            for (int i = 0; i < this.ListeCoord.Count() - 1; i++)
            {
                longueur1 = longueur1 + MathUtil.CalculLongueurSegment(this.ListeCoord[i].Latitude, this.ListeCoord[i + 1].Latitude, this.ListeCoord[i].Longitude, this.ListeCoord[i + 1].Longitude);

            }

            for (int i = 0; i < other.ListeCoord.Count() - 1; i++)
            {
                longueur2 = longueur2 + MathUtil.CalculLongueurSegment(other.ListeCoord[i].Latitude, other.ListeCoord[i + 1].Latitude, other.ListeCoord[i].Longitude, other.ListeCoord[i + 1].Longitude);

            }

            if (longueur1 > longueur2)
                return 1;
            else if (longueur1 < longueur2)
                return -1;
            else
                return 0;
        }

        public bool Equals(Polyline other) //Comparer selon la surface des bounding box
        {
            double infLatitude1, supLatitude1, infLongitude1, supLongitude1;
            double infLatitude2, supLatitude2, infLongitude2, supLongitude2;
            double longueur1 = 0, largeur1 = 0, longueur2 = 0, largeur2 = 0;
            double surface1 = 0, surface2 = 0;

            infLatitude1 = double.PositiveInfinity;
            supLongitude1 = double.NegativeInfinity;
            supLatitude1 = double.NegativeInfinity;
            infLongitude1 = double.PositiveInfinity;

            infLatitude2 = double.PositiveInfinity;
            supLongitude2 = double.NegativeInfinity;
            supLatitude2 = double.NegativeInfinity;
            infLongitude2 = double.PositiveInfinity;

            foreach (Coordonnees temp1 in this.ListeCoord)
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

            foreach (Coordonnees temp2 in other.ListeCoord)
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

            if (surface1.Equals(surface2))
                return true;
            else
                return false;
        }

        /*public bool Equals(Polyline other) //Comparer selon la taille totale des segments
        {
            double longueur1 = 0, longueur2 = 0;

            for (int i = 0; i < this.ListeCoord.Count() - 1; i++)
            {
                longueur1 = longueur1 + MathUtil.CalculLongueurSegment(this.ListeCoord[i].Latitude, this.ListeCoord[i + 1].Latitude, this.ListeCoord[i].Longitude, this.ListeCoord[i + 1].Longitude);

            }

            for (int i = 0; i < other.ListeCoord.Count() - 1; i++)
            {
                longueur2 = longueur2 + MathUtil.CalculLongueurSegment(other.ListeCoord[i].Latitude, other.ListeCoord[i + 1].Latitude, other.ListeCoord[i].Longitude, other.ListeCoord[i + 1].Longitude);

            }

            if(longueur1.Equals(longueur2))
                return true;
            else
                return false;
        }*/
        #endregion
    }
}
