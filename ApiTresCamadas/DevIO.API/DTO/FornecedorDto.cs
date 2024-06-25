namespace DevIO.API.DTO
{
    public class FornecedorDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public int TipoFornecedor { get; set; }
        public bool Ativo { get; set; }
        public EnderecoDto? Endereco { get; set; }
        public IEnumerable<ProdutoDto>? Produtos { get; set; }


    }
}
