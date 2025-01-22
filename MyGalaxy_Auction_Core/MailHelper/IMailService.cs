using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Core.MailHelper
{
    public interface IMailService
    {
        void SendEmail(string body,string  subject,string email);
    }
}
