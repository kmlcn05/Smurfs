using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Abstract
{
    public interface IEmailService
    {
        public void SendMail(UserDto User);
        public void Notification(string icerik);
    }
}
