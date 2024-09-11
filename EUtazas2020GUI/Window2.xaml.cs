using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EUtazas2020GUI
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private List<Utas> passengersConsole;
        public Window2(List<Utas> passengers)
        {
            InitializeComponent();

            this.passengersConsole = passengers;
            lbl1.Content = $"3. feladat\nA buszra {passengersConsole.Count} utas akart felszállni.";

            

            lbl2.Content = $"4.feladat\nA buszra {passengersConsole.Count(p => int.Parse(p.CardValidityPeriod) == 0)} utas nem szállhatott fel.";
        }
    }
}
