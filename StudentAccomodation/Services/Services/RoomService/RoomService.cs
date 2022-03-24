using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.RoomService
{
    public class RoomService:IRoomService
    {
        private ADORoom service;

        public RoomService(ADORoom roomService)
        {
            service = roomService;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return service.GetAllRooms();
        }

        public IEnumerable<Room> GetAllVacantRooms()
        {
            return service.GetAllVacantRooms();
        }
    }
}
