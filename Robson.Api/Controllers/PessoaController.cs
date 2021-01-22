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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors(ConstantVars.POLICY_NAME)]
    public class PessoaController : ControllerBase
    {

        private readonly ILogger<PessoaController> _logger;
        private readonly IMapper _mapper;
        private readonly IPessoaRepository<Pessoa> _pessoaRepository;

        public PessoaController(ILogger<PessoaController> logger, IMapper mapper, IPessoaRepository<Pessoa> pessoaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PessoaViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<ActionResult<IEnumerable<PessoaViewModel>>> GetAsync()
        {
            var pessoas = await _pessoaRepository.Todos();

            if (pessoas == null)
                return NotFound();

            var pessoasViewModel = _mapper.Map<IEnumerable<PessoaViewModel>>(pessoas).ToList();

            return Ok(pessoasViewModel);
        }

        [HttpGet("{id?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<ActionResult<PessoaViewModel>> GetIdAsync(int? id)
        {
            var pessoa = await _pessoaRepository.PesquisarIdAsync((int)id);

            if (pessoa == null)
                return NotFound();

            var pessoaViewModel = _mapper.Map<PessoaViewModel>(pessoa);

            return Ok(pessoaViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PessoaViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<ActionResult<PessoaViewModel>> PostAsync([FromBody] PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);

            if (!await _pessoaRepository.IncluirAsync(pessoa))
                return NoContent();

            var pessoaViewModelInsert = _mapper.Map<PessoaViewModel>(pessoa);

            return CreatedAtRoute("DefaultApi", new { id = pessoa.Id }, pessoaViewModelInsert);
        }

        [HttpPut("{id?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<ActionResult<PessoaViewModel>> PutAsync([FromRoute] int? id, [FromBody] PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);

            if (!await _pessoaRepository.AlterarAsync(pessoa))
                return BadRequest();

            var pessoaViewModelUpdate = _mapper.Map<PessoaViewModel>(pessoa);

            var uri = Url.RouteUrl("default", new { id = pessoaViewModelUpdate.Id });

            return Ok(pessoaViewModelUpdate);
        }

        [HttpDelete("{id?}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorException))]
        public async Task<IActionResult> DeleteAsync([FromRoute] int? id)
        {
            if (!await _pessoaRepository.ExcluirAsync((int)id))
                BadRequest();

            return NoContent();
        }
    }
}
