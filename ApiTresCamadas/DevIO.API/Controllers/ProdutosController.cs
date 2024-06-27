using AutoMapper;
using DevIo.Domain.Interfaces;
using DevIo.Domain.Models;
using DevIO.API.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevIO.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoService produtoService,
            IProdutoRepository produtoRepository,
            IMapper mapper, 
            INotificador notificador) : base(notificador)
        {
            _produtoService = produtoService;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoDto>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterProdutoPorId(id);

            if (produtoViewModel == null)
                return NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> Adicionar(ProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoDto));

            return CustomResponse(HttpStatusCode.Created, produtoDto);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoDto produtoDto)
        {
            if (id != produtoDto.Id)
            {
                NotificarErro("Os ids informados não são iguais.");
                return CustomResponse(HttpStatusCode.BadRequest);
            }

            var produtoAtualizacao = await ObterProdutoPorId(id);

            produtoAtualizacao.FornecedorId = produtoDto.FornecedorId;
            produtoAtualizacao.Nome = produtoDto.Nome;
            produtoAtualizacao.Descricao = produtoDto.Descricao;
            produtoAtualizacao.Valor = produtoDto.Valor;
            produtoAtualizacao.Ativo = produtoDto.Ativo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoDto>> Excluir(Guid id)
        {
            var produto = await ObterProdutoPorId(id);

            if (produto == null)
                return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }


        private async Task<ProdutoDto> ObterProdutoPorId(Guid id)
        {
            return _mapper.Map<ProdutoDto>(await _produtoRepository.ObterProdutoFornecedor(id));
        }
    }

}

