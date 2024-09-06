using Microsoft.VisualBasic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
        private const string fileSrc = @"..\..\..\src\utasadat.txt";
        public MainWindow()
        {
            InitializeComponent();
            //takeOffDate_DatePicker.SelectedDate = DateTime.Now;
            //ticketValidityDate_Datepicker.SelectedDate = DateTime.Now;
            leaseRadioButton.IsChecked = true;

            

            var passengers = new List<Utas>();

            foreach (var item in File.ReadAllLines(fileSrc))
            {
                passengers.Add(new(item));
            }

            busStopNumberCombobox.Items.Add("Válasszon megállót!"); busStopNumberCombobox.SelectedIndex= 0;

            foreach (var item in passengers.Select(e => e.BusStopNumber).Distinct())
            {
                busStopNumberCombobox.Items.Add(item);
            }

            ticketTypeCombobox.Items.Add("Válasszon megállót!"); ticketTypeCombobox.SelectedIndex = 0;

            foreach (var item in passengers.Select(e => e.TicketType).Distinct())
            {
                ticketTypeCombobox.Items.Add(item);
            }

        }

        private void cardIDTextbox_TextChanged(object sender, EventArgs e)
        {
            if (cardIDTextbox.Text != null) cardIdLabel.Content = $"{cardIDTextbox.Text.Length} db";

            cardIdLabel.Foreground = cardIDTextbox.Text.Length > 7 ? Brushes.Red : SystemColors.WindowTextBrush;
        }   

        private void usableTicketCountSlider_ValueChanged(object sender, EventArgs e)
        {
            //to be fixed 
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var isLeaseChecked = (sender as RadioButton) == leaseRadioButton;

            leaseGroupbox.Visibility = isLeaseChecked ? Visibility.Visible : Visibility.Collapsed;
            ticketGroupbox.Visibility = isLeaseChecked ? Visibility.Collapsed : Visibility.Visible;
        }

        private void dataRecordButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBusStopNumber = busStopNumberCombobox.SelectedItem;
            var takeOffTime = takeOffTimeTextbox.Text;
            var cardId = cardIDTextbox.Text;
            var selectedLeaseType = ticketTypeCombobox.SelectedItem;

            var busStopNumberPlaceholder = busStopNumberCombobox.Items[0];
            if (selectedBusStopNumber == null || selectedBusStopNumber == busStopNumberPlaceholder)
            {
                MessageBox.Show("Nem választott megállót!", "Hiba!");
                return;
            }
            if (takeOffDate_DatePicker.SelectedDate == null)
            {
                MessageBox.Show("Nem adott meg felszállási dátumot!", "Hiba!");
                return;
            }
            if (!IsValidTimeFormat(takeOffTime))
            {
                MessageBox.Show("Időpont formátuma nem helyes! Használja a 'hh:mm' formátumot.", "Hiba!");
                return;
            }
            if (cardId.Length != 7 || !int.TryParse(cardId, out _))
            {
                MessageBox.Show("Egy 7 számjegyet tartalmazó kártya azonosítót adjon meg.", "Hiba!");
                return;
            }
            if (leaseRadioButton.IsChecked == true)
            {
                var ticketTypePlaceholder = ticketTypeCombobox.Items[0];

                if (selectedLeaseType == null || selectedLeaseType == ticketTypePlaceholder)
                {
                    MessageBox.Show("Nem választott bérletet!", "Hiba!");
                    return;
                }
            }
            if (ticketValidityDate_Datepicker.SelectedDate == null)
            {
                MessageBox.Show("Nem adott meg bérlet dátumot!", "Hiba!");
                return;
            }

            using StreamWriter sw = new(fileSrc);

            //----------------------
            //sw.WriteLine($"{selectedBusStopNumber} ");
        }

        private bool IsValidTimeFormat(string timeText)
        {
            // Regular expression for 'hh:mm' format
            var regex = new Regex(@"^(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$");

            if (!regex.IsMatch(timeText))
                return false;

            // Additional checks can be added if necessary
            return true;
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
            BusStopNumber = Convert.ToInt32(x[0]);
            TakeOffDate = x[1];
            CardId = Convert.ToInt32(x[2]);
            TicketType = x[3];
            CardValidityPeriod = x[4];
        }
        public override string ToString()
        {
            return $"Bus stop number: {BusStopNumber}, Take-off date: {TakeOffDate}, Card ID: {CardId}, Ticket type: {TicketType}, Card validity period: {CardValidityPeriod}";
        }
    }
}