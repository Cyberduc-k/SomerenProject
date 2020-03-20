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
            string query = "SELECT DrankID, KassaID, Aantal FROM [Voorraad]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadStock(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Stock> ReadStock(DataTable dataTable)
        {
            List<Stock> stocks = new List<Stock>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Stock stock = new Stock()
                {
                    DrinkID = (int)dr["DrankID"],
                    RegisterID = (int)dr["KassaID"],
                    Amount = (int)dr["Aantal"],
                    

                };

                stocks.Add(stock);
            }
            return stocks;
        }

    }
}
