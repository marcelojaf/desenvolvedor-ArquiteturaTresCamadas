namespace CKLabs.Business.Models
{
    /// <summary>
    /// Classe base para todos os modelos
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Identificador único do modelo
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Indica se o registro está ativo
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data de cadastro do registro
        /// </summary>
        public DateTime DataCadastro { get; set; }

    }
}
