using ConvertTest.Context;
using ConvertTest.Interfaces.Repositories;
using ConvertTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertTest.Repositories
{
    public class CallRepository : ICallRepository
    {
        private readonly AppDbContext _Context;

        public CallRepository(AppDbContext context)
        {
            _Context = context;
        }

        public bool IsCustomer(string document)
        {
            return _Context.Customer.Any(x => x.Document.Equals(document));
        }

        public async Task<Call> LastContact(string document)
        {
            var lastCall = await _Context.Calls.OrderBy(x=>x.Date).LastOrDefaultAsync(x => x.Document.Equals(document));

            return lastCall;
        }

        public async Task<bool> SaveCall(Call call)
        {
            await _Context.AddAsync(call);
            var numberEntitiesWritten = _Context.SaveChanges();
            return numberEntitiesWritten > 0;
        }
    }
}
