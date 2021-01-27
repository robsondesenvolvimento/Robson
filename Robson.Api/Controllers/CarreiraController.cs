using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Robson.Api.Models.Result;
using Robson.Common;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Services.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Robson.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [EnableCors(ConstantVars.POLICY_NAME)]
    public class CarreiraController : ControllerBase
    {
        private readonly ILogger<CarreiraController> _logger;
        private readonly IMapper _mapper;
        private readonly ICarreiraRepository<Carreira> _carreiraRepository;

        public CarreiraController(ILogger<CarreiraController> logger, IMapper mapper, ICarreiraRepository<Carreira> carreiraRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _carreiraRepository = carreiraRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CarreiraViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<ActionResult<IEnumerable<CarreiraViewModel>>> GetAsync()
        {
            var carreiras = await _carreiraRepository.Todos();

            if (carreiras == null)
                return NotFound();

            var carreirasViewModel = _mapper.Map<IEnumerable<CarreiraViewModel>>(carreiras).ToList();

            return Ok(carreirasViewModel);
        }

        [HttpGet("{id?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarreiraViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<ActionResult<CarreiraViewModel>> GetIdAsync(int? id)
        {
            var carreira = await _carreiraRepository.PesquisarIdAsync((int)id);

            if (carreira == null)
                return NotFound();

            var carreiraViewModel = _mapper.Map<CarreiraViewModel>(carreira);

            return Ok(carreiraViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CarreiraViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<ActionResult<CarreiraViewModel>> PostAsync([FromBody] CarreiraViewModel carreiraViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carreira = _mapper.Map<Carreira>(carreiraViewModel);

            if (!await _carreiraRepository.IncluirAsync(carreira))
                return NoContent();

            var carreiraViewModelInsert = _mapper.Map<CarreiraViewModel>(carreira);

            return CreatedAtRoute("DefaultApi", new { id = carreira.Id }, carreiraViewModelInsert);
        }

        [HttpPut("{id?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarreiraViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<ActionResult<CarreiraViewModel>> PutAsync([FromRoute] int? id, [FromBody] CarreiraViewModel carreiraViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carreira = _mapper.Map<Carreira>(carreiraViewModel);

            if (!await _carreiraRepository.AlterarAsync(carreira))
                return BadRequest();

            var carreiraViewModelUpdate = _mapper.Map<CarreiraViewModel>(carreira);

            var uri = Url.RouteUrl("default", new { id = carreiraViewModelUpdate.Id });

            return Ok(carreiraViewModelUpdate);
        }

        [HttpDelete("{id?}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<IActionResult> DeleteAsync([FromRoute] int? id)
        {
            if (!await _carreiraRepository.ExcluirAsync((int)id))
                BadRequest();

            return NoContent();
        }
    }
}
