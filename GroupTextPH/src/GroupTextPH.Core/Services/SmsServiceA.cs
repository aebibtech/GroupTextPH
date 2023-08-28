using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GroupTextPH.Core.Services
{
    public class SmsServiceA : ISmsServiceA
    {
        public Task<bool> DeleteSms(int id) => throw new NotImplementedException();
        public async Task<bool> SendSms(string message, string recipients)
        {
            try
            {
                var recipientsArray = recipients.Split(',');
                foreach (var number in recipientsArray)
                {
                    var sms = new SmsMessage(message, number);
                    await Sms.ComposeAsync(sms);
                    await Task.Delay(2000);
                }
                return true;
            }
            catch (FeatureNotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
