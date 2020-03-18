using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;


namespace SomerenDAL
{
    public class Stock_DAO : Base
    {
        public List<Stock> Db_Get_All_Stocks()
        {
            string query = "SELECT StudentID, Voornaam, Achternaam, GeboorteDatum FROM [Voorraad]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadStudent(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Stock> ReadStudent(DataTable dataTable)
        {
            List<Stock> students = new List<Stock>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Stock stock = new Stock()
                {
                    DrinkID = (int)dr["StudentID"],
                    RegisterID = (int)dr["Voornaam"],
                    Amount = (int)dr["Achternaam"],
                    

                };

                students.Add(stock);
            }
            return students;
        }

    }
}
