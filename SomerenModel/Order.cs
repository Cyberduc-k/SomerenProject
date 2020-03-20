using System;

namespace SomerenModel
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Student Student { get; set; }
        public CashRegister CashRegister { get; set; }
        public Drink Drink { get; set; }
        public DateTime Date { get; set; }
    }
}