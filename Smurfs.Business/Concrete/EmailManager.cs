using Smurfs.Business.Abstract;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class EmailManager : IEmailService
    {
        public void SendMail(UserDto User)
        {
            MailMessage msg = new MailMessage(); //Mesaj gövdesini tanımlıyoruz...

            msg.Subject = "DZDTECH AİLESİNE HOŞGELDİN!";
            msg.From = new MailAddress("dzdsmurfs@outlook.com", "DZDTECH SMURFS EKİBİ");
            msg.To.Add(new MailAddress(User.Mail, $"{User.Name} {User.Surname}"));

            //Mesaj içeriğinde HTML karakterler yer alıyor ise aşağıdaki alan TRUE olarak gönderilmeli ki HTML olarak yorumlansın. Yoksa düz yazı olarak gönderilir...
            msg.IsBodyHtml = true;
            msg.Body = "<h2>Hey Dzd'li!</h2><br>Aramıza hoşgeldin!<br><br>" +
                "Programa mail adresin ile giriş yapabilirsin: " + User.Mail +
                "<br><br>İşte senin için oluşturulmuş şifre: " + User.Password +
                "<br><br>Unutma! şifreni istediğin zaman yenileyebilirsin!";

            //Mesaj önceliği (BELİRTMEK ZORUNLU DEĞİL!)
            msg.Priority = MailPriority.High;

            //SMTP/Gönderici bilgilerinin yer aldığı erişim/doğrulama bilgileri
            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
            NetworkCredential AccountInfo = new NetworkCredential("dzdsmurfs@outlook.com", "Dzd123456");
            smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true; //SSL kullanılarak mı gönderilsin...

            smtp.Send(msg);
        }
    }
}
