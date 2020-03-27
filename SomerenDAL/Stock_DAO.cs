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
            //To select collums from the 'Voorrad' and 'Drankje' table, with this it's possible to show the needed information. Also we can filter out free drinks and drinks that are no longer in stock
            string query = "SELECT V.DrankID, V.KassaID, V.Aantal, D.Naam, D.Alcholistisch, D.Prijs FROM Voorraad as V join Drankje as D on D.DrankID = V.DrankID where v.Aantal > 1 AND d.Prijs > 1";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadStock(ExecuteSelectQuery(query, sqlParameters));
        }

        //update Stock 
        public void Db_Update_Stock(int DrankID, int Amount)
        {
            //Update stock of drink
            string UDAmount = $"UPDATE [Voorraad] SET [Aantal] = '{Amount}' WHERE [DrankID] = '{DrankID}'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(UDAmount, sqlParameters);
        }

        public void Db_Update_Name(int DrankID, string Name)
        {
            //Update name of drink
            string UDName = $"UPDATE [Drankje] SET [Naam] = '{Name}' WHERE [DrankID] = '{DrankID}'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(UDName, sqlParameters);
        }

        public void Db_Add_To_Stock(int DrankID, string Name,int Price, int Amount, bool Alcohol)
        {
            //add drinks to stock 
            string InstertDrink= $"Insert into [Drankje] (DrankID, Naam, Prijs, Alcholistisch ) Values ( {DrankID},'{Name}', {Price}, '{Alcohol}' ";
            string InstertStock = $"Insert into [Voorraad] (DrankId, KassaID, Aantal) Values ({DrankID}, 0 ,{Amount})";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            ExecuteEditQuery(InstertDrink, sqlParameters);
            ExecuteEditQuery(InstertStock, sqlParameters);
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
                    Name = (string)dr["Naam"],
                    Price = (int)dr["Prijs"],
                    Alcohol = (bool)dr["Alcholistisch"]
                };

                stocks.Add(stock);
            }
            
            return stocks;
        }
    }
}
