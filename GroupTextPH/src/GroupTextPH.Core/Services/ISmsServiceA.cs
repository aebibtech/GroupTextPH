using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroupTextPH.Core.Services
{
    public interface ISmsServiceA
    {
        Task<bool> SendSms(string message, string recipients);
        Task<bool> DeleteSms(int id);
    }
}
