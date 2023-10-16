using log4net;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RoleBasedAccessControl_Authorization
{
    public partial class Form1 : Form
    {
        MyConnection db = new MyConnection();
        public Form1()
        {
            InitializeComponent();
        }

        ILog log;
        private void Form1_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            log = LogManager.GetLogger(typeof(Form1));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_role_login", db.con);
                cmd.CommandType = CommandType.StoredProcedure;
                db.con.Open();
                cmd.Parameters.AddWithValue("@uname", textBox1.Text);
                cmd.Parameters.AddWithValue("@upass", textBox2.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.HasRows)
                {
                    rdr.Read();
                    if (rdr[4].ToString() == "Admin")
                    {
                        MyConnection.type = "A";
                    }
                    else if (rdr[4].ToString() == "User")
                    {
                        MyConnection.type = "U";
                    }

                    log.Info("Login successfully");

                    Form2 f = new Form2();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    log.Error("Login Failed");
                    MessageBox.Show("Error Login");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
