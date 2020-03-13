using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Rooms_DAO : Base
    {
        public List<Room> Db_Get_All_Rooms()
        {
            string query = "SELECT KamerID, AantalPersonen FROM [Kamer]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadRoom(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadRoom(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room()
                {
                    Number = (int)dr["KamerID"],
                    Capacity = (int)dr["AantalPersonen"],


                };

                rooms.Add(room);
            }
            return rooms;
        }

    }
}