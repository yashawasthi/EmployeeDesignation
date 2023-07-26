using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;

namespace EmployeeDesignation
{
    public partial class Designation : System.Web.UI.Page
    {
        string connectionString = "Data Source=VINAYAK\\SQLEXPRESS;Initial Catalog=HealthCare;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("selectAllDesignations", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                Designations.DataSource = dtbl;
                Designations.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string designation = txtDesignation.Text;

                string query = "insertIntoDesignation";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DesignationName", designation);

                connection.Open();
                command.ExecuteNonQuery();
            }

            Response.Redirect("~/Default.aspx");
        }


        protected void updateDesignation_Click(object sender, EventArgs e)
        {
            int DesignationID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "designationBasedOnID";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DesignationID", DesignationID);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtDesignation.Text = reader["DesignationName"].ToString();
                    }
                }
            }
        }


        protected void deleteDesignation_Click(object sender, EventArgs e)
        {
            int DesignationID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "deleteFromDesignation";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DesignationID", DesignationID);
                connection.Open();
                command.ExecuteNonQuery();
            }


            Response.Redirect("~/Designation.aspx");
        }
    }
}