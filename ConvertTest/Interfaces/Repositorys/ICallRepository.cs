using ConvertTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertTest.Interfaces.Repositories
{
    public interface ICallRepository
    {
        public Task<bool> SaveCall(Call call);

        public Task<Call> LastContact(string document);

        public bool IsCustomer(string document);
    }
}
