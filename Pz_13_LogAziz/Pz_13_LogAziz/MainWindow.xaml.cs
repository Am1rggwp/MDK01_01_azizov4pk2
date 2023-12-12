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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Pz_13_LogAziz
{
    public partial class MainWindow : Window
    {
        DataBaseContext db;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new DataBaseContext();
            var query = db.Trip.Where(t => t.plane == "TU-134")
                .OrderBy(t => t.time_out);
            dbTrip.ItemsSource = query.ToList();
            if (dbTrip.Items.Count > 0)
                dbTrip.SelectedIndex = 0;
        }
        private void dbTrip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic selectedTrip = dbTrip.SelectedItem;
            try
            {
                trip_no.Text = selectedTrip.trip_no.ToString();
                ID_comp.Text = selectedTrip.ID_comp.ToString();
                plane.Text = selectedTrip.plane;
                town_from.Text = selectedTrip.town_from;
                town_to.Text = selectedTrip.town_to.ToString();
                town_out.Text = selectedTrip.time_out.ToString();
                town_in.Text = selectedTrip.time_in.ToString();
            }
            catch
            {

            }
            
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Trip selectedTrip = (Trip)dbTrip.SelectedItem;
            if (selectedTrip != null)
            {
                Trip trip = new Trip();
                trip.trip_no = Convert.ToInt32(trip_no.Text);
                trip.ID_comp = Convert.ToInt32(ID_comp.Text);
                trip.plane=plane.Text;
                trip.town_from= town_from.Text;
                trip.town_to = town_to.Text;
                trip.time_out = Convert.ToDateTime(town_out.Text);
                trip.time_in = Convert.ToDateTime(town_in.Text);

                db.Remove(selectedTrip);
                db.Add(trip);
                db.SaveChanges();
                dbTrip.ItemsSource = db.Trip.ToList();

            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Trip selectedTrip = (Trip)dbTrip.SelectedItem;
            db.Remove(selectedTrip);
            db.SaveChanges();
            dbTrip.ItemsSource = db.Trip.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Trip trip = new Trip();
            trip.trip_no = Convert.ToInt32(trip_no.Text);
            trip.ID_comp = Convert.ToInt32(ID_comp.Text);
            trip.plane = plane.Text;
            trip.town_from = town_from.Text;
            trip.town_to = town_to.Text;
            trip.time_out = Convert.ToDateTime(town_out.Text);
            trip.time_in = Convert.ToDateTime(town_in.Text);
            db.Add(trip);
            db.SaveChanges();
            dbTrip.ItemsSource = db.Trip.ToList();
        }
    }
}
