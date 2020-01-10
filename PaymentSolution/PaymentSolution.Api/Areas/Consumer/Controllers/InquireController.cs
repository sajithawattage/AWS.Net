using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSolution.Api.Areas.Consumer.Data;

namespace PaymentSolution.Api.Areas.Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquireController : ControllerBase
    {
        private readonly IDynamodb _dynamodb;

        public InquireController(IDynamodb dynamodb)
        {
            _dynamodb = dynamodb;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _dynamodb.CreateDynamoDbTable();

            return Ok();
        }

        [HttpPost]
        public void Post([FromBody] Models.InquireModel model)
        {
            if (ModelState.IsValid)
            {
                
            }


        }
    }
}