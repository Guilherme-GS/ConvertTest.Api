using ConvertTest.Enums;
using ConvertTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertTest.ResponseModels
{
    public class LastContactResponse:ResponseBase
    {
        public LastContactResponse()
        {

        }

        public LastContactResponse(Call call)
        {
            var documentTypeName = "Outro";
            switch (call.DocumentType)
            {
                case (int)DocumentTypeEnum.CPF:
                    documentTypeName = "CPF";
                    break;
                case (int)DocumentTypeEnum.CNPJ:
                    documentTypeName = "CNPJ";
                    break;
                default:
                    break;
            }

            Document = call.Document;
            IsCustomer = call.IsCustomer;
            DocumentType = documentTypeName;
            ValidDocument = call.ValidDocument;
            LastContact = call.Date;
        }
        public DateTime LastContact { get; set; }
    }
}
