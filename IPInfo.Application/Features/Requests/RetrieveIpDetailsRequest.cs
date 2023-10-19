using IPInfo.Application.Contracts;
using IPInfo.Application.Exceptions.ExternalServices;
using IPInfo.Domain.Entities.Persistence;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.Features.Requests
{
    public class RetrieveIpDetails : IRequest<IpDetails>
    {
        public string Ip { get; set; }
    }
    public class RetrieveIpDetailsHandler : IRequestHandler<RetrieveIpDetails, IpDetails>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RetrieveIpDetailsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IpDetails> Handle(RetrieveIpDetails request, CancellationToken cancellationToken)
        {
            
            if (_unitOfWork.cache.TryGetValue(request.Ip, out IpDetails ipDetails))
            {
                return ipDetails;
            }
            else if(await _unitOfWork.ipDetailsLocalRepository.Exists(searchTerm:request.Ip)) 
            {
                var details = await _unitOfWork.ipDetailsLocalRepository.GetSingleBySearchTermAsync(request.Ip);
                _unitOfWork.cache.Set(request.Ip, details,TimeSpan.FromMinutes(10));
                return details;
            }
            else {
                var detailsFromApi = await _unitOfWork.ipDetailsExternalRepository.GetDetailsAsync(searchTerm:request.Ip);
                if (detailsFromApi is null)
                {
                    throw new IPServiceNotAvailableException("Service not available.");
                }
                else
                {
                    var details = new IpDetails
                    {
                        Ip = detailsFromApi.Ip,
                        Id = Guid.NewGuid(),
                        City = detailsFromApi.City,
                        Country = detailsFromApi.Country,
                        Continent = detailsFromApi.Continent,
                        Longitude = detailsFromApi.Longitude,
                        Latitude = detailsFromApi.Latitude
                    };
                    var guid = await _unitOfWork.ipDetailsLocalRepository.CreateOneAsync(details);
                    details = await _unitOfWork.ipDetailsLocalRepository.GetByIdAsync(guid);
                    _unitOfWork.cache.Set(details.Ip, details);
                    return details;
                }
            }

        }
    }
}
