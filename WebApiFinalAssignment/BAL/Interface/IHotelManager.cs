using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_BAL.Interface
{
    public interface IHotelManager
    {
        Hotel GetHotel();
        Hotel GetHotel(int id);

        List<Hotel> GetAllHotels();

        String createHotel(Hotel model);
        String createRoom(Room model);

        String bookRoom(Booking model);

        List<Booking> checkBooking(Booking model);

        String UpdateBookingdate(Booking model);
        String UpdateBookingStatus(Booking model);



        IQueryable getRoomsByPara(Hotel model);
        String deleteBooking(int id);
    }
}
