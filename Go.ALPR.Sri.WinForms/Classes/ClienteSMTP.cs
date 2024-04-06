using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using Go.ALPR.Sri.Common;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;

namespace Go.ALPR.Sri.WinForms
{
    public class ClienteSMTP : IClienteSMTP
    {
        private readonly ILogger<ClienteSMTP> _logger;
        private readonly IConfiguration _config;

        SmtpClient _smtpClient;
        SmtpSettings _smtpSettings;

        private bool _conectado = false;

        public ClienteSMTP(ILogger<ClienteSMTP> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        ~ClienteSMTP()
        {
            _smtpClient.Dispose();
            _smtpClient = null;
        }

        //https://dotnetcoretutorials.com/2018/03/18/common-errors-sending-email-mailkit/

        public bool ComprobarConfiguracionSMTP()
        {

            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            try
            {
                _smtpSettings = _config.GetSection("Smtp").Get<SmtpSettings>();

                _smtpClient = new SmtpClient();
                
                _smtpClient.Connect(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.EnableSsl);
                _smtpClient.Authenticate(_smtpSettings.Username, _smtpSettings.Password);                    
                _smtpClient.Disconnect(true);
                
                _conectado = true;

                _logger.LogTrace($"{this.TraceMethod(new { })} - EMAIL OK");
            }
            catch(Exception ex)
            {
                var stmpConfig = _smtpSettings.ToString();
                _logger.LogError(ex, $"{this.TraceMethod(new { stmpConfig })} - ERROR AL COMPROBAR EMAIL");
                _conectado = false;
            }
            finally
            {
                if (_smtpClient.IsConnected)
                {
                    _smtpClient.Disconnect(true);
                }
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return _conectado;
        }


        public async Task<bool> EnviarAlbaran(string nombre, byte[] pdf, Dictionary<string, string> contactos)
        {

            if (!_conectado || contactos.Count == 0)
            {
                return true;
            }

            var listContactos = String.Join(";", contactos.Select(x => x.Key).ToArray());


            _logger.LogTrace($"{this.TraceMethod(new { nombre, listContactos })} - INICIO");
            
            bool result = false;

            try
            {
                var datosEmail = _config.GetSection("Email").Get<EmailDatos>();

                var mailMessage = new MimeMessage();
                                               
                mailMessage.Subject = datosEmail.Asunto;

                mailMessage.From.Add(new MailboxAddress(datosEmail.DesdeNombre, datosEmail.DesdeEmail));

                var builder = new BodyBuilder {
                    HtmlBody = datosEmail.CuerpoHTML
                };

                builder.Attachments.Add(nombre, pdf);
                mailMessage.Body = builder.ToMessageBody();

                foreach(KeyValuePair<string, string> contacto in contactos)
                {
                    mailMessage.Bcc.Add(new MailboxAddress(contacto.Value, contacto.Key));                    
                }

                await _smtpClient.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.EnableSsl);
                await _smtpClient.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                await _smtpClient.SendAsync(mailMessage);

                result = true;
            }
            catch (Exception ex)
            {
                               
                _logger.LogError(ex, $"{this.TraceMethod(new { nombre, listContactos })} - ERROR AL ENVIAR EMAIL");
            }
            finally
            {
                if (_smtpClient.IsConnected)
                {
                    await _smtpClient.DisconnectAsync(true);
                }
            }


            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;

        }

    }


    public interface IClienteSMTP
    {
        bool ComprobarConfiguracionSMTP();

        Task<bool> EnviarAlbaran(string nombre, byte[] pdf, Dictionary<string, string> contactos);

    }


}
