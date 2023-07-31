using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;
using EmployeeDesignationDAL;

namespace EmployeeDesignation
{
    public partial class Employees : System.Web.UI.Page
    {

        DataEngine myEngine;
        List<CustomParameters> myCustomParameters;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDesignations();
            }

            myEngine = new DataEngine();
            DataTable dtbl = new DataTable();
            dtbl=myEngine.getData("selectAllEmployees");
            Employee.DataSource = dtbl;
            Employee.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            //string dob = textDOB.SelectedDate.ToString("yyyy-MM-dd");
            string dob = textDOB.Value;
            string gender = txtGender.Text;
            string designationID = ddlDesignations.SelectedValue;

            myCustomParameters = new List<CustomParameters>();

            CustomParameters customParameters1 = new CustomParameters() { ParamName = "@FirstName", ParamValue = firstName };
            myCustomParameters.Add(customParameters1);

            CustomParameters customParameters2 = new CustomParameters() { ParamName = "@LastName", ParamValue = lastName };
            myCustomParameters.Add(customParameters2);

            CustomParameters customParameters3 = new CustomParameters() { ParamName = "@DOB", ParamValue = dob };
            myCustomParameters.Add(customParameters3);

            CustomParameters customParameters4 = new CustomParameters() { ParamName = "@Gender", ParamValue = gender };
            myCustomParameters.Add(customParameters4);

            CustomParameters customParameters5 = new CustomParameters() { ParamName = "@DesignationID", ParamValue = designationID };
            myCustomParameters.Add(customParameters5);

            myEngine = new DataEngine();
            bool IsSaved = myEngine.saveData("insertIntoEmployee", myCustomParameters);

            Response.Redirect("~/Default.aspx");
        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employees.aspx");
        }

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            //string dob = textDOB.SelectedDate.ToString("yyyy-MM-dd");
            string dob = textDOB.Value;
            string gender = txtGender.Text;
            string designationID = ddlDesignations.SelectedValue;

            myCustomParameters = new List<CustomParameters>();

            CustomParameters customParameters1 = new CustomParameters() { ParamName = "@FirstName", ParamValue = firstName };
            myCustomParameters.Add(customParameters1);

            CustomParameters customParameters2 = new CustomParameters() { ParamName = "@LastName", ParamValue = lastName };
            myCustomParameters.Add(customParameters2);

            CustomParameters customParameters3 = new CustomParameters() { ParamName = "@DOB", ParamValue = dob };
            myCustomParameters.Add(customParameters3);

            CustomParameters customParameters4 = new CustomParameters() { ParamName = "@Gender", ParamValue = gender };
            myCustomParameters.Add(customParameters4);

            CustomParameters customParameters5 = new CustomParameters() { ParamName = "@DesignationID", ParamValue = designationID };
            myCustomParameters.Add(customParameters5);

            myEngine = new DataEngine();
            bool IsSaved = myEngine.saveData("insertIntoEmployee", myCustomParameters);

            Response.Redirect("~/ListEmployees.aspx");
        }

        protected void updateEmployee_Click(object sender, EventArgs e)
        {
            int EmployeeID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            myCustomParameters = new List<CustomParameters>();

            CustomParameters customParameters1 = new CustomParameters() { ParamName = "@EmployeeID", ParamValue = EmployeeID };
            myCustomParameters.Add(customParameters1);

            DataTable dtbl = myEngine.getDataByID("employeeBasedOnID", myCustomParameters);


            if (dtbl.Rows.Count > 0)
            {
                DataRow row = dtbl.Rows[0];
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                //textDOB.SelectedDate = Convert.ToDateTime(row["DOB"]);
                txtGender.Text = row["Gender"].ToString();
                string dob = row["DOB"].ToString();

                if (!string.IsNullOrEmpty(dob))
                {
                    DateTime dateOfBirth = DateTime.Parse(dob);
                    string formattedDate = dateOfBirth.ToString("yyyy-MM-dd");
                    textDOB.Value = formattedDate; 
                }

                if (row["DesignationID"] != DBNull.Value)
                {
                    int designationID = Convert.ToInt32(row["DesignationID"]);

                    // Find the corresponding ListItem in the DropDownList by its value and select it
                    ListItem selectedDesignation = ddlDesignations.Items.FindByValue(designationID.ToString());
                    if (selectedDesignation != null)
                    {
                        selectedDesignation.Selected = true;
                    }
                }

                //txtDesignationID.Text = row["DesignationID"].ToString();
            }


        }

        protected void deleteEmployee_Click(object sender, EventArgs e)
        {
            int EmployeeID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            myCustomParameters = new List<CustomParameters>();

            CustomParameters customParameters1 = new CustomParameters() { ParamName = "@EmployeeID", ParamValue = EmployeeID };
            myCustomParameters.Add(customParameters1);

            

            myEngine = new DataEngine();
            bool IsSaved = myEngine.deleteEntry("deleteFromEmployees", myCustomParameters);

            Response.Redirect("~/Employees.aspx");
        }

        protected void BindDesignations()
        {
            myEngine=new DataEngine();
            DataTable dtblDesignations = myEngine.getData("selectAllDesignations");

            ddlDesignations.DataSource = dtblDesignations;
            ddlDesignations.DataBind();
        }
    }
}






























//protected void btnUpdate_Click(object sender, EventArgs e)
//{
//    Button btnUpdate = (Button)sender;
//    string employeeID = btnUpdate.CommandArgument;

//    string connectionString = "Data Source=VINAYAK\\SQLEXPRESS;Initial Catalog=HealthCare;Integrated Security=True;";

//}


