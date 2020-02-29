using HotelManagr.Data.Models_Entitys_;
using HotelManagr.ViewModels.RoomViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagr.Services.Contracts
{
    public interface IRoomServices
    {
        public bool CreateNewRoom(RegisterRoomViewModel newRoom);
        public bool EditRoom(EditRoomViewModel editRoom);
        IEnumerable<Room> GetAll();
        public IEnumerable<Room> GetAll(Expression<Func<Room, bool>> predicate);
        Room GetRoom(int id);
        Room GetRoom(Expression<Func<Room, bool>> predicate);
        bool DeleteRoom(DeleteRoomViewModel deleteRoom);
    }
}
