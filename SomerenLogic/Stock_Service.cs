using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Stock_Service
    {
        Stock_DAO stock_db = new Stock_DAO();

        public List<Stock> GetStock()
        {


            return stock_db.Db_Get_All_Stocks();


        }

        public void Update_Stock(int DrankID, int Amount)
        {
            stock_db.Db_Update_Stock(DrankID, Amount);
        }

        public void Update_Name(int DrankID, string Name)
        {
            stock_db.Db_Update_Name(DrankID, Name);
        }

        public void Add_To_Stock(int DrankID, string Name, int Price, int Stock, bool Alcohol)
        {
            stock_db.Db_Add_To_Stock(DrankID, Name, Price, Stock, Alcohol);
        }
    }
}
