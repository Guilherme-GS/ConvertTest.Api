using System;

namespace ConvertTest.ApiModels
{
    public class CallApiModel
    {
        public long CallId { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime InitatedDate { get; set; }
    }
}
