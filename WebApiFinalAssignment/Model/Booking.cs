using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Model
{
    public class Booking
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long bookingId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<long> roomid { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string statusOfBooking { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string bookingDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<long> hotelid { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<int> isActive { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string hotelName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string roomNumber { get; set; }
    }
}
