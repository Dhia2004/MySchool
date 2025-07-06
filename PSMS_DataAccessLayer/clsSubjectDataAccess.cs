using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    static public class clsSubjectDataAccess
    {
        static public DataTable GetAllSubjects()
        {
            DataTable dtSubjects = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Subjects";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtSubjects.Load(reader);
                else
                    dtSubjects = null;
            }
            catch (Exception ex)
            {
                dtSubjects = null;
            }
            finally { connection.Close(); }

            return dtSubjects;
        }
    }
}
