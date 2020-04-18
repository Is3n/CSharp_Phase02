using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;
using MyCartographyObj;

namespace PersonalMap_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            /*listBox1.Items.Add(Menu_TextBox1.Text);
            listBox1.Items.Add(Menu_TextBox2.Text);
            listBox1.Items.Add(Menu_TextBox3.Text);*/

            
            MyPersonalMapData MyMap = new MyPersonalMapData();

            MyMap.LoadFromBinaryFormat("IsenClaes"/*MyMap.Prenom + MyMap.Nom*/);
            try
            {
                foreach (ICartoObj obj in MyMap.MaCollection) 
                {
                    if (obj is Polyline)
                    {
                        Polyline p = (Polyline)obj;
                        p.Couleur = (Color)ColorConverter.ConvertFromString(p.CouleurString);
                        addNewPolyline(p.ListeCoord, System.Windows.Media.Color.FromArgb(p.Couleur.A, p.Couleur.R, p.Couleur.G, p.Couleur.B), p.Epaisseur); 
                        listBox1.Items.Add(p);
                    }
                    else if (obj is Polygone)
                    {
                        Polygone p = (Polygone)obj;
                        p.Remplissage = (Color)ColorConverter.ConvertFromString(p.RemplissageString);
                        p.Contour = (Color)ColorConverter.ConvertFromString(p.ContourString);
                        addNewPolygon(p.ListeCoord, System.Windows.Media.Color.FromArgb(p.Remplissage.A, p.Remplissage.R, p.Remplissage.G, p.Remplissage.B), System.Windows.Media.Color.FromArgb(p.Contour.A, p.Contour.R, p.Contour.G, p.Contour.B), p.Opacite); 
                        listBox1.Items.Add(p);
                    }
                    else if (obj is POI)
                    {
                        POI p = (POI)obj;
                        addNewPOI(p);
                        listBox1.Items.Add(p);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("La collection est vide");
            }

            


        }
        private void Menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Tools_About_Click(object sender, RoutedEventArgs e)
        {
            AboutMe About1 = new AboutMe();
            About1.ShowDialog();
        }
        private void Tools_Option_Click(object sender, RoutedEventArgs e)
        {
            Option Option1 = new Option();
            Option1.Owner = this;
            Option1.Show();

            Option1.OptionsEvent += OptionsApplyClick;
        }

        private void OptionsApplyClick(Option MyOptions)
        {
            switch(MyOptions.ComboBox_OpColors_Fond.Text)
            {
                case "AliceBlue (Default)":
                    listBox1.Background = Brushes.AliceBlue;
                    break;
                case "White":
                    listBox1.Background = Brushes.White;
                    break;
                case "Black":
                    listBox1.Background = Brushes.Black;
                    break;
                case "Yellow":
                    listBox1.Background = Brushes.Yellow;
                    break;
                case "Green":
                    listBox1.Background = Brushes.Green;
                    break;
                case "Blue":
                    listBox1.Background = Brushes.Blue;
                    break;
                case "Red":
                    listBox1.Background = Brushes.Red;
                    break;
            }

            switch (MyOptions.ComboBox_OpColors_Text.Text)
            {
 
                case "White":
                    listBox1.Foreground = Brushes.White;
                    break;
                case "Black (Default)":
                    listBox1.Foreground = Brushes.Black;
                    break;
                case "Yellow":
                    listBox1.Foreground = Brushes.Yellow;
                    break;
                case "Green":
                    listBox1.Foreground = Brushes.Green;
                    break;
                case "Blue":
                    listBox1.Foreground = Brushes.Blue;
                    break;
                case "Red":
                    listBox1.Foreground = Brushes.Red;
                    break;
            }
        }

        #region COLOR COMBOBOX
        /*
        private void CBI_Color_Default_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.AliceBlue;
            Color color2 = Colors.Black;
            MainToolBar.Background = new SolidColorBrush(color);
            listBox1.Background = new SolidColorBrush(color);
            listBox1.Foreground = new SolidColorBrush(color2);
        }
        private void CBI_Color_Yellow_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Yellow;
            Color color2 = Colors.Black;
            MainToolBar.Background = new SolidColorBrush(color);
            listBox1.Background = new SolidColorBrush(color);
            listBox1.Foreground = new SolidColorBrush(color2);
        }
        private void CBI_Color_Green_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Green;
            Color color2 = Colors.White;
            MainToolBar.Background = new SolidColorBrush(color);
            listBox1.Background = new SolidColorBrush(color);
            listBox1.Foreground = new SolidColorBrush(color2);
        }
        private void CBI_Color_Blue_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Blue;
            Color color2 = Colors.White;
            MainToolBar.Background = new SolidColorBrush(color);
            listBox1.Background = new SolidColorBrush(color);
            listBox1.Foreground = new SolidColorBrush(color2);
        }
        private void CBI_Color_Red_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Red;
            Color color2 = Colors.White;
            MainToolBar.Background = new SolidColorBrush(color);
            listBox1.Background = new SolidColorBrush(color);
            listBox1.Foreground = new SolidColorBrush(color2);
        }
        private void CBI_Color_White_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.White;
            Color color2 = Colors.Black;
            MainToolBar.Background = new SolidColorBrush(color);
            listBox1.Background = new SolidColorBrush(color);
            listBox1.Foreground = new SolidColorBrush(color2);
        }
        */
        #endregion

        
        private void addNewPOI(POI p)
        {
            Console.WriteLine("fonction addNewPOI");
            Pushpin push = new Pushpin();
            push.Background = new SolidColorBrush(System.Windows.Media.Colors.Red);
            push.Location = new Location(p.Latitude, p.Longitude);
            push.Content = p.Id;
            push.Foreground = new SolidColorBrush(System.Windows.Media.Colors.White);
            MyMap.Children.Add(push);
        }


        private void addNewPolygon(List<MyCartographyObj.Coordonnees> ListCoord, Color couleurfond, Color couleurcontour, double Opacite)
        {
            Console.WriteLine("fonction addNewPolygone");
            LocationCollection LocationList = new LocationCollection();
            foreach (Coordonnees c in ListCoord)
                LocationList.Add(new Location(c.Latitude, c.Longitude));

            MapPolygon polygon = new MapPolygon();
            polygon.Fill = new System.Windows.Media.SolidColorBrush(couleurfond);
            polygon.Stroke = new System.Windows.Media.SolidColorBrush(couleurcontour);
            polygon.StrokeThickness = 3;
            polygon.Opacity = Opacite;
            polygon.Locations = LocationList;
            MyMap.Children.Add(polygon); 
        }

        private void addNewPolyline(List<MyCartographyObj.Coordonnees> ListCoord, Color co, double Epaisseur)
        {
            Console.WriteLine("fonction addNewPolyline");
            LocationCollection LocationList = new LocationCollection();
            foreach (Coordonnees c in ListCoord) 
                LocationList.Add(new Location(c.Latitude, c.Longitude));

            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new SolidColorBrush(co);
            polyline.StrokeThickness = Epaisseur;
            polyline.Opacity = 0.5;
            polyline.Locations = LocationList;
            MyMap.Children.Add(polyline);
        }

        

    }
}
