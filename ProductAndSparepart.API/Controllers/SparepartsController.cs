using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAndSparepart.Business.Abstract;
using ProductAndSparepart.Entity.Dto;

namespace ProductAndSparepart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SparepartsController : ControllerBase
    {
        private readonly ISparepartService _sparepartService;

        public SparepartsController(ISparepartService sparepartService)
        {
            _sparepartService = sparepartService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSparepartDto productDto)
        {
            return Ok(await _sparepartService.AddProductAndSparepart(productDto));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSparepartId(int id)
        {
            return Ok(await _sparepartService.GetProductAndSparepart(id));
        }
    }
}
