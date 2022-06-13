using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FakturyKudlackova
{
    public class SqlRepository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Faktury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Faktury> GetFaktury()
        {
            List<Faktury> Faktury = new List<Faktury>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SELECT * FROM Faktury";
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            var faktury = new Faktury()
                            {
                                id = Convert.ToInt32(sqlDataReader["id"]),
                                datum = Convert.ToDateTime(sqlDataReader["datum"]),
                                cislo = Convert.ToInt32(sqlDataReader["cislo"]),
                                odberatel = Convert.ToString(sqlDataReader["odberatel"]),
                                nazev = Convert.ToString(sqlDataReader["nazev"]),
                                pocet = Convert.ToInt32(sqlDataReader["pocet"]),
                                cena = Convert.ToSingle(sqlDataReader["cena"]),

                            };
                            Faktury.Add(faktury);
                        }
                    }
                }
                sqlConnection.Close();
            }
            return Faktury;
        }
    }
}

