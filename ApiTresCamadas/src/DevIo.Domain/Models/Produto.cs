﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Domain.Models
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        // EF Relation
        public Fornecedor Fornecedor { get; set; }
    }
}
