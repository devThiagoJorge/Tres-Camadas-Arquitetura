using DevIo.Domain.Interfaces;

namespace DevIo.Domain.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacao;

        public Notificador() { 
            _notificacao = new List<Notificacao>();
        }    

        public bool TemNotificacao()
        {
            return _notificacao.Any();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacao;
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacao.Add(notificacao);
        }
    }
}
