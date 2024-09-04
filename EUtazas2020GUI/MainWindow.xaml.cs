using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EUtazas2020GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string fileSrc = @"..\..\..\src\utasadat.txt";

            var passengers = new List<Utas>();

            foreach (var item in File.ReadAllLines(fileSrc))
            {
                passengers.Add(new(item));
            }

            Console.WriteLine(passengers[0]);
            
            //megalloCombobox.
            asd.Content = passengers[0].ToString();
        }

       
    }

    class Utas
    {
        public int BusStopNumber { get; set; }
        public string TakeOffDate { get; set; }
        public int CardId { get; set; }
        public string TicketType { get; set; }
        public string CardValidityPeriod { get; set; }
        public Utas(string sor) {
            var x = sor.Split(" ");
            BusStopNumber = Convert.ToInt16(x[0]);
            TakeOffDate = x[1];
            CardId = Convert.ToInt16(x[0]);
            TicketType = x[0];
            CardValidityPeriod = x[0];
        }
        public override string ToString()
        {
            return $"Bus stop number: {BusStopNumber}, Take-off date: {TakeOffDate}, Card ID: {CardId}, Ticket type: {TicketType}, Card validity period: {CardValidityPeriod}";
        }
    }
}