using System;
using System.Collections.Generic;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Order_Service
    {
        private Order_DAO orderDao = new Order_DAO();

        public List<Order> GetAll()
        {
            return orderDao.GetAll();
        }

        public List<Order> GetAllInRange(DateTime startDate, DateTime endDate)
        {
            List<Order> filter = new List<Order>();
            List<Order> orders = GetAll();

            foreach (Order order in orders)
            {
                if (order.Date.Date >= startDate.Date && order.Date.Date <= endDate.Date)
                    filter.Add(order);
            }

            return filter;
        }

        public int TotalNumberOfDrinks(DateTime startDate, DateTime endDate)
        {
            List<Order> orders = GetAllInRange(startDate, endDate);
            int total = 0;

            foreach (Order order in orders)
                total += order.Number;

            return total;
        }
      
        public int OrderCount()
        {
            return orderDao.OrderCount();
        }

        public void Db_Update_Order(int Id, Drink Drink, Student Student, DateTime Date, int Number)
        {
            orderDao.Db_Update_Order( Id,  Drink,  Student,  Date, Number);
        }
    }
}