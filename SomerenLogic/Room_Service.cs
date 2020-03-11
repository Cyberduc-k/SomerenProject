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
    public class Room_Service
    {
        Rooms_DAO room_db = new Rooms_DAO();
        
        public List<Room> GetRoom()
        {


            return room_db.Db_Get_All_Rooms(); 
            

        }
    }
    
}
