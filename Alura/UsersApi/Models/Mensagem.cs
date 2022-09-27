using MimeKit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UsersApi.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatario, int usuarioId, string assunto, string codigo)
        {
            Destinatario = new List<MailboxAddress>(); 
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress("", d)));
            Assunto = assunto;
            Conteudo = $"https://localhost:44321/Ativacao?UsuarioId={usuarioId}&CodigoDeAtivacao={codigo}";
        }
    }
}
