using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Order_DAO : Base
    {
        public List<Order> GetAll()
        {
            string query =
                "SELECT BestellingId, Aantal, Datum, B.StudentId, B.KassaId, B.DrankId,\n" +
                "S.Voornaam AS StudentVoornaam, S.Achternaam AS StudentAchternaam, GeboorteDatum,\n" +
                "Omzet, Vouchers, K.DocentId,\n" +
                "D.Voornaam AS DocentVoornaam, D.Achternaam AS DocentAchternaam, D.KamerId,\n" +
                "[Naam] AS DrankNaam, Prijs, Alcholistisch\n" +
                "FROM [Bestellingen] AS B\n" +
                "JOIN [Studenten] AS S ON B.StudentId = S.StudentId\n" +
                "JOIN [Kassa] AS K ON B.KassaId = K.KassaId\n" +
                "JOIN [Drankje] AS DR ON B.DrankId = DR.DrankId\n" +
                "JOIN [Docenten] AS D ON K.DocentId = D.DocentId";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadOrders(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Order> ReadOrders(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order()
                {
                    Id = (int)dr["BestellingId"],
                    Number = (int)dr["Aantal"],
                    Date = (DateTime)dr["Datum"],
                    Student = new Student()
                    {
                        Id = (int)dr["StudentId"],
                        FirstName = (string)dr["StudentVoornaam"],
                        LastName = (string)dr["StudentAchternaam"],
                        BirthDate = (DateTime)dr["GeboorteDatum"],
                    },
                    CashRegister = new CashRegister()
                    {
                        Id = (int)dr["KassaId"],
                        Sales = (int)dr["Omzet"],
                        Vouchers = (int)dr["Vouchers"],
                        Teacher = new Teacher()
                        {
                            Id = (int)dr["DocentId"],
                            FirstName = (string)dr["DocentVoornaam"],
                            LastName = (string)dr["DocentAchternaam"],
                            RoomNumber = (int)dr["KamerId"],
                        }
                    },
                    Drink = new Drink()
                    {
                        Id = (int)dr["DrankId"],
                        Name = (string)dr["DrankNaam"],
                        Price = (int)dr["Prijs"],
                        Alcoholic = (bool)dr["Alcholistisch"],
                    }
                };

                orders.Add(order);
            }

            return orders;
        }
    }
}
