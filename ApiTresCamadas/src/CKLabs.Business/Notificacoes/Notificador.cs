using CKLabs.Business.Interfaces;

namespace CKLabs.Business.Notificacoes
{
    /// <summary>
    /// Classe que representa serviços de notificação
    /// </summary>
    public class Notificador : INotificador
    {
        /// <summary>
        /// Lista de notificações
        /// </summary>
        private List<Notificacao> _notificacoes;

        /// <summary>
        /// Construtor
        /// </summary>
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        /// <summary>
        /// Adiciona uma notificação à lista de notificações
        /// </summary>
        /// <param name="notificacao"></param>
        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        /// <summary>
        /// Obtem a lista de notificações
        /// </summary>
        /// <returns></returns>
        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        /// <summary>
        /// Verifica se existe alguma notificação
        /// </summary>
        /// <returns></returns>
        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
