namespace StylistPro.Produto.Domain.Interfaces.Dtos
{
    public interface IProdutoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        void Validate();
    }
}
