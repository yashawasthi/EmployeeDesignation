using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDesignationDAL
{
    public class DataEngine
    {
        string connectionString = "Data Source=VINAYAK\\SQLEXPRESS;Initial Catalog=HealthCare;Integrated Security=True;";



        //START MAKING CHANGES FROM HERE

        public DataTable getData(string storedProcedureName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlDataAdapter sqlDa = new SqlDataAdapter(storedProcedureName, connection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                connection.Close();

                return dtbl;

            }
        }


        public DataTable getDataByID(string storedProcedureName,List<CustomParameters> param = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (param != null)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        string paramname = param[i].ParamName;
                        object paramvalue = param[i].ParamValue;
                        command.Parameters.AddWithValue(paramname, paramvalue);
                    }
                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlDataAdapter sqlDa = new SqlDataAdapter(storedProcedureName, connection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                connection.Close();

                return dtbl;

            }
        }

        public bool deleteEntry(string storedProcedureName, List<CustomParameters> param = null)
        {
            bool isSaved = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (param != null)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        string paramname = param[i].ParamName;
                        object paramvalue = param[i].ParamValue;
                        command.Parameters.AddWithValue(paramname, paramvalue);
                    }
                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    isSaved = true;
                }
            }
            return isSaved;
        }

        //END MAKING CHANGES HERE
        public bool saveData(string storedProcedureName,List<CustomParameters> param = null)
        {

            bool isSaved = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {                
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if(param != null)
                {
                    for(int i = 0; i < param.Count; i++)
                    {
                        string paramname = param[i].ParamName;
                        object paramvalue = param[i].ParamValue;
                        command.Parameters.AddWithValue(paramname, paramvalue);
                    }
                }
                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }                
                int rowsAffected=command.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    isSaved = true;
                }

            }
            return isSaved;
        }

        public bool deleteData(string storedProcedureName, List<CustomParameters> param = null)
        {
            bool isSaved = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        string paramname = param[i].ParamName;
                        object paramvalue = param[i].ParamValue;
                        command.Parameters.AddWithValue(paramname, paramvalue);
                    }
                }

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    isSaved = true;
                }
            }

            return isSaved;

        }
    }
}






//public DataTable getData(string storedProcedureName)
//{
//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
//        {
//            command.CommandType = CommandType.StoredProcedure;
//            DataTable dtbl = new DataTable();

//                connection.Open();
//                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
//                {
//                    adapter.Fill(dtbl);
//                }
//                connection.Close();

//            return dtbl;
//        }
//    }
//}