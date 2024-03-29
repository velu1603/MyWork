﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests._Help
{
    public class SQLHelperMethods
    {
        // The below static method is to get the GUID from OpenDay table for Create Event testcases
        public static Guid GetIdFromDb(string eventName)
        {
            var ConnectionString = @ConfigurationManager.AppSettings["TestDBConnection"];
            var vQuery = "SELECT ID,IsDeleted FROM OpenDay WHERE EventName = '" + eventName + "'";

            SqlConnection Connection;  // It is for SQL connection
            Connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(vQuery, Connection);
            Guid ID = Guid.Empty;
            try
            {
                Connection.Open();
                Console.WriteLine("Connection with database is done. for getting the ID");

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {                                     
                    Console.WriteLine(dr["ID"]);
                    Console.WriteLine(dr["IsDeleted"]);                    
                    ID = dr.GetGuid(0);                

                }

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                Connection.Dispose();
                Connection.Close();
                Console.WriteLine("Connection with database is closed--for getting ID");
            }

            return ID;
        }
        public static void DeleteIdFromDb(Guid ID)
        {
            var ConnectionString = @ConfigurationManager.AppSettings["TestDBConnection"];
            var vQuery = "update OpenDay set IsDeleted = 1 where id = '"+ ID +"'";
            

            //"SELECT ID FROM OpenDay WHERE EventName = '" + eventName + "'";


            SqlConnection Connection;  // It is for SQL connection
            Connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(vQuery, Connection);
            //Guid ID = Guid.Empty;
            try
            {
                Connection.Open();
                Console.WriteLine("Connection with database is done for deleting ID.");
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {                   
                  Console.WriteLine(dr["ID"]);                    
                }

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                Connection.Dispose();
                Connection.Close();
                Console.WriteLine("Connection with database is closed --for deleting ID");
            }

            


        }

    }

}
