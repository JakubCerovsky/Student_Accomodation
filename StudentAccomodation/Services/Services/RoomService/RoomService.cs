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

        public void AddLeasing(Leasing leasing)
        {
            service.AddLeasing(leasing);
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return service.GetAllRooms();
        }

    }
}
