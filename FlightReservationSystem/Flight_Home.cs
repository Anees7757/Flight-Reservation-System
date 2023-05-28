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
    public partial class Flight_Home : Form
    {
        string connetionString = null;
        SqlConnection cnn = null;
        int UserId;
        int FlightId;
        public Flight_Home(int u)
        {
            InitializeComponent();
            radioButton1.Checked = true;
            connetionString = "Integrated Security=SSPI;Initial Catalog=Flight Reservation System;Data Source=DESKTOP-CF1EUD1\\SQLEXPRESS";
            cnn = new SqlConnection(connetionString);
            groupBox1.Hide();
            noFlightLabel.Hide();
            for(int i=0; i<dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value = "Select";
            }
            UserId = u;
            //try
            //{
            //    String query = "select distinct Arival from Flight union select distinct Departure from Flight";
            //    cnn.Open();
            //    SqlCommand command = new SqlCommand(query, cnn);
            //    SqlDataReader dr = command.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            fromComboBox.Items.Add(dr["Departure"]);
            //            toComboBox.Items.Add(dr["Departure"]);
            //            fromComboBox.Items.Add(dr["Arival"]);
            //            toComboBox.Items.Add(dr["Arival"]);
            //        }
            //    }
            //    else
            //    {
            //        fromComboBox.Items.Add("N/A");
            //        toComboBox.Items.Add("N/A");
            //    }
            //    UserId = u;
            //}
            //catch (Exception ex) { 
            //    MessageBox.Show(ex.Message);
            //}

            //if (fromComboBox.Text.Length == 0 || totb.Text.Length == 0)
            //{
            //    fromComboBox.Text = "From";
            //    fromComboBox.ForeColor = Color.Gray;
            //    totb.Text = "To";
            //    totb.ForeColor = Color.Gray;
            //}
        }

        //private void Flight_Home_Load(object sender, EventArgs e)
        //{
            //if (fromComboBox.Text.Length == 0 || totb.Text.Length == 0)
            //{
            //    fromComboBox.Text = "From";
            //    fromComboBox.ForeColor = Color.Gray;
            //    totb.Text = "To";
            //    totb.ForeColor = Color.Gray;
            //}
        //}

        //private void fromtb_Leave(object sender, EventArgs e)
        //{
        //    if (fromComboBox.Text.Length == 0)
        //    {
        //        fromComboBox.Text = "From";
        //        fromComboBox.ForeColor = Color.Gray;
        //    }
        //}
        //private void fromtb_Enter(object sender, EventArgs e)
        //{
        //    if (fromtb.Text.Equals("From"))
        //    {
        //        fromtb.Clear();
        //        fromtb.ForeColor = Color.Black;

        //    }
        //}

        //private void totb_Leave(object sender, EventArgs e)
        //{
        //    if (fromtb.Text.Length == 0)
        //    {
        //        totb.Text = "To";
        //        totb.ForeColor = Color.Gray;
        //    }
        //}
        //private void totb_Enter(object sender, EventArgs e)
        //{
        //    if (totb.Text.Equals("To"))
        //    {
        //        totb.Clear();
        //        totb.ForeColor = Color.Black;

        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (fromComboBox.SelectedItem != toComboBox.SelectedItem)
                {
                    string type="";
                    if (radioButton1.Checked == true)
                    {
                        type = radioButton1.Text;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        type = radioButton2.Text;
                    }
                    else { 
                    }


                    cnn.Open();

                    if (cnn.State == ConnectionState.Open)
                    {
                        MessageBox.Show(UserId.ToString());
                        string q = "insert into Bookings values(" + FlightId + "," + UserId + ",'" + fromComboBox.SelectedItem + "','" + toComboBox.SelectedItem + "','" + departureDTP.Value + "','" + returnDTP.Value + "','" + passengersCB.SelectedItem + "','" + cabinCB.SelectedItem + "','" + type + "')";
                        SqlCommand cmd = new SqlCommand(q, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Flight Booked");
                        cnn.Close();

                        departureDTP.Hide();
                        returnDTP.Hide();
                        groupBox1.Hide();
                        label6.Hide();
                        label7.Hide();
                        label8.Hide();
                        label9.Hide();
                        button1.Hide();
                        passengersCB.Hide();
                        cabinCB.Hide();
                        toComboBox.SelectedIndex = 0;
                        fromComboBox.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Departure and Arival must be different");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            this.Hide();
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Bookings_Home frm = new Bookings_Home(u: UserId);
            this.Hide();
            frm.Show();
        }

        Boolean isFilter = false;

        private void searchBtn_Click(object sender, EventArgs e)
        {
            String query;
            if (isFilter == true)
            {
                query = "select * from Flight where Departure = '" + fromComboBox.SelectedItem + "' AND Arival = '" + toComboBox.SelectedItem + "' AND depDate = '" + dateTimePicker1.Value.ToShortDateString() + "'";
            }
            else
            {
                query = "select * from Flight where Departure = '" + fromComboBox.SelectedItem + "' AND Arival = '" + toComboBox.SelectedItem + "'";
            }
                cnn.Open();
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                dataGridView1.Show();
                dataGridView1.Rows.Clear();
                while (dr.Read())
                {
                    if (isFilter == true) {
                        dataGridView1.Columns[4].Visible = true;
                        dataGridView1.Rows.Add(dr[1], dr[2], dr[3], dr[4]);
                    }
                    else
                    {
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Rows.Add(dr[1], dr[2], dr[3]);
                    }
                   
                }
            }
            else
            {
                groupBox1.Hide();
                label6.Hide();
                label7.Hide();
                dataGridView1.Hide();
                departureDTP.Hide();
                returnDTP.Hide();
                label8.Hide();
                label9.Hide();
                button1.Hide();
                passengersCB.Hide();
                cabinCB.Hide();
                noFlightLabel.Show();
            }
            cnn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FlightId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            dataGridView1.Hide();
            groupBox1.Show();
            searchBtn.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            returnDTP.Show();
            label7.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            returnDTP.Hide();
            label7.Hide();
            dateTimePicker1.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            isFilter = true;
        }
    }
}
