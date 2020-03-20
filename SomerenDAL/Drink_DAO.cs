using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Drink_DAO : Base
    {
        public List<Drink> Db_Get_All_Drinks()
        {
            string query = "SELECT DrankID, Naam, Alcholistisch, Prijs FROM [Drankje]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadDrink(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadDrink(DataTable dataTable)
        {
            List<Drink> Drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink Drink = new Drink()
                {
                    Id = (int)dr["DrankID"],
                    Name = (string)dr["Naam"],
                    Alcoholic = (bool)dr["Alcholistisch"],
                    Price = (int)dr["Prijs"]
                    

                };

                Drinks.Add(Drink);
            }
            return Drinks;
        }

    }
}