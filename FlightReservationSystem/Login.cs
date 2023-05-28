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
    public partial class Login : Form
    {
        String conStr = null;
        SqlConnection con = null;
        public Login()
        {
            InitializeComponent();
            conStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Flight Reservation System;Data Source=DESKTOP-CF1EUD1\\SQLEXPRESS";
            con = new SqlConnection(conStr);
            id_textBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup frm = new Signup();
            this.Hide();
            frm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int userId;
            try {
                if (id_textBox.Text != "" || password_textBox.Text != "")
                {
                    if (id_textBox.Text == "admin" && password_textBox.Text == "admin")
                    {
                        Admin_Dashboard frm = new Admin_Dashboard();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        con.Open();
                        String q = "select * from Users where Email = '" + id_textBox.Text + "' AND Password = '" + password_textBox.Text + "'";
                        SqlCommand cmd = new SqlCommand(q, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                userId = int.Parse(dr[0].ToString());
                                con.Close();
                                Flight_Home frm = new Flight_Home(u: userId);
                                this.Hide();
                                frm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Provided Credentials are Incorrect");
                            }
                        }
                    }
                }
                else {
                    MessageBox.Show("Fields must be filled");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
