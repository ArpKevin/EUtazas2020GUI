//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace EUtazas2020GUI
//{
//    /// <summary>
//    /// Interaction logic for Window2.xaml
//    /// </summary>
//    public partial class Window2 : Window
//    {
//        private List<Utas> passengersConsole;
//        public Window2(List<Utas> passengers)
//        {
//            InitializeComponent();

//            this.passengersConsole = passengers;

//            lbl1.Content = $"3. feladat\nA buszra {passengersConsole.Count()} utas akart felszállni.";
//            lbl2.Content = $"4. feladat\nA buszra {passengersConsole.Count(p => p.CardValidityPeriod == "0" ||
//                (DateTime.TryParseExact(p.CardValidityPeriod, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var cardValidityDate) &&
//                 DateTime.TryParseExact(p.TakeOffDate, "yyyyMMdd-HHmm", null, System.Globalization.DateTimeStyles.None, out var takeOffDate) &&
//                 takeOffDate > cardValidityDate && takeOffDate.Date != cardValidityDate.Date))} utas nem szállhatott fel.";


//            var f5 = passengersConsole.GroupBy(p => p.BusStopNumber).MaxBy(g => g.Count());

//            lbl3.Content = $"5. feladat\nA legtöbb utas ({f5.Key} fő) a {f5.Count()}. megállóban próbált felszállni.";

//            var f6Ervenyesek = passengersConsole.Where(p => int.Parse(p.CardValidityPeriod) != 0);
//            var f6Ingyenes = f6Ervenyesek.Count(p => p.TicketType == "NYP" || p.TicketType == "RVS" || p.TicketType == "GYK");
//            var f6Kedvezmenyes = f6Ervenyesek.Count(p => p.TicketType == "TAB" || p.TicketType == "NYB");

//            lbl4.Content = $"6. feladat\nIngyenesen utazók száma: {f6Ingyenes} fő\nA kedvezményesen utazók száma: {f6Kedvezmenyes} fő";

//            var f7Berlet = passengersConsole
//             .Where(p => DateTime.TryParseExact(p.CardValidityPeriod, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out _))
//             .Select(p => new
//             {
//                 CardID = p.CardId,
//                 TakeOffDate = DateTime.ParseExact(p.TakeOffDate, "yyyyMMdd-HHmm" ,null),
//                 CardValidityPeriod = DateTime.ParseExact(p.CardValidityPeriod, "yyyyMMdd", null)
//             }).ToList();

//            using StreamWriter sw = new(@"..\..\..\src\figyelmeztetes.txt", false);

//            foreach (var item in f7Berlet)
//            {
//                var expiryTime = (item.CardValidityPeriod - item.TakeOffDate);

//                if (expiryTime.TotalDays <= 3)
//                {
//                    sw.WriteLine($"{item.CardID} {item.CardValidityPeriod.ToString("yyyy-MM-dd")}");
//                }
//            }
//        }
//    }
//}