using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Persons> lstPersons { get; set; }
        public List<Locations> lstLocations { get; set; }
        public List<string> lstKlimas { get; set; }
        public List<DaysOfWeek> lstDaysOfWeek { get; set; }
        public DaysOfWeek DOW { get; set; }
        public Persons Person { get; set; }
        public bool IsColumnVisible { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DG_Test.DataContext = this;
            SP_UserControl.DataContext = this;

            Person = new Persons
            {
                Vorname = "Philipp",
                Name = "Meißner",
                MobilNr = "07143416914",
                Klima = "Warm"
            };
            DOW = new DaysOfWeek();
            lstPersons = new ObservableCollection<Persons>();
            lstLocations = new List<Locations>();
            lstDaysOfWeek = new List<DaysOfWeek>();
            lstKlimas = new List<string> { "Kalt", "Gemäßigt", "Warm", "Heiß" };
            lstLocations.Add(new Locations("Mettmann", 40822, "NRW"));
            lstLocations.Add(new Locations("Monheim am Rhein", 40789, "NRW"));
            lstPersons.Add(Person);

            DGCB_Location.ItemsSource = lstLocations;
            DGCB_Climate.ItemsSource = lstKlimas;
            
            lstDaysOfWeek.Add(new DaysOfWeek("Montag", 1));
            lstDaysOfWeek.Add(new DaysOfWeek("Dienstag", 2));
            lstDaysOfWeek.Add(new DaysOfWeek("Mittwoch", 3));
            lstDaysOfWeek.Add(new DaysOfWeek("Donnerstag", 4));
            lstDaysOfWeek.Add(new DaysOfWeek("Freitag", 5));
            lstDaysOfWeek.Add(new DaysOfWeek("Samstag", 6));
            lstDaysOfWeek.Add(new DaysOfWeek("Sonntag", 7));

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
            BitArray bitArray64 = new BitArray(64);
            for (int index = 0; index < bitArray64.Length; index += 4)
            {
                bitArray64[index] = true;
            }
            ulong ergebnis = Conversion.ToULong(array: bitArray64);

            MessageBox.Show(String.Format("Das Ergebnis lautet: {0}.", ergebnis.ToString("N0")), "Umwandlung", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    public class Locations
    {
        public string City { get; set; }
        public int ZIP { get; set; }
        public string County { get; set; }
        public Locations() { }
        public Locations(string city, int zip, string county)
        {
            this.City = city;
            this.ZIP = zip;
            this.County = county;
        }
    }
    public class B2MVConv: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<Visibility> visibilities = new List<Visibility>(values.Length);
            visibilities = values.Cast<Visibility>().ToList();
            return visibilities.All(x => x == Visibility.Visible);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isChecked = (bool)(value);
            List<object> result = new List<object>();
            Visibility visible = Visibility.Visible;
            Visibility collapsed = Visibility.Collapsed;
            if (isChecked) 
            { 
                for (int index = 0; index < targetTypes.Length; index++) 
                { 
                    result.Add(visible); 
                } 
            }
            else 
            { 
                for (int index = 0; index < targetTypes.Length; index++) 
                { 
                    result.Add(collapsed); 
                } 
            } 
            return result.ToArray();
        }
    }
    public class B2VConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Visibility)(value) == Visibility.Visible) { return true; }
            else { return false; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)(value))
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
    }
    public class V2BConv: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)(value))
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Visibility)(value) == Visibility.Visible) { return true; }
            else { return false; }
        }
    }
    public class Conversion
    {
        /// <summary>
        /// Wandelt ein 64-Bitarray in eine 64-Bit Ganzzahl ohne Vorzeichen um.
        /// </summary>
        /// <param name="array">Das umzuwandelnde 64-Bitarray.</param>
        /// <returns>Das umgewandelte Array als 64-Bit Ganzzahl.</returns>
        public static ulong ToULong(BitArray array)
        {
            byte[] result = new byte[8];
            array.CopyTo(result, 0);
            return BitConverter.ToUInt64(result, 0);
        }
    }
}
