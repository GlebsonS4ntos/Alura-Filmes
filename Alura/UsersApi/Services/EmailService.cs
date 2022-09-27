
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class EmailService
    {
        public IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string codigo)
        {
            Mensagem mensagem = new Mensagem(destinatario, usuarioId, assunto, codigo);
            MimeMessage mensagemDeEmail = CrinandoCorpoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var cliente = new SmtpClient())
            {
                try
                {
                    cliente.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    cliente.AuthenticationMechanisms.Remove("XOUATH2");
                    cliente.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    cliente.Send(mensagemDeEmail);
                }
                catch(Exception)
                {
                    throw;
                }
                finally
                {
                    cliente.Disconnect(true);
                    cliente.Dispose();
                }
            }
        }

        private MimeMessage CrinandoCorpoEmail(Mensagem mensagem)
        {
            MimeMessage mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("Email ?", _configuration.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemDeEmail;
        }
    }
}
