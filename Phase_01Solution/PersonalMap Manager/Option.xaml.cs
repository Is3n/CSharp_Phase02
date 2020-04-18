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
    /// Interaction logic for Option.xaml
    /// </summary>

    

    public partial class Option : Window
    {
        public delegate void OptionsDelegate(Option OriginWindow);
        public event OptionsDelegate OptionsEvent;

        public Option()
        {
            InitializeComponent();
        }

        #region BUTTONS
        private void Option_Ok_Click(object sender, RoutedEventArgs e)
        {
            OptionsEvent(this);
            this.Close();
        }

        private void Option_Appliquer_Click(object sender, RoutedEventArgs e)
        {
            OptionsEvent(this);
        }

        private void Option_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region COLORS OPTION

        #region BACKGROUND COLORS
        private void ComboBox_Color_Fond_Default_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.AliceBlue;
            TB_ComboBox_Colors_Fond.Background = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Background = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Fond_White_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.White;
            TB_ComboBox_Colors_Fond.Background = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Background = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Fond_Black_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Black;
            TB_ComboBox_Colors_Fond.Background = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Background = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Fond_Yellow_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Yellow;
            TB_ComboBox_Colors_Fond.Background = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Background = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Fond_Green_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Green;
            TB_ComboBox_Colors_Fond.Background = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Background = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Fond_Blue_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Blue;
            TB_ComboBox_Colors_Fond.Background = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Background = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Fond_Red_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Red;
            TB_ComboBox_Colors_Fond.Background = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Background = new SolidColorBrush(color);
        }

        #endregion

        #region TEXT COLORS
        private void ComboBox_Color_Text_Black_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Black;
            TB_ComboBox_Colors_Fond.Foreground = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Foreground = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Text_White_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.White;
            TB_ComboBox_Colors_Fond.Foreground = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Foreground = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Text_Yellow_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Yellow;
            TB_ComboBox_Colors_Fond.Foreground = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Foreground = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Text_Green_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Green;
            TB_ComboBox_Colors_Fond.Foreground = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Foreground = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Text_Blue_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Blue;
            TB_ComboBox_Colors_Fond.Foreground = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Foreground = new SolidColorBrush(color);
        }

        private void ComboBox_Color_Text_Red_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Colors.Red;
            TB_ComboBox_Colors_Fond.Foreground = new SolidColorBrush(color);
            TB_ComboBox_Colors_Text.Foreground = new SolidColorBrush(color);
        }

        #endregion

        #endregion

    }
}
