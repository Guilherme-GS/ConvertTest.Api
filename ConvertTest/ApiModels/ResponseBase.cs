using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertTest.ResponseModels
{
    public class ResponseBase
    {
        public string Document { get; set; }
        public bool ValidDocument { get; set; }
        public string DocumentType {get;set;}
        public bool HasError { get; set; }
        public string Error { get; set; }
        public string ErrorLocation { get; set; }
        public bool HasErrorDB { get; set; }
        public string ErrorDB { get; set; }
        public string ErrorDBLocation { get; set; }
        public bool IsCustomer { get; set; }

    }
}
