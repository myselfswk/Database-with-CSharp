using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Database_with_CSharp
{
    public partial class SignUp : Form
    {
        SqlConnection conn;
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=DESKTOP-QG8ONMB;Initial Catalog=DatabaseWithCSharp;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "Insert into [user] (username, password, email) values ('"+ txtUsername.Text +"', '"+ txtUserpass.Text + "', '" + txtUserEmail.Text + "')";
                sqlCommand.Connection = conn;

                conn.Open();
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Data Enter Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
