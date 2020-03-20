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
    }
}
