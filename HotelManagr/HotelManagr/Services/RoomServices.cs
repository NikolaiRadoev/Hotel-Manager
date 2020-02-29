using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels.RoomViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagr.Services
{
    public class RoomServices : IRoomServices
    {   
        private readonly ApplicationDbContext context;
        public RoomServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CreateNewRoom(RegisterRoomViewModel newRoom)
        {
        //throw new NotImplementedException();
        Room room = new Room
            {
                Capacity=newRoom.Capacity,
                RoomType=newRoom.RoomType,
                FreeRoom=newRoom.FreeRoom,
                PricePerAdult=newRoom.PricePerAdult,
                PricePerKid=newRoom.PricePerKid,
                RoomNumber=newRoom.RoomNumber

            };
            this.context.Rooms.Add(room);
            this.context.SaveChanges();
            /*room = GetRoom(newRoom.Id);
            if (room is null)
            {
                return false;
            }*/
            return true;
        }

        public bool DeleteRoom(DeleteRoomViewModel deleteRoom)
        {
            //throw new NotImplementedException();
            Room room = new Room
            {
                Id = deleteRoom.Id
            };
            this.context.Rooms.Remove(room);
            this.context.SaveChanges();
            return true;
        }

        public bool EditRoom(EditRoomViewModel editRoom)
        {
            //throw new NotImplementedException();
            Room room = new Room
            {
                Capacity = editRoom.Capacity,
                RoomType = editRoom.RoomType,
                FreeRoom = editRoom.FreeRoom,
                PricePerAdult = editRoom.PricePerAdult,
                PricePerKid = editRoom.PricePerKid,
                RoomNumber = editRoom.RoomNumber
            };
            this.context.Rooms.Update(room);
            this.context.SaveChanges();
            return true;
        }

        public IEnumerable<Room> GetAll()
        {
            //throw new NotImplementedException();
            return this.context.Rooms.AsEnumerable();
        }

        public IEnumerable<Room> GetAll(Expression<Func<Room, bool>> predicate)
        {
            //throw new NotImplementedException();
            return this.context.Rooms.Where(predicate).AsEnumerable();
        }

        public Room GetRoom(int id)
        {
            //throw new NotImplementedException();
            return this.context.Rooms.Find(id);
        }

        public Room GetRoom(Expression<Func<Room, bool>> predicate)
        {
            //throw new NotImplementedException();
            return this.context.Rooms.FirstOrDefault(predicate);
        }
    }
}
