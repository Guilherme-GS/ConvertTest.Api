using ConvertTest.ApiModels;
using ConvertTest.Models;
using ConvertTest.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertTest.Interfaces.Services
{
    public interface ICallservice
    {
        public Task<ResponseBase> NewCall(CallApiModel call);

        public Task<Call> LastContact(string document);
    }
}
