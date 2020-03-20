using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

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
    

