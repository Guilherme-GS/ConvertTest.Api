using ConvertTest.Context;
using ConvertTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertTest.ResponseModels;
using System.Data.Common;
using ConvertTest.Helpers;
using ConvertTest.Enums;
using ConvertTest.ApiModels;
using ConvertTest.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace ConvertTest.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class CallController: ControllerBase
    {
        private readonly ICallservice _callService;
        private readonly ILogger<CallController> _logger;

        public CallController(ICallservice callService,ILogger<CallController> logger)
        {
            _logger = logger;
            _callService = callService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseBase>> NewCall(CallApiModel call)
        {
            var response = new ResponseBase();
            try
            {
                return await _callService.NewCall(call);
            }
            catch (DbException e)
            {
                response.HasError = true;
                response.HasErrorDB = true;
                response.Error = e.Message;
                response.ErrorDB = e.Message;
                _logger.LogError(e, "erro de banco de dados");
            }
            catch (Exception e)
            {
                response.HasError = true;
                response.Error = e.Message;
                _logger.LogError(e, "erro desconhecido");
            }


            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult<LastContactResponse>> LastContact(string document)
        {
            var response = new LastContactResponse();
            try
            {
                var lastCall = await _callService.LastContact(document);

                if (lastCall == null)
                {
                    return NotFound();
                }

                response = new LastContactResponse(lastCall);

            }
            catch(DbException e)
            {
                response.HasError = true;
                response.HasErrorDB = true;
                response.Error = e.Message;
                response.ErrorDB = e.Message;
                _logger.LogError(e, "erro de banco de dados");
            }
            catch(Exception e)
            {
                response.HasError = true;
                response.Error = e.Message;
                _logger.LogError(e, "erro desconhecido");
            }

            return Ok(response);
        }
    }
}
