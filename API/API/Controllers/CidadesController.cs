using API.Context;
using API.DTOs;
using API.Models;
using API.Pagination;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public CidadesController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }
                   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CidadeDTO>>> Get([FromQuery] CidadesParameters cidadesParameters)
        {
            try
            {
                var cidades = await _uof.CidadeRepository.GetCidades(cidadesParameters);

                var metadata = new
                {
                    cidades.TotalCount,
                    cidades.PageSize,
                    cidades.CurrentPage,
                    cidades.TotalPages,
                    cidades.HasNext,
                    cidades.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                var cidadesDTO = _mapper.Map<List<CidadeDTO>>(cidades);   

                if (cidades is null)
                {
                    return NotFound("Cidades não encontradas");
                }
                return cidadesDTO;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar solicitação");
                //return StatusCode(StatusCodes.Status500InternalServerError, ""ex.Message);
            }
        }

                
        [HttpGet("{id:int}", Name = "ObterCidade")]
        public async Task<ActionResult<CidadeDTO>> Get(int id)
        {
            try
            {
                var cidade = await _uof.CidadeRepository.GetById(p => p.CidadeId == id);

                if (cidade is null)
                {
                    return NotFound("Cidades não encontradas");
                }
                
                var cidadesDTO = _mapper.Map<CidadeDTO>(cidade);
                return cidadesDTO;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar solicitação");
                //return StatusCode(StatusCodes.Status500InternalServerError, ""ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CidadeDTO cidadeDto)
        {
            var cidade = _mapper.Map<Cidade>(cidadeDto);
            if (cidade is null)
            {
                return BadRequest();
            }

            _uof.CidadeRepository.Add(cidade);
            await _uof.Commit();

            var cidadeDTO = _mapper.Map<CidadeDTO>(cidade);

            return new CreatedAtRouteResult("ObterCidade", new { id = cidade.CidadeId }, cidadeDTO);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CidadeDTO cidadeDto)
        {
            if (id != cidadeDto.CidadeId)
            {
                return BadRequest();
            }

            var cidade = _mapper.Map<Cidade>(cidadeDto);

            _uof.CidadeRepository.Update(cidade);
            await _uof.Commit();

            return Ok(cidade);

        }      

    }
}
