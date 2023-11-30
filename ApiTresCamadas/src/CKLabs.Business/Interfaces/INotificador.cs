using CKLabs.Business.Notificacoes;

namespace CKLabs.Business.Interfaces
{
    /// <summary>
    /// Interface que implementa métodos de um serviço de notificação
    /// </summary>
    public interface INotificador
    {
        /// <summary>
        /// Verifica se existe alguma notificação
        /// </summary>
        /// <returns></returns>
        bool TemNotificacao();

        /// <summary>
        /// Obtem a lista de notificações
        /// </summary>
        /// <returns></returns>
        List<Notificacao> ObterNotificacoes();

        /// <summary>
        /// Manipula uma notificação
        /// </summary>
        /// <param name="notificacao"></param>
        void Handle(Notificacao notificacao);
    }
}
