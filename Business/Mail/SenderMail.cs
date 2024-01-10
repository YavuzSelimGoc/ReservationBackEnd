using System;
using MailKit.Net.Smtp;
using MimeKit;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Business.Mail
{
	public class SenderMail
	{
      
       
        public void SenderMailContact(string mail,string message)
        {
            //Random random = new Random();
            //int code;
            //code = random.Next(100000, 1000000);
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("R E A S Y Rezervasyon Sistemi", "reasyrezervasyon@gmail.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
          //  bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
            bodyBuilder.TextBody = "Mesajınız Bize Başarıyla Ulaştı   Mesajınız:"+message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "R E A S Y  İletişim";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("reasyrezervasyon@gmail.com", "xgaytxxnesvmwknc");
            client.Send(mimeMessage);
            client.Disconnect(true);
           
        }
	
	}
}

