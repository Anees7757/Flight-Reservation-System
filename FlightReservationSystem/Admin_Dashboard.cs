using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    public partial class Admin_Dashboard : Form
    {
        String conStr = null;
        SqlConnection con = null;
        public Admin_Dashboard()
        {
            InitializeComponent();
            allFlightsToolStripMenuItem.BackColor = Color.DarkBlue;
            panel1.Hide();
            dataGridView2.Hide();
            conStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Flight Reservation System;Data Source=DESKTOP-CF1EUD1\\SQLEXPRESS;MultipleActiveResultSets=true;";
            con = new SqlConnection(conStr);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            this.Hide();
            frm.Show();
        }

        private void addflightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            addFlightsToolStripMenuItem.BackColor = Color.DarkBlue;
            allFlightsToolStripMenuItem.BackColor = Color.Blue;
            bookedFlightsToolStripMenuItem.BackColor = Color.Blue;
            panel1.Show();
        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flight_Reservation_SystemDataSet1.Bookings' table. You can move, or remove it, as needed.
            this.bookingsTableAdapter.Fill(this.flight_Reservation_SystemDataSet1.Bookings);
            // TODO: This line of code loads data into the 'flight_Reservation_SystemDataSet.Flight' table. You can move, or remove it, as needed.
            this.flightTableAdapter.Fill(this.flight_Reservation_SystemDataSet.Flight);
            allFlightsToolStripMenuItem.BackColor = Color.DarkBlue;
            panel1.Hide();
            dataGridView2.Hide();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.flightTableAdapter.FillBy(this.flight_Reservation_SystemDataSet.Flight);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void bookedFlightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            bookedFlightsToolStripMenuItem.BackColor = Color.DarkBlue;
            allFlightsToolStripMenuItem.BackColor = Color.Blue;
            bookedFlightsToolStripMenuItem.BackColor = Color.Blue;

            dataGridView2.Visible = true;

            con.Open();
            String q = "Select Id,[Flight Id],[User Id],Departure,Arival,[Departure Date],Passengers,Cabin,[Flight Type] from Bookings";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                String q1 = "select Name from Users where Id = " + dr["User Id"] + "";
                SqlCommand cmd1 = new SqlCommand(q1, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read()) {
                    String q2 = "select [Flight No] from Flight where Id = " + dr["User Id"] + "";
                    SqlCommand cmd2 = new SqlCommand(q2, con);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {

                        dataGridView2.Rows.Add(dr[0], dr2["Flight No"], dr1["Name"], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);
                    }
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
                {
                    con.Open();
                    String q = "insert into Flight values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("Flight Added");
                    con.Close();
                }
                else {
                    MessageBox.Show("Please fill all fields before continue");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                con.Open();
                String q = "delete from Flight where Id = " + e.RowIndex + 1 + "";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Flight Deleted");
                this.Hide();
                this.Show();
                con.Close();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                con.Open();
                String q = "delete from Bookings where Id = " + e.RowIndex + 1 + "";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Booking Deleted");
                this.Hide();
                this.Show();
                con.Close();
            }
        }

        private void allFlightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allFlightsToolStripMenuItem.BackColor = Color.DarkBlue;
            panel1.Hide();
            dataGridView2.Hide();
            dataGridView1.Show();
        }
    }
}
