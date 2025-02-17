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

namespace SQL_Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\USERS\\M2303661\\ONEDRIVE - MIDDLESBROUGH COLLEGE\\YEAR 2\\C#\\SQL PRACTICE\\DB.MDF";

            SqlConnection sqlConnection = new SqlConnection(connectionString);



            //Use stored procedure
            SqlCommand command = new SqlCommand("CreateNewPersonRecord", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;


            //Input name and age from form
            string name = txtName.Text;
            int age = int.Parse(txtAge.Text);


            //Call stored procedure passing name and age as parameters
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Age", age);

            //Open connection to database, execute stored procedure and close the connection
            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //Read a person record
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\USERS\\M2303661\\ONEDRIVE - MIDDLESBROUGH COLLEGE\\YEAR 2\\C#\\SQL PRACTICE\\DB.MDF";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetPersonDetails", sqlConnection);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sd.Fill(dt);
            sqlConnection.Close();


            //Read rows of database and extract fields
            foreach (DataRow dr in dt.Rows)

            {
                int personID = (int)(dr["Id"]);
                string personName = (string)(dr["Name"]);
                int personAge = (int)(dr["Age"]);
                string personPhone = (string)(dr["Phone"]);
                string personEmail = (string)(dr["Email"]);

                txtPeople.AppendText(personName + "\t" + personAge.ToString() + "\t" + personPhone + "\t" + personEmail + "\t" + personID + "\t" + Environment.NewLine);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\USERS\\M2303661\\ONEDRIVE - MIDDLESBROUGH COLLEGE\\YEAR 2\\C#\\SQL PRACTICE\\DB.MDF";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

                
            //USE STORED PROCEDURE
            SqlCommand command = new SqlCommand("UpdatePerson", sqlConnection);

            command.CommandType = CommandType.StoredProcedure;

            string name = txtEditName.Text;
            int age = int.Parse(txtEditAge.Text);
            string phoneNo = txtEditPhoneNo.Text;
            string email = txtEditEmail.Text;
            string currentID = txtID.Text;

            command.Parameters.AddWithValue("@StdID", currentID);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Age", age);
            command.Parameters.AddWithValue("@Phone", phoneNo);
            command.Parameters.AddWithValue("@Email", email);

            sqlConnection.Open();

            command.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Use stored procedure to delete record(s) containing a given name

            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\USERS\\M2303661\\ONEDRIVE - MIDDLESBROUGH COLLEGE\\YEAR 2\\C#\\SQL PRACTICE\\DB.MDF";

            SqlConnection sqlConnection = new SqlConnection(connectionString);


            //USE STORED PROCEDURE

            SqlCommand command = new SqlCommand("DeletePerson", sqlConnection);

            command.CommandType = CommandType.StoredProcedure;

            string name = txtDelName.Text;

            command.Parameters.AddWithValue("@Name", name);

            sqlConnection.Open();

            command.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}