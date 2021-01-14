using AutoMapper;
using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HM_DAL.Repository
{
   public class HotelRepository :IHotelRepository
    {
        private readonly DAL.Database.HMEntities dbContext;

        public HotelRepository()
        {
            dbContext = new DAL.Database.HMEntities();
        }

        public string bookRoom(Booking model)
        {
            try
            {
                if (model != null)
                {

                    var entity = dbContext.tbl_room.Find(model.roomid);


                    DAL.Database.tbl_room room = new DAL.Database.tbl_room();

                    DAL.Database.tbl_booking book = new DAL.Database.tbl_booking();

                    book.bookingDate = model.bookingDate;
                    book.roomid = model.roomid;
                    book.statusOfBooking = "Definitive";
                    book.hotelid = model.hotelid;
                    book.isActive = 0;

                    entity.isActive = 1;

                                     
                    dbContext.tbl_booking.Add(book);
                    dbContext.SaveChanges();
                    return "Booked Successfully.";
                }
                return "Model is Null.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public List<Booking> checkBooking(Booking model)
        {

           

            List<Booking> bookingDetails = new List<Booking>();


            var roomentity = dbContext.tbl_room.ToList();


            if (roomentity!=null)
            {

            
            foreach (var item in roomentity)
            {


                    var entityy = dbContext.tbl_booking.Where(x=>x.roomid==item.rid & x.bookingDate==model.bookingDate);
                    
                    if(entityy.Count()!=0)
                    {
                        foreach (var i in entityy)
                        {
                            Booking book = new Booking();
                            book.bookingId = 0;
                            book.roomid = i.roomid;
                            book.hotelid = i.hotelid;
                            book.roomNumber = item.roomName;
                           
                            if(i.isActive==1)
                            {
                                book.statusOfBooking = "True";
                            }
                            else
                            {
                                book.statusOfBooking = "False";
                            }
                          


                            bookingDetails.Add(book);
                         }
                    }
                    
                    else
                    {
                        Booking book2 = new Booking();
                        book2.roomid = item.rid;
                        book2.hotelid = item.hotelid;
                        book2.statusOfBooking = "True";
                        book2.roomNumber = item.roomName;
                        bookingDetails.Add(book2);
                    }
                 


                }
            if(bookingDetails.Count==0)
                {
                    return null;
                }
                return bookingDetails;
            }
            else
            {
                return null;
            }
           
        }

        public string createHotel(Hotel model)
        {
            try
            {
                if (model != null)
                {


                    DAL.Database.tbl_hotel entities = new DAL.Database.tbl_hotel();

                    entities.hotelName = model.hotelName;
                    entities.address = model.address;
                    entities.city = model.city;
                    entities.pincode = model.pincode;
                    entities.contactPerson = model.contactPerson;
                    entities.contactNumber = model.contactNumber;
                    entities.createdBy = model.createdBy;
                    entities.createDate = DateTime.Now;
                    entities.updatedBy = model.updatedBy;
                    entities.updateDate = DateTime.Now;
                    entities.facebook = model.facebook;
                    entities.Twitter = model.Twitter;
                    entities.isActive = "0";
                    entities.website = model.website;


                    dbContext.tbl_hotel.Add(entities);
                    dbContext.SaveChanges();
                    return "Data Submitted Successfully.";
                }
                return "Model is Null.";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string createRoom(Room model)
        {
            try
            {
                if (model != null)
                {


                    DAL.Database.tbl_room entities = new DAL.Database.tbl_room();
                   

                    entities.hotelid = model.hotelid;
                    entities.category = model.category;
                    entities.price = model.price;
                    entities.createdBy = model.createdBy;
                    entities.createdDate = DateTime.Now;
                    entities.updatedBy = model.updatedBy;
                    entities.updateDate =DateTime.Now;
                    entities.roomName = model.roomName;
                    entities.isActive = 0;
                                      

                  

                    dbContext.tbl_room.Add(entities);
                  
                    dbContext.SaveChanges();
                    return "Room Booked Successfully.";
                }
                return "Model is Null.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string deleteBooking(int id)
        {
            var entity = dbContext.tbl_booking.Find(id);

            var entity2 = dbContext.tbl_room.Find(entity.roomid);
            
            if (entity != null)
            {
                entity.isActive = 1;
                entity.statusOfBooking = "Deleted";
                entity2.isActive = 0;
                dbContext.SaveChanges();
                return "Deleted Successfully.";
            }
            else
            {
                return "Null";
            }
           
        }

      

        public List<Hotel> GetAllHotels()

        { 
            
            List<Hotel> hotelDetails = new List<Hotel>();
            // GET all hotels sort by alphabetic order. Response: List of hotels 
            var data = dbContext.tbl_hotel.OrderBy(x => x.hotelName).ToList();


            if (data!=null)
            {
                
                foreach (var item in data)
                {
                    Hotel hotel = new Hotel();
                    hotel.hid = item.hid;
                    hotel.hotelName = item.hotelName;
                    hotel.address = item.address;
                    hotel.city = item.city;
                    hotel.pincode = item.pincode;
                    hotel.contactPerson = item.contactPerson;
                    hotel.contactNumber = item.contactNumber;
                    hotel.createdBy = item.createdBy;
                    hotel.createDate = item.createDate;
                    hotel.updatedBy = item.updatedBy;
                    hotel.updateDate = item.updateDate;
                    hotel.facebook = item.facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.isActive = item.isActive;
                    hotel.website = item.website;

                    hotelDetails.Add(hotel);
                }
            }
            return hotelDetails;
        }

        public Hotel GetHotel()
        {
            Hotel hotel = new Hotel
            {
                hid = 2,
                hotelName = "Gateway",
                address = "Ahmedabad"

            };
            return hotel;
        }

        public Hotel GetHotel(int id)
        {
            try
            {
                var entity = dbContext.tbl_hotel.Find(id);
                 if(entity!=null)
                {
                    Hotel hotel = new Hotel();
                    hotel.hid = entity.hid;
                    hotel.hotelName = entity.hotelName;
                    hotel.address = entity.address;
                    hotel.city = entity.city;
                    hotel.pincode = entity.pincode;
                    hotel.contactPerson = entity.contactPerson;
                    hotel.contactNumber = entity.contactNumber;
                    hotel.createdBy = entity.createdBy;
                    hotel.createDate = entity.createDate;
                    hotel.updatedBy = entity.updatedBy;
                    hotel.updateDate = entity.updateDate;
                    hotel.facebook = entity.facebook;
                    hotel.Twitter = entity.Twitter;
                    hotel.isActive = entity.isActive;
                    hotel.website = entity.website;

                    return hotel;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
      
        }

        public IQueryable getRoomsByPara(Hotel model)
        {
           

           // var hotalData = dbContext.tbl_hotel.Where(x=>x.city==model.city || x.pincode==model.pincode);
            var hotalData = from h in dbContext.tbl_hotel
                     join r in dbContext.tbl_room on h.hid equals r.hotelid
                    where h.city ==model.city || h.pincode==model.pincode || r.price==model.price || r.category==model.category
                     orderby r.price
                     select new
                     {
                         h.hid,
                         r.rid,
                         r.roomName,
                         h.hotelName,
                         r.category,
                         r.price,
                         h.pincode,
                         h.city,
                         
                      };

            return hotalData;



        }

        public string UpdateBookingdate(Booking model)
        {
            var entity = dbContext.tbl_booking.Find(model.bookingId);

            if(entity!=null)
            {
                entity.bookingDate = model.bookingDate;
                dbContext.SaveChanges();
                return "Updated Successfully.";
            }
            
            return "Something went wrong";


        }

        public string UpdateBookingStatus(Booking model)
        {
            var entity = dbContext.tbl_booking.Find(model.bookingId);

            if (entity != null)
            {
                entity.statusOfBooking = model.statusOfBooking;
                dbContext.SaveChanges();
                return "Status Updated Successfully.";
            }

            return "Something went wrong";
        }

       
    }
}
