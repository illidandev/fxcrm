using AventStack.ExtentReports;
using Npgsql;
using NUnit.Framework;
using CrmAutoTestNUnit.Base_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmAutoTestNUnit;
using System.Data.SqlClient;

namespace CrmAutoTestNUnit.DB_connectors
{
    public class ConnectToDb
    {
         protected TestsConfiguration _conf = null;

        public int  ConnectToDbTest()
        {
            /* if we have more than 1 column
            List<string> dataFromDb = new List<string>();*/
            string dataFromDb= "";
            _conf = TestsConfiguration.Instance;
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.IndexOf("bin"));
            string projectPth = new Uri(actualPath).LocalPath;

            FileInfo file = new FileInfo(projectPth + @"DBcon\myQuery.sql");
            string script = file.OpenText().ReadToEnd();

            try
            {
                _conf = TestsConfiguration.Instance;
                string connstring = _conf.Connstring;
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(script,connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //dataFromDb.Add(dataReader[0].ToString() + " " + dataReader[1].ToString() + " " + dataReader[2].ToString() + " ");
                        dataFromDb = dataReader[0].ToString();
                    }
                    
                    PropertiesCollection._reportingTasks.Log(Status.Info, "<b>" + "There are records in the table : " +dataFromDb + "<br>");
                    connection.Close();
                    int counts = Int32.Parse(dataFromDb);
                    return counts;
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                PropertiesCollection._reportingTasks.Log(Status.Error, msg.ToString());
                throw;
            }
        }

    }
}
