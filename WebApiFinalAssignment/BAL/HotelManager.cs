using HM_BAL.Interface;
using HM_DAL.Repository;
using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_BAL
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string bookRoom(Booking model)
        {
            return _hotelRepository.bookRoom(model);
        }

        public List<Booking> checkBooking(Booking model)
        {
            return _hotelRepository.checkBooking(model);
        }

        public string createHotel(Hotel model)
        {
            return _hotelRepository.createHotel(model);
        }

        public string createRoom(Room model)
        {
            return _hotelRepository.createRoom(model);
        }

        public string deleteBooking(int id)
        {
            return _hotelRepository.deleteBooking(id);
        }

        public List<Hotel> GetAllHotels()
        {
            var data = _hotelRepository.GetAllHotels();
            return data;
        }

        public Hotel GetHotel()
        {
            var hotel = _hotelRepository.GetHotel();

            return hotel;
        }

        public Hotel GetHotel(int id)
        {
            var hotel = _hotelRepository.GetHotel(id);

            return hotel;
        }

        public string UpdateBookingdate(Booking model)
        {
            return _hotelRepository.UpdateBookingdate(model);
        }

        public string UpdateBookingStatus(Booking model)
        {
            return _hotelRepository.UpdateBookingStatus(model);
        }

        public IQueryable getRoomsByPara(Hotel model)
        {
            return _hotelRepository.getRoomsByPara(model);

        }
    }
}
