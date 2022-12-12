using System.CodeDom.Compiler;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace testProject
{
    public partial class Form1 : Form
    {
        public string Dbconnection = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        
        
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            testgen<int> intValue= new testgen<int>(2);
            testgen<string> stringvalue = new testgen<string>("Hello");
            this.label1.Text = "" + intValue.returnValue();
            this.label1.Text += "\n"+stringvalue.returnValue();



            // Database Connection Code
            SqlConnection connection;

            connection = new SqlConnection();

            connection.ConnectionString= Dbconnection;

            /*SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from temp";
            command.Connection = connection;


            connection.Open();


            SqlDataReader reader=command.ExecuteReader();
            */
            ////This is test /////////////////////////////
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT CategoryID, CategoryName FROM Categories;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                            reader.GetString(1));
                    }
                }
                else
                {
                    label1.Text = "No rows Found";
                }
                reader.Close();
            }





            /////////////////////////////////////////////           
        }
 
    }







    class testgen<T>
    {
        T test;

        public testgen(T value)
        {
            test = value;
        }

        public T returnValue()
        {
            return test;
        }

    }





}