using IPInfo.Application.DTOs.ExternalServices;
using IPInfo.Application.Features.Commands;
using IPInfo.Application.Features.Requests;
using IPInfo.Domain.Entities.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IPInfo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IpDetailsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public IpDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{ip}")]
        public async Task<ActionResult<GetIpDetailsDto>> GetIpDetailsAsync(string ip)
        {
            try
            {
                var details = await _mediator.Send(new RetrieveIpDetails() { Ip = ip });
                return Ok(details);
            }
            catch (Exception ex) { return  BadRequest(ex); }    
        }
        [HttpPost("/batchUpdate")]
       
        public async Task<ActionResult<Guid>> BatchUpdateIpsRequestAsync([FromBody] IEnumerable<IpDetails> ipDetailsTbU)
        {
            var result = await _mediator.Send(new BatchUpdateIpDetails { IpDetails = ipDetailsTbU });
            if (result != default)
            { 
                //RedirectToAction("BatchUpdateInvoke", ipDetailsTbU);
                //var t = Task.Run(() => _mediator.Send(new BatchUpdateIpDetailsProcessRequest { IpDetailsTbU = ipDetailsTbU }));
                return Ok($"Job Guid: {result}");
            }
            else
            {
                return BadRequest("something went wrong");
            }
        }
        [HttpPost("/batchUpdateStatus/{id}")]

        public async Task<ActionResult<Guid>> BatchUpdateIpsRequestStatusAsync(Guid id)
        {
            var result = ""; //await _mediator.Send(new BatchUpdateIpDetails { IpDetails = ipDetailsTbU });
            if (result != default)
            {
                //RedirectToAction("BatchUpdateInvoke", ipDetailsTbU);
                //var t = Task.Run(() => _mediator.Send(new BatchUpdateIpDetailsProcessRequest { IpDetailsTbU = ipDetailsTbU }));
                return Ok($"Job Guid: {result}");
            }
            else
            {
                return BadRequest("something went wrong");
            }
        }




    }
}