using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using Shipping.Serivec.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.EmailService
{
    public class EmailService:IEmailService
    {
        private readonly Email _email;

        public EmailService(IOptions<Email> email)
        {
            this._email = email.Value;
        }

        public async Task<string> SendEmailAsync(string Name, string Email, string token)
        {

            using var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                // Create an email message based on the provided authentication details
                var mailMessage = CreateEmailMessage(Name, Email, token);

                // Connect to the SMTP server using the configured settings
                await client.ConnectAsync(_email.SmtpServer, _email.Port, true);

                // Remove the XOAUTH2 authentication mechanism
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Authenticate with the SMTP server using the provided credentials
                await client.AuthenticateAsync(_email.Username, _email.Password);

                // Send the email message
                await client.SendAsync(mailMessage);

                // If the email is sent successfully, return "success"
                return "success";
            }
            catch (SmtpException ex)
            {
                // Return a meaningful error message
                return "An SMTP error occurred while sending an email. Please try again later.";
            }
            catch (Exception ex)
            {
                // Return a generic error message
                return "An error occurred while sending an email. Please try again later.";
            }
            finally
            {
                // Disconnect and dispose the client
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
        private MimeMessage CreateEmailMessage(string name, string email, string token)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
                throw new ArgumentException("Name, email, and token cannot be null or empty.");


            var link = $"{_email.PasswordResetLink}?email={email}&token={token}";
            var content = $@"
                <html>
                    <head>
                        <meta charset='utf-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Password Reset</title>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                background-color: #f4f4f4;
                                padding: 20px;
                            }}
                            h1 {{
                                color: #333;
                            }}
                            p {{
                                color: #555;
                            }}
                            a {{
                                color: #007BFF;
                                text-decoration: none;
                            }}
                            a:hover {{
                                text-decoration: underline;
                            }}
                        </style>    
                    </head>
                    <body>
                        <h1>Welcome to Our Service</h1>
                        <p>Dear {name},</p>
                        <p>Click the link below to reset your password:</p>
                        <a href='{link}'>Reset Password</a>
                    </body>
                </html>";
            // Create email message
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Shipping System", _email.From));
            mailMessage.To.Add(new MailboxAddress(name, email));
            mailMessage.Subject = "Reset Passord";
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = content };

            return mailMessage;
        }
    }
}
