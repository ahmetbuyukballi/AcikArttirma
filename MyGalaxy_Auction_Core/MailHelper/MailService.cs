using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MyGalaxy_Auction_Data_Access.Context;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Core.Models;


namespace MyGalaxy_Auction_Core.MailHelper
{
    public class MailService : IMailService
    {
        private readonly ApplicationDbContext _context;
        private readonly ApiResponse _response;
        public MailService(ApplicationDbContext context,ApiResponse apiResponse) 
        { 
            _context = context;
            _response = apiResponse;
        }    
        public void SendEmail(string body, string subject, string email)
        {
            try
            {
                var emailToSend = new MimeMessage();
                emailToSend.From.Add(MailboxAddress.Parse("ahmetbuyukballi@gmail.com"));
                emailToSend.To.Add(MailboxAddress.Parse(email));
                emailToSend.Subject = subject;
                emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

                using var emailClient = new SmtpClient();
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("ahmetbuyukballi@gmail.com", "zasfuvrxycidnpcw");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public async void ResetPasswordSendMail(string body,string subject,string email)
        {
            try
            {
                var user = await _context.ApplicationUser.FirstOrDefaultAsync(x => x.Email == email);
                if (user != null)
                {
                    var emailToSend = new MimeMessage();
                    emailToSend.From.Add(MailboxAddress.Parse("ahmetbuyukballi@gmail.com"));
                    emailToSend.To.Add(MailboxAddress.Parse(email));
                    emailToSend.Subject =subject;
                    emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

                    using var emailClient = new SmtpClient();
                    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    emailClient.Authenticate("ahmetbuyukballi@gmail.com", "zasfuvrxycidnpcw");
                    emailClient.Send(emailToSend);
                    emailClient.Disconnect(true);
                }
            }
            catch(Exception ex) 
            {
                throw ex; 
            
            }
           
         

        }
    }
}
