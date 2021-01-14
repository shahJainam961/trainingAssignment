using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Model
{
    public class Hotel
    {


        public long hid { get; set; }
        public string hotelName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public Nullable<long> contactNumber { get; set; }
        public string contactPerson { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string Twitter { get; set; }
        public string isActive { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public string updatedBy { get; set; }

        public string category { get; set; }
        public string price { get; set; }

    }
}
