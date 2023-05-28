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
    public partial class Signup : Form
    {
        String conStr = null;
        SqlConnection con = null;
        public Signup()
        {
            InitializeComponent();
            conStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Flight Reservation System;Data Source=DESKTOP-CF1EUD1\\SQLEXPRESS";
            con = new SqlConnection(conStr);
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            this.Hide();
            frm.Show();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (password_textBox.Text == retype_pass_textBox.Text)
                {
                    con.Open();
                    String q = "insert into Users values('" + name_textBox.Text + "','" + gender_comboBox.SelectedItem + "','" + passport_textBox.Text + "','" + dateTimePicker1.Value + "','" + nationality_textBox.Text + "','" + email_comboBox.SelectedItem + "','" + email_textBox.Text + "','" + phone_comboBox.SelectedItem + "','" + phone_textBox.Text + "','" + city_textBox.Text + "','" + address_textBox.Text + "','" + password_textBox.Text + "'," + 0 + ")";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Account Created Sucessfully");
                    Login frm = new Login();
                    this.Hide();
                    frm.Show();
                }
                else {
                    MessageBox.Show("Password do not match");
                    retype_pass_textBox.Focus();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
