
using System.Data.SqlClient;

namespace Activity02_databaseApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;";

            SqlConnection myconnection = new SqlConnection();
            myconnection.ConnectionString = connection;
            myconnection.Open();

            SqlCommand mycommand = new SqlCommand();
            mycommand.Connection = myconnection;
            mycommand.CommandText = "Select * from temp";
            SqlDataReader  datareader =mycommand.ExecuteReader();

            int id;
            string firstName,lastName;
            while (datareader.Read())
            {
                id = datareader.GetInt32(0);
                firstName = datareader.GetString(1);
                lastName = datareader.GetString(2);

                label1.Text+=id+"\t"+firstName+"\t"+lastName;

            }

            datareader.Close();
            myconnection.Close();
        }
    }
}