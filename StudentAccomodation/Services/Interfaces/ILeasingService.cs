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
        Leasing GetLeasingByStudentNo(int studentNo);
        void AddLeasing(Leasing leasing);

    }
}
