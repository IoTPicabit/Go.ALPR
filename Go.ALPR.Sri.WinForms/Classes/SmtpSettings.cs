using System;
using System.Collections.Generic;
using System.Text;

namespace Go.ALPR.Sri.WinForms
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return String.Format("Host: {0}; Port: {1}; EnableSsl: {2}; UserName: {3}", Host, Port, EnableSsl.ToString(), Username);
        }
    }
}
