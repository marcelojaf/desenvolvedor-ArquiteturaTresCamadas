namespace CKLabs.Business.Notificacoes
{
    /// <summary>
    /// Classe que representa uma notificação
    /// </summary>
    public class Notificacao
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mensagem"></param>
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        /// <summary>
        /// Mensagem da notificação
        /// </summary>
        public string? Mensagem { get; }
    }
}
