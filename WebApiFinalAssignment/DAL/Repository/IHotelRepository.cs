using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_DAL.Repository
{
    public interface IHotelRepository
    {
        Hotel GetHotel();
        Hotel GetHotel(int id);

        List<Hotel> GetAllHotels();

        String createHotel(Hotel model);

        String createRoom(Room model);

        String bookRoom(Booking model);

        List<Booking> checkBooking(Booking model);

        IQueryable getRoomsByPara(Hotel model);

        String deleteBooking(int id);



        String UpdateBookingdate(Booking model);

        String UpdateBookingStatus(Booking model);
    }
}
