using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GroupTextPH.Core.Models;

namespace GroupTextPH.Core.Services
{
    public class DatabaseServiceA : IDatabaseServiceA
    {
        public Task<int> DeleteMessageAsync(int id) => throw new NotImplementedException();
        public Task<Message> GetMessageAsync(int id) => throw new NotImplementedException();
        public Task<List<Message>> GetMessagesAsync() => throw new NotImplementedException();
        public Task<Settings> GetSettingsAsync() => throw new NotImplementedException();
        public Task<int> SaveMessageAsync(Message message) => throw new NotImplementedException();
        public Task<int> SaveSettingsAsync(Settings settings) => throw new NotImplementedException();
    }
}
