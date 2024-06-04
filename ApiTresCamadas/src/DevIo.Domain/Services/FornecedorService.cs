using DevIo.Domain.Interfaces;
using DevIo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Domain.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Atualizar(fornecedor);
        }


        public async Task Remover(Guid id)
        {
            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}
