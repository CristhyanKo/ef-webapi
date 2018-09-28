namespace MyApi.Domain.Model
{
    public class Atividade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int SituacaoId { get; set; }
        public virtual Situacao Situacao { get; set; }
    }
}
