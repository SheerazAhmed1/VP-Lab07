using System.Data;

namespace testProject2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataSet salesSet=new DataSet();

            DataTable orderTable=new DataTable("order");

            DataColumn colId=new DataColumn("OrderId",typeof(string));
            orderTable.Columns.Add(colId);

            DataColumn colDate = new DataColumn("OrderDate", typeof(DateTime));
            orderTable.Columns.Add(colDate);

            orderTable.PrimaryKey=new DataColumn[] {colId};


            DataRow row1=orderTable.NewRow();
            row1["OrderId"] = "00001";
            row1["OrderDate"] = new DateTime(2013, 3, 1);
            orderTable.Rows.Add(row1);

            salesSet.Tables.Add(orderTable);


            label1.Text = salesSet.Tables["order"].Rows[0]["OrderDate"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}