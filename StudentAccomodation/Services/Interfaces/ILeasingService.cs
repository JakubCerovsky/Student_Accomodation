using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Interfaces
{
    public interface ILeasingService
    {
        IEnumerable<Leasing> GetAllLeasings();
        void AddLeasing(Leasing leasing);
    }
}
