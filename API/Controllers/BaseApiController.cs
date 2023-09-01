
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace API.Controllers
{
     [ApiController]
    [Route("api/nombre/[controller]")]
    public class BaseApiController
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public BaseApiController(IUnitOfWork unitOfWork, IMapper mapper)
        {
             _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
    }
}