using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using Robson.Services.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robson.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    //[EnableCors("PolicyRobson")]
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
        public async Task<ActionResult<IEnumerable<PessoaViewModel>>> Get()
        {
            var pessoas = await _pessoaRepository.Todos();

            if (pessoas == null)
                return NoContent();

            var pessoaViewModel = _mapper.Map<IEnumerable<PessoaViewModel>>(pessoas).ToList();

            return Ok(pessoaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaViewModel>> Post(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);

            await _pessoaRepository.IncluirAsync(pessoa);

            return Ok(pessoaViewModel);
        }
    }
}
