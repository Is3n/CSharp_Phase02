using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Media;

using MyCartographyObj;

namespace Phase01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TEST 1
            Console.WriteLine(" ************************************************** ");
            Console.WriteLine(" ********************  TEST 1  ******************** ");
            Console.WriteLine(" ************************************************** ");

            #region COORDONNEES
            Coordonnees c = new Coordonnees(4,6);
            Coordonnees c2 = new Coordonnees(651, 94);
            Coordonnees c3 = new Coordonnees(10, 10);
            Coordonnees c4 = new Coordonnees(564, 231);
            Coordonnees c5 = new Coordonnees(761, 349);

            Console.WriteLine("\n ***************************************** ");
            Console.WriteLine(" ***** Affichage de deux coordonnees ***** ");
            Console.WriteLine(" ***************************************** ");
            c.Draw();
            c2.Draw();

            Console.WriteLine("\n ******************************************** ");
            Console.WriteLine(" ******** IsPointClose - Coordonnees ******** ");
            Console.WriteLine(" ******************************************** ");

            if (c3.IsPointClose(new Coordonnees(15, 15), 10))
                Console.WriteLine("Le point est proche\n");
            else
                Console.WriteLine("Le point n'est pas proche\n");

            if (c5.IsPointClose(new Coordonnees(15, 15), 10))
                Console.WriteLine("Le point est proche\n");
            else
                Console.WriteLine("Le point n'est pas proche\n");
            #endregion

            #region POI
            POI interet = new POI();
            POI interet2 = new POI(50.609901, 5.543506, "Standard de liege");
            POI interet3 = new POI(51.492593, 7.451842, "Dortmund");
            POI interet4 = new POI(53.480759, - 2.242631, "Manchester");
            POI interet5 = new POI(51.507351, - 0.127758, "London");
            POI interet6 = new POI(53.408371, - 2.991573, "Liverpool");

            Console.WriteLine("\n ********************************* ");
            Console.WriteLine(" ***** Affichage de deux POI ***** ");
            Console.WriteLine(" ********************************* ");
            interet.Draw();
            interet2.Draw();

            Console.WriteLine("\n ******************************************** ");
            Console.WriteLine(" ***** IsPointClose - Point Of Interest ***** ");
            Console.WriteLine(" ******************************************** ");

            if (interet5.IsPointClose(new Coordonnees(15, 15), 5))
                Console.WriteLine("Le point est proche\n");
            else
                Console.WriteLine("Le point n'est pas proche\n");

            if (interet5.IsPointClose(new Coordonnees(15, 15), 8))
                Console.WriteLine("Le point est proche\n");
            else
                Console.WriteLine("Le point n'est pas proche\n");
            #endregion

            #region LISTES
            List<Coordonnees> listeCoordonnees1 = new List<Coordonnees>();

            listeCoordonnees1.Add(interet);
            //listeCoordonnees1.Add(c2);
            listeCoordonnees1.Add(interet2);
            //listeCoordonnees1.Add(c4);
            listeCoordonnees1.Add(interet6);
            //listeCoordonnees1.Add(c4);
            listeCoordonnees1.Add(interet4);
            listeCoordonnees1.Add(interet);

            List<Coordonnees> listeCoordonnees2 = new List<Coordonnees>();

            listeCoordonnees2.Add(interet3);
            listeCoordonnees2.Add(c);
            listeCoordonnees2.Add(interet4);
            listeCoordonnees2.Add(c3);
            listeCoordonnees2.Add(interet);
            listeCoordonnees2.Add(interet2);
            listeCoordonnees2.Add(c);
            listeCoordonnees2.Add(interet5);

            List<Coordonnees> listeCoordonnees3 = new List<Coordonnees>();

            listeCoordonnees3.Add(interet2);
            listeCoordonnees3.Add(c);
            listeCoordonnees3.Add(interet3);
            listeCoordonnees3.Add(c2);
            listeCoordonnees3.Add(interet5);

            List<Coordonnees> listeCoordonnees4 = new List<Coordonnees>();

            listeCoordonnees4.Add(interet3);
            listeCoordonnees4.Add(c2);
            listeCoordonnees4.Add(interet4);
            listeCoordonnees4.Add(c3);
            listeCoordonnees4.Add(interet6);

            List<Coordonnees> listeCoordonnees5 = new List<Coordonnees>();

            listeCoordonnees5.Add(interet4);
            listeCoordonnees5.Add(c3);
            listeCoordonnees5.Add(interet5);
            listeCoordonnees5.Add(c4);
            listeCoordonnees5.Add(interet);
            listeCoordonnees5.Add(c5);

            List<Coordonnees> listeCoordonnees6= new List<Coordonnees>();

            listeCoordonnees6.Add(interet4);
            listeCoordonnees6.Add(c3);
            listeCoordonnees6.Add(interet5);


            #endregion

            #region POLYLINES
            Polyline polyline1 = new Polyline(listeCoordonnees1, Colors.Red, 10, "Ma polyline 1");
            polyline1.NbCoord = listeCoordonnees1.Count();
            Polyline polyline2 = new Polyline(listeCoordonnees2, Colors.Red, 5, "Ma polyline 2");
            polyline2.NbCoord = listeCoordonnees2.Count();
            Polyline polyline3 = new Polyline(listeCoordonnees3, Colors.Red, 7, "Ma polyline 3");
            polyline3.NbCoord = listeCoordonnees3.Count();
            Polyline polyline4 = new Polyline(listeCoordonnees4, Colors.Red, 3, "Ma polyline 4");
            polyline4.NbCoord = listeCoordonnees4.Count();
            Polyline polyline5 = new Polyline(listeCoordonnees5, Colors.Red, 9, "Ma polyline 5");
            polyline5.NbCoord = listeCoordonnees5.Count();

            Console.WriteLine("\n *********************************** ");
            Console.WriteLine(" ***** Affichage des polylines ***** ");
            Console.WriteLine(" *********************************** ");

            polyline1.Draw();
            Console.WriteLine("Nombre de Coordonnees : " + polyline1.NbCoord);
            Console.WriteLine("Nombre de points differents : " + polyline1.NbPoints + "\n");
            polyline2.Draw();
            Console.WriteLine("Nombre de Coordonnees : " + polyline2.NbCoord);
            Console.WriteLine("Nombre de points differents : " + polyline2.NbPoints);

            Console.WriteLine("\n *********************************** ");
            Console.WriteLine(" ***** IsPointClose - Polyline ***** ");
            Console.WriteLine(" *********************************** ");

            if (polyline1.IsPointClose(interet5, 10))
                Console.WriteLine("Le point est proche\n");
            else
                Console.WriteLine("Le point n'est pas proche\n");

            if (polyline2.IsPointClose(new Coordonnees(600, 600), 10))
                Console.WriteLine("Le point est proche\n");
            else
                Console.WriteLine("Le point n'est pas proche\n");

            #endregion
           
            #region POLYGONES
            Polygone polygone1;
            Polygone polygone2;
            try
            {
                polygone1 = new Polygone(listeCoordonnees1, Color.FromRgb(205, 203, 203), Colors.Red, 0.4, "Mon Polygone 1");
                polygone1.NbCoord = listeCoordonnees1.Count();
                polygone2 = new Polygone(listeCoordonnees2, Color.FromRgb(205, 203, 203), Colors.Red, 0.8, "Mon Polygone 2");
                polygone2.NbCoord = listeCoordonnees1.Count();

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ERROR : Opacite MUST BE >=0 AND <= 1 !\n");
                Console.WriteLine("Creation de polygones pas defaut ! ( Opacite => 0 )");
                polygone1 = new Polygone(listeCoordonnees1, Color.FromRgb(205, 203, 203), Colors.Red, 0.5, "Mon Polygone 1");
                polygone1.NbCoord = listeCoordonnees1.Count();
                polygone2 = new Polygone(listeCoordonnees2, Color.FromRgb(205, 203, 203), Colors.Red, 0.5, "Mon Polygone 2");
                polygone2.NbCoord = listeCoordonnees1.Count();
            };

            Console.WriteLine("\n *********************************** ");
            Console.WriteLine(" ***** Affichage des polygones ***** ");
            Console.WriteLine(" *********************************** ");

            polygone1.Draw();
            Console.WriteLine("Nombre de Coordonnees : " + polygone1.NbCoord);
            Console.WriteLine("Nombre de points differents : " + polygone1.NbPoints + "\n");
            polygone2.Draw();
            Console.WriteLine("Nombre de Coordonnees : " + polygone2.NbCoord);
            Console.WriteLine("Nombre de points differents : " + polygone2.NbPoints);

            Console.WriteLine("\n *********************************** ");
            Console.WriteLine(" ***** IsPointClose - Polygone ***** ");
            Console.WriteLine(" *********************************** ");

            if (polygone1.IsPointClose(c, 10))
                Console.WriteLine("Le point se trouve dans la bounding box\n");
            else
                Console.WriteLine("Le point ne se trouve pas dans la bounding box\n");

            if (polygone2.IsPointClose(new Coordonnees(600, 600), 10))
                Console.WriteLine("Le point se trouve dans la bounding box\n");
            else
                Console.WriteLine("Le point ne se trouve pas dans la bounding box\n");

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 2\n");
            Console.ReadKey();
            #endregion
            #endregion

            #region TEST 2
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 2  ******************** ");
            Console.WriteLine(" ************************************************** ");

            List<CartoObjs> listeCartoObj1 = new List<CartoObjs>();

            listeCartoObj1.Add(c);
            listeCartoObj1.Add(c2);
            listeCartoObj1.Add(interet);
            listeCartoObj1.Add(interet2);
            listeCartoObj1.Add(polyline1);
            listeCartoObj1.Add(polyline2);
            listeCartoObj1.Add(polygone1);
            listeCartoObj1.Add(polygone2);

            Console.WriteLine("Creation de la liste d'objets cartographiques effectuee !");

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 3\n");
            Console.ReadKey();
            #endregion

            #region TEST 3
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 3  ******************** ");
            Console.WriteLine(" ************************************************** ");

            Console.WriteLine("Affichage de la liste d'objets cartographiques :\n");

            foreach (CartoObjs ObjCarto in listeCartoObj1)
            {
                ObjCarto.Draw();
            }

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 4\n");
            Console.ReadKey();
            #endregion

            #region TEST 4
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 4  ******************** ");
            Console.WriteLine(" ************************************************** ");

            Console.WriteLine("Affichage de la liste d'objets cartographiques qui implementent IPointy:\n");

            foreach (CartoObjs ObjCarto in listeCartoObj1)
            {
                if (ObjCarto is IPointy)
                {
                    ObjCarto.Draw();
                }
            }

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 5\n");
            Console.ReadKey();
            #endregion

            #region TEST 5
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 5  ******************** ");
            Console.WriteLine(" ************************************************** ");

            Console.WriteLine("Affichage de la liste d'objets cartographiques qui n'implementent pas IPointy:\n");

            foreach (CartoObjs ObjCarto in listeCartoObj1)
            {
                if (!(ObjCarto is IPointy))
                {
                    ObjCarto.Draw();
                }
            }

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 6\n");
            Console.ReadKey();
            #endregion

            #region TEST 6
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 6  ******************** ");
            Console.WriteLine(" ************************************************** ");

            List<Polyline> listePolyline1 = new List<Polyline>();

            listePolyline1.Add(polyline1);
            listePolyline1.Add(polyline2);
            listePolyline1.Add(polyline3);
            listePolyline1.Add(polyline4);
            listePolyline1.Add(polyline5);

            Console.WriteLine("Creation de la liste de polylines effectuee !");

            Console.WriteLine("Affichage de la liste de polylines :");
            foreach (Polyline Poly in listePolyline1)
            {
                Poly.Draw();
            }

            Console.WriteLine("Tri de la liste de polylines selon l'ordre de longueurs croissantes !");
            listePolyline1.Sort();

            Console.WriteLine("Affichage de la liste de polylines triee :");
            foreach (Polyline Poly in listePolyline1)
            {
                Poly.Draw();
            }

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 7\n");
            Console.ReadKey();
            #endregion

            #region TEST 7
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 7  ******************** ");
            Console.WriteLine(" ************************************************** ");

            Console.WriteLine("Affichage de la liste de polylines :");
            foreach (Polyline Poly in listePolyline1)
            {
                Poly.Draw();
            }

            Console.WriteLine("Tri de la liste de polylines selon la surface des bounding box !\n");
            MyPolylineBoundingBoxComparer pcomp = new MyPolylineBoundingBoxComparer();
            listePolyline1.Sort(pcomp);

            Console.WriteLine("Affichage de la liste de polylines triee :");
            foreach (Polyline Poly in listePolyline1)
            {
                Poly.Draw();
            }

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 8\n");
            Console.ReadKey();
            #endregion

            #region TEST 8
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 8  ******************** ");
            Console.WriteLine(" ************************************************** ");

            Console.WriteLine("Affichage de la liste de polylines :");
            foreach (Polyline Poly in listePolyline1)
            {
                Poly.Draw();
            }

            Polyline polylineRef = new Polyline(listeCoordonnees1, Colors.Red, 15, "Ma polyline de reference");
            //Polyline polylineRef = new Polyline(listeCoordonnees6, Colors.d, 15, "Ma polyline de reference");

            Console.WriteLine("Affichage de la polyline de reference :");
            polylineRef.Draw();

            List<Polyline> listePolylineTmp = listePolyline1.FindAll(x => x.Equals(polylineRef));
           
            Console.WriteLine("Affichage des polylines egales a celle de reference :");
            foreach (Polyline Poly in listePolylineTmp)
            {
                Poly.Draw();
            }

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 9\n");
            Console.ReadKey();
            #endregion

            #region TEST 9
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 9  ******************** ");
            Console.WriteLine(" ************************************************** ");

            Console.WriteLine("Affichage de la liste de polylines :");
            foreach (Polyline Poly in listePolyline1)
            {
                Poly.Draw();
            }

            List<Polyline> listePolylineTmp2 = new List<Polyline>();

            foreach (Polyline Poly in listePolyline1)
            {
                if(Poly.IsPointClose(interet5, 10))
                    listePolylineTmp2.Add(Poly);
                //if(Poly.IsPointClose(c5, 10))
                //    listePolylineTmp2.Add(Poly);
                //if(Poly.IsPointClose(new Coordonnees(1000, 1000), 10))
                //    listePolylineTmp2.Add(Poly);
            }

            Console.WriteLine("\nAffichage des polylines proches du point de reference :");
            foreach (Polyline Poly in listePolylineTmp2)
            {
                Poly.Draw();
            }

            Console.WriteLine("\n\t Appuyez sur une touche pour passer a l'etape 10\n");
            Console.ReadKey();
            #endregion

            #region TEST 10
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" ********************  TEST 10  ******************* ");
            Console.WriteLine(" ************************************************** ");

            listeCartoObj1.Add(polyline5);
            listeCartoObj1.Add(c4);

            Console.WriteLine("Affichage de la liste d'objets cartographiques :\n");

            foreach (CartoObjs ObjCarto in listeCartoObj1)
            {
                ObjCarto.Draw();
            }

            Console.WriteLine("\nTri de la liste d'objets cartographiques :\n");

            listeCartoObj1.Sort();

            foreach (CartoObjs _tmp in listeCartoObj1)
            {
                _tmp.Draw();
            }

            Console.WriteLine("\n\t Appuyez sur une touche pour passer au test de MyPersonalMapData\n");
            Console.ReadKey();
            #endregion

            #region TEST MyPersonalMapData
            Console.WriteLine("************************************************** ");
            Console.WriteLine(" **************  MyPersonalMapData  *************** ");
            Console.WriteLine(" ************************************************** ");

            List<Coordonnees> listeCoordonneesDuSud = new List<Coordonnees>();

            listeCoordonneesDuSud.Add(new POI(41.385064, 2.173403, "Barcelone"));
            listeCoordonneesDuSud.Add(new POI(39.469907, -0.376288, "Valence"));
            listeCoordonneesDuSud.Add(new POI(37.389092, -5.984459, "Séville"));
            listeCoordonneesDuSud.Add(new POI(38.722252, -9.139337, "Lisbonne"));
            listeCoordonneesDuSud.Add(new POI(33.573110, -7.589843, "Casablanca"));

            List<Coordonnees> listeCoordonneesFrance = new List<Coordonnees>();

            listeCoordonneesFrance.Add(new POI(48.856614, 2.352222, "Paris"));
            listeCoordonneesFrance.Add(new POI(48.117266, -1.677793, "Rennes"));
            listeCoordonneesFrance.Add(new POI(46.580224, 0.340375, "Poitiers"));
            listeCoordonneesFrance.Add(new POI(47.322047, 5.041480, "Lisbonne"));

            Polyline polylineDuSud = new Polyline(listeCoordonneesDuSud, Colors.Red, 5, "Ma polyline du sud");
            polylineDuSud.NbCoord = listeCoordonneesDuSud.Count();

            Polygone polygoneFrance;
            try
            {
                polygoneFrance = new Polygone(listeCoordonneesFrance, Colors.AliceBlue, Colors.Blue, 0.5, "Mon Polygone France");
                polygoneFrance.NbCoord = listeCoordonneesFrance.Count();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ERROR : Opacite MUST BE >=0 AND <= 1 !\n");
                Console.WriteLine("Creation de polygones pas defaut ! ( Opacite => 0 )");
                polygoneFrance = new Polygone(listeCoordonneesFrance, Colors.AliceBlue, Colors.Blue, 0.5, "Mon Polygone France");
                polygoneFrance.NbCoord = listeCoordonneesFrance.Count();
            };

            MyPersonalMapData MapData1 = new MyPersonalMapData();

            MapData1.AddCollection(interet);
            MapData1.AddCollection(interet2);
            MapData1.AddCollection(interet3);
            MapData1.AddCollection(interet5);
            MapData1.AddCollection(interet6);
            MapData1.AddCollection(polylineDuSud);
            MapData1.AddCollection(polygoneFrance);

            MapData1.AfficherCollection();

            MapData1.SaveAsBinaryFormat(MapData1.Prenom + MapData1.Nom);
            
            Console.WriteLine("\n\t Appuyez sur une touche pour tester le LOAD\n");
            Console.ReadKey();
            /*
            MapData1.LoadFromBinaryFormat(MapData1.Prenom + MapData1.Nom);
            MapData1.AfficherCollection();
            */
            Console.WriteLine("\n\t Appuyez sur une touche pour mettre fin a l'application\n");
            Console.ReadKey();
            Console.WriteLine("\n\t Confirmation de l'arret de l'application");
            Console.ReadKey();
            #endregion

        }
    }
}
