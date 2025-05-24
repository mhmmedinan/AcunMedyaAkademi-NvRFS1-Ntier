using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Requests.Brand;
using Business.Dtos.Responses.Brand;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        //[HttpPost]
        //public void Add([FromBody]Brand brand)
        //{
        //    _brandService.Add(brand);
        //}

        //[HttpGet]
        //public List<Brand> GetAll()
        //{
        //    return _brandService.GetAll();
        //}

        [HttpPost]
        public ActionResult<CreatedBrandResponse> Add([FromBody] CreateBrandRequest request)
        {
            return Created("", _brandService.Add(request));
        }

        [HttpGet]
        [Authorize(Roles = OperationClaims.Default)]
        public ActionResult<List<GetListBrandResponse>> GetAll()
        {
            return Ok(_brandService.GetList());
        }
    }
}
