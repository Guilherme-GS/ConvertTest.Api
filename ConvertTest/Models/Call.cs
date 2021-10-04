using System;

namespace ConvertTest.Models
{
    public class Call
    {
        public int Id { get; set; }
        public long CallId { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public bool IsCustomer { get; set; }
        public int DocumentType { get; set; }
        public bool ValidDocument { get; set; }
    }
}
