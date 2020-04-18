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
using System.Windows.Shapes;

namespace PersonalMap_Manager
{
    /// <summary>
    /// Interaction logic for Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m1 = new MainWindow();
            m1.Show();
            Close();
        }
    }
}
