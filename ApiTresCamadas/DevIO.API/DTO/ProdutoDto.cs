﻿namespace DevIO.API.DTO
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public Guid FornecedorId { get; set; }
        public string? Nome { get; set; }

        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public string? NomeFornecedor { get; set; }
    }
}
