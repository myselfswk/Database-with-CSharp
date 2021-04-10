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
    public partial class SignIn : Form
    {
        SqlConnection conn;
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=DESKTOP-QG8ONMB;Initial Catalog=DatabaseWithCSharp;Integrated Security=True");
                string credentials = "select * from [DatabaseWithCSharp].[dbo].[user] where [username] = '"+ txtUsername.Text +"' and [password] = '"+ txtUserPass.Text +"'";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(credentials, conn);
                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Check Your Email And Password");
                }
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
