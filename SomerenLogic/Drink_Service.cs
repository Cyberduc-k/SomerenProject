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
    public class Drink_Service
    {
        Drink_DAO room_db = new Drink_DAO();
        
        public List<Drink> GetDrink()
        {


            return room_db.Db_Get_All_Drinks(); 
            

        }
    }
    
}
