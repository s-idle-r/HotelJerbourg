using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelJerbourg.Models
{
    public class Bill
    {
        public int BillID { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }

        public Bill()
        {

        }

        public virtual Client Client { get; set; }
    }
}