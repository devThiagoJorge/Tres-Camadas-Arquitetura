using AutoMapper;
using DevIO.API.DTO;
using DevIo.Domain.Interfaces;
using DevIo.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevIO.API.Controllers
{
    [Route("api/fornecedores")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorService fornecedorService,
            IFornecedorRepository fornecedorRepository,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _fornecedorService = fornecedorService;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorDto>>(await _fornecedorRepository.ObterTodos());
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorDto>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterFornecedoresProdutosEndereco(id);

            if (produtoViewModel == null)
                return NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorDto>> Adicionar(FornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorDto));

            return CustomResponse(HttpStatusCode.Created, fornecedorDto);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, FornecedorDto fornecedorDto)
        {
            if (id != fornecedorDto.Id)
            {
                NotificarErro("Os ids informados não são iguais.");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);


            await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorDto));
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorDto>> Excluir(Guid id)
        {
            var produto = await ObterFornecedoresProdutosEndereco(id);

            if (produto == null)
                return NotFound();

            await _fornecedorService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }


        private async Task<FornecedorDto> ObterFornecedoresProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorDto>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
    }
}
