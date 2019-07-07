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
using System.Windows.Shapes;

namespace BindingTest
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Persons> lstPersons { get; set; }
        public List<Locations> lstLocations { get; set; }
        public List<string> lstKlima { get; set; }
        public List<DaysOfWeek> lstDaysOfWeek { get; set; }
        public DaysOfWeek DOW { get; set; }
        public Persons Person { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Person = new Persons
            {
                Vorname = "Philipp",
                Name = "Meißner",
                MobilNr = "07143416914",
                Klima = "Warm"
            };
            DOW = new DaysOfWeek();

            lstPersons = new List<Persons>();
            lstLocations = new List<Locations>();
            lstKlima = new List<string> {"Kalt", "Gemäßigt", "Warm", "Heiß" };
            lstDaysOfWeek = new List<MainWindow.DaysOfWeek>();

            lstPersons.Add(Person);            
            lstLocations.Add(new Locations("Mettmann", 40822, "NRW"));
            lstLocations.Add(new Locations("Monheim am Rhein", 40789, "NRW"));
            lstDaysOfWeek.Add(new DaysOfWeek("Montag", 1));
            lstDaysOfWeek.Add(new DaysOfWeek("Dienstag", 2));
            lstDaysOfWeek.Add(new DaysOfWeek("Mittwoch", 3));
            lstDaysOfWeek.Add(new DaysOfWeek("Donnerstag", 4));
            lstDaysOfWeek.Add(new DaysOfWeek("Freitag", 5));
            lstDaysOfWeek.Add(new DaysOfWeek("Samstag", 6));
            lstDaysOfWeek.Add(new DaysOfWeek("Sonntag", 7));

            DGCB_Location.ItemsSource = lstLocations;
            DGCB_Climate.ItemsSource = lstKlima;
            CBox_DayOfWeek.ItemsSource = lstDaysOfWeek;
            DG_Test.ItemsSource = lstPersons;
            Person.Location = lstLocations[0]; 
            CBox_DayOfWeek.SelectedIndex = 0;
        }

        public class Persons
        {
            public string Vorname { get; set; }
            public string Name { get; set; }
            public string MobilNr { get; set; }
            public Locations Location { get; set; }
            public string Klima { get; set; }
            public static Persons CreateRandom()
            {
                
                Persons result = new Persons();
                Random zufall = new Random((int)(DateTime.Now.ToBinary()));
                result.Vorname = zufall.ToString();
                zufall = new Random(zufall.Next());
                result.Name = zufall.ToString();
                zufall = new Random(zufall.Next());
                result.MobilNr = zufall.ToString();
                return result;
            }
        }        
        public class Locations
        {
            public string City { get; set; }
            public int ZIP { get; set; }
            public string County { get; set; }
            public Locations() {}
            public Locations(string city, int zip, string county)
            {
                this.City = city;
                this.ZIP = zip;
                this.County = county;
            }
        }
        public class DaysOfWeek
        {
            public string Day { get; set; }
            public int Value { get; set; }
            public DaysOfWeek(string day, int value)
            {
                this.Day = day;
                this.Value = value;
            }
            public DaysOfWeek() { }
        }
        private void DG_Test_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(String.Format("Day von DOW ist {0}.", DOW.Day), null, MessageBoxButton.OK);
            DG_Test.Items.Refresh();
        }

        private void CBox_DayOfWeek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        -{
            DOW = (DaysOfWeek)(CBox_DayOfWeek.SelectedItem);
        }
    }
}
