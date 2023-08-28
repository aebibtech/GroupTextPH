using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;

namespace GroupTextPH.Core.Services
{
    public class SmsServiceA : ISmsServiceA
    {
        public Task<bool> DeleteSms(int id) => throw new NotImplementedException();
        public async Task<bool> SendSms(string message, string recipients)
        {
            try
            {
                if (string.IsNullOrEmpty(recipients) || string.IsNullOrEmpty(message))
                {
                    return false;
                }

                var recipientsArray = recipients.Split(',');

                if (CrossMessaging.Current.SmsMessenger.CanSendSmsInBackground)
                {
                    foreach (var recipient in recipientsArray)
                    {
                        CrossMessaging.Current.SmsMessenger.SendSmsInBackground(recipient, message);
                        await Task.Delay(3000);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
