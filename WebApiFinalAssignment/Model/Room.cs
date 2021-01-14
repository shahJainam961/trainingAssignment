using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Model
{
    public class Room
    {

        public long rid { get; set; }
        public Nullable<long> hotelid { get; set; }
        public string roomName { get; set; }
        public string category { get; set; }
        public string price { get; set; }
        public Nullable<long> isActive { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public string updatedBy { get; set; }

    }
}
