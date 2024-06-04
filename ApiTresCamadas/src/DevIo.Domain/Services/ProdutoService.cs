using DevIo.Domain.Interfaces;
using DevIo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Domain.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Adicionar(Produto fornecedor)
        {
            await _produtoRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Produto fornecedor)
        {
            await _produtoRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

    }
}
