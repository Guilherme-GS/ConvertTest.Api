using ConvertTest.ApiModels;
using ConvertTest.Enums;
using ConvertTest.Helpers;
using ConvertTest.Interfaces.Repositories;
using ConvertTest.Interfaces.Services;
using ConvertTest.Models;
using ConvertTest.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertTest.Services
{
    public class CallService : ICallservice
    {
        private readonly ICallRepository _Repository;

        public CallService(ICallRepository repository)
        {
            _Repository = repository;
        }

        public async Task<Call> LastContact(string document)
        {
            var documentWithoutMask = new String(document.Where(Char.IsDigit).ToArray());
            return await _Repository.LastContact(documentWithoutMask);
        }

        public async Task<ResponseBase> NewCall(CallApiModel call)
        {
            //remove mask
            var document = new String(call.Document.Where(Char.IsDigit).ToArray());

            var newCall = new Call();
            var documentTypeName = "Outro";
            if (document.Length == 11)
            {
                newCall.ValidDocument = DocumentValidation.ValidCpf(document);
                newCall.DocumentType = (int)DocumentTypeEnum.CPF;
                documentTypeName = "CPF";
            }
            else if(document.Length == 14)
            {
                newCall.ValidDocument = DocumentValidation.ValidCnpj(document);
                newCall.DocumentType = (int)DocumentTypeEnum.CNPJ;
                documentTypeName = "CNPJ";
            }
            else
            {
                newCall.ValidDocument = false;
                newCall.DocumentType = (int)DocumentTypeEnum.Other;
            }

            newCall.Document = document;
            newCall.IsCustomer =  _Repository.IsCustomer(document);
            newCall.CallId = call.CallId;
            newCall.Date = call.InitatedDate;
            newCall.PhoneNumber = call.PhoneNumber;

            var sucesso =await _Repository.SaveCall(newCall);

            var response = new ResponseBase
            {
                Document = newCall.Document,
                DocumentType = documentTypeName,
                ValidDocument= newCall.ValidDocument,
                IsCustomer=newCall.IsCustomer
            };

            return response;

        }
    }
}
