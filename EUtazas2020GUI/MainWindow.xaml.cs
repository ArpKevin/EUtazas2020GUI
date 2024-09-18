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
        //public List<Utas> passengers { get; set; }

        private const string fileSrc = @"..\..\..\src\utasadat.txt";
        public MainWindow()
        {
            InitializeComponent();
            //leaseRadioButton.IsChecked = true;

            //passengers = new List<Utas>();

            //foreach (var item in File.ReadAllLines(fileSrc))
            //{
            //    passengers.Add(new(item));
            //}

            //busStopNumberCombobox.Items.Add("Válasszon megállót!"); busStopNumberCombobox.SelectedIndex = 0;

            //foreach (var item in passengers.Select(e => e.BusStopNumber).Distinct())
            //{
            //    busStopNumberCombobox.Items.Add(item);
            //}

            //ticketTypeCombobox.Items.Add("Válasszon megállót!"); ticketTypeCombobox.SelectedIndex = 0;

            //foreach (var item in passengers.Select(e => e.TicketType).Distinct())
            //{
            //    ticketTypeCombobox.Items.Add(item);
            //}

        }

        private void cardIDTextbox_TextChanged(object sender, EventArgs e)
        {
            //cardIdLabel.Content = $"{cardIDTextbox.Text.Length} db";

            //cardIdLabel.Foreground = cardIDTextbox.Text.Length > 7 ? Brushes.Red : SystemColors.WindowTextBrush;
        }   

        private void usableTicketCountSlider_ValueChanged(object sender, EventArgs e)
        {
            //if(usableTicketCountLabel != null) usableTicketCountLabel.Content = $"{usableTicketCountSlider.Value} db";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //var isLeaseChecked = (sender as RadioButton) == leaseRadioButton;

            //leaseGroupbox.Visibility = isLeaseChecked ? Visibility.Visible : Visibility.Collapsed;
            //ticketGroupbox.Visibility = isLeaseChecked ? Visibility.Collapsed : Visibility.Visible;
        }

        private void dataRecordButton_Click(object sender, RoutedEventArgs e)
        {
        //    var selectedBusStopNumber = busStopNumberCombobox.SelectedItem;
        //    var cardId = cardIDTextbox.Text;
        //    var selectedLeaseType = ticketTypeCombobox.SelectedItem;



        //    var busstopnumberplaceholder = busStopNumberCombobox.Items[0];
        //    if (selectedBusStopNumber == null || selectedBusStopNumber == busstopnumberplaceholder)
        //    {
        //        MessageBox.Show("Nem választott megállót!", "Hiba!");
        //        return;
        //    }
        //    DateTime takeOffDate;
        //    if (!DateTime.TryParse(takeOffDate_DatePicker.Text, out takeOffDate))
        //    {
        //        MessageBox.Show("Nem adott meg felszállási dátumot, vagy a dátum formátuma nem helyes!", "Hiba!");
        //        return;
        //    }
        //    TimeSpan takeOffTime;
        //    if (!TimeSpan.TryParse(takeOffTimeTextbox.Text, out takeOffTime))
        //    {
        //        MessageBox.Show("Az felszállás időpontja nem helyes! Használja a 'hh:mm' formátumot.", "Hiba!");
        //        return;
        //    }
        //    if (cardId.Length != 7 || !int.TryParse(cardId, out _))
        //    {
        //        MessageBox.Show("Egy 7 számjegyet tartalmazó kártya azonosítót adjon meg.", "Hiba!");
        //        return;
        //    }

        //    var tickettypeplaceholder = ticketTypeCombobox.Items[0];

        //    if (leaseRadioButton.IsChecked == true)
        //    {
        //        if (selectedLeaseType == null || selectedLeaseType == tickettypeplaceholder)
        //        {
        //            MessageBox.Show("Nem választott bérletet!", "Hiba!");
        //            return;
        //        }
        //        if (ticketValidityDate_Datepicker.SelectedDate == null)
        //        {
        //            MessageBox.Show("Nem adott meg bérlet dátumot!", "Hiba!");
        //            return;
        //        }
        //    }
            

        //    DateTime combinedDateTime = takeOffDate.Date + takeOffTime;

        //    string combinedDateTimeFormat = combinedDateTime.ToString("yyyyMMdd-HHmm");
        //    string ticketValidityDateFormat = string.Empty;
        //    if (ticketValidityDate_Datepicker.SelectedDate != null) ticketValidityDateFormat = ticketValidityDate_Datepicker.SelectedDate.Value.ToString("yyyyMMdd");

        //    string txtAppendLine = string.Empty;
        //    if (leaseRadioButton.IsChecked == true)
        //    {
        //        txtAppendLine = $"{selectedBusStopNumber} {combinedDateTimeFormat} {cardId} {selectedLeaseType} {ticketValidityDateFormat}";
        //    }
        //    else
        //    {
        //        txtAppendLine = $"{selectedBusStopNumber} {combinedDateTimeFormat} {cardId} JGY {usableTicketCountSlider.Value}";
        //    }

        //    using StreamWriter sw = new StreamWriter(fileSrc, true);

        //    sw.WriteLine(txtAppendLine);

        //    MessageBox.Show("A felszállás tárolása sikeres volt!", "EUtazás 2020");

        //    busStopNumberCombobox.SelectedIndex = 0;
        //    takeOffDate_DatePicker.SelectedDate = null;
        //    takeOffTimeTextbox.Clear();
        //    cardIDTextbox.Clear();
        //    ticketTypeCombobox.SelectedIndex = 0;
        //    ticketValidityDate_Datepicker.SelectedDate = null;
        //    usableTicketCountSlider.Value = 0;
        }

        private void newwindowButton_Click(object sender, RoutedEventArgs e)
        {
            //Window2 subWindow = new Window2(passengers);
            //subWindow.Show();
            //this.Hide();
        }
    }

    //public class Utas
    //{
    //    public int BusStopNumber { get; set; }
    //    public string TakeOffDate { get; set; }
    //    public int CardId { get; set; }
    //    public string TicketType { get; set; }
    //    public string CardValidityPeriod { get; set; }
    //    public Utas(string sor) {
    //        var x = sor.Split(" ");
    //        BusStopNumber = Convert.ToInt32(x[0]);
    //        TakeOffDate = x[1];
    //        CardId = Convert.ToInt32(x[2]);
    //        TicketType = x[3];
    //        CardValidityPeriod = x[4];
    //    }
    //    public override string ToString()
    //    {
    //        return $"Bus stop number: {BusStopNumber}, Take-off date: {TakeOffDate}, Card ID: {CardId}, Ticket type: {TicketType}, Card validity period: {CardValidityPeriod}";
    //    }
    //}
}