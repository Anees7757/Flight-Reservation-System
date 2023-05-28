using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    public partial class Bookings_Home : Form
    {
        int userId;
        public Bookings_Home(int u)
        {
            InitializeComponent();
            userId = u;
        }

        private void Bookings_Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flight_Reservation_SystemDataSet1.Bookings' table. You can move, or remove it, as needed.
            this.bookingsTableAdapter.Fill(this.flight_Reservation_SystemDataSet1.Bookings);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Flight_Home frm = new Flight_Home(u: userId);
            this.Hide();
            frm.Show();
        }
    }
}
