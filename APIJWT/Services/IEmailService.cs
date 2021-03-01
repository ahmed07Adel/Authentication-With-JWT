using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Services
{
   public interface IEmailService
    {
        public bool SendEmail(string to, string subject, string body, bool isHtml, string displayNameFrom);

    }
}
