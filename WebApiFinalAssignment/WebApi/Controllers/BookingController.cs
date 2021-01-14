using HM_BAL.Interface;
using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMWebApi.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IHotelManager _IHotelManager;
        public BookingController(IHotelManager hotelManager)
        {
            this._IHotelManager = hotelManager;
        }

        // GET: api/Booking

        public List<Hotel> GetHotels()
        {

            var hotel = _IHotelManager.GetAllHotels();
            return hotel;
        }

        // GET: api/Booking/5
        public HttpResponseMessage GetHotelById(int id)
        {
            var hotel = _IHotelManager.GetHotel(id);
            return Request.CreateResponse<Hotel>(HttpStatusCode.OK, hotel);
        }

        // POST: api/Booking
        public string createHotel([FromBody] Hotel model)
        {
            return _IHotelManager.createHotel(model);
        }

        // POST: api/Booking

        public string createRoom([FromBody] Room model)
        {
            return _IHotelManager.createRoom(model);
        }
        public string bookRoom([FromBody] Booking model)
        {
            return _IHotelManager.bookRoom(model);
        }

        [HttpPut]
        // PUT: api/Booking/5
        public String UpdateBookingDate([FromBody] Booking model)
        {
            return _IHotelManager.UpdateBookingdate(model);
        }

        [HttpPut]
        public String UpdateBookingStatus([FromBody] Booking model)
        {
            return _IHotelManager.UpdateBookingStatus(model);
        }

        // DELETE: api/Booking/5
        public String DeleteBooking(int id)
        {
            return _IHotelManager.deleteBooking(id);
        }

        [HttpPost]
        public List<Booking> checkAvailability([FromBody] Booking model)
        {

            var booking = _IHotelManager.checkBooking(model);

            return booking;

        }

        [HttpPost]
        public IQueryable getRoomsByParameters([FromBody] Hotel model)
        {

            var data = _IHotelManager.getRoomsByPara(model);

            return data;

        }


    }
}

