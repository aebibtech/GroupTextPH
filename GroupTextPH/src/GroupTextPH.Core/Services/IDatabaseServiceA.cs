using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GroupTextPH.Core.Models;

namespace GroupTextPH.Core.Services
{
    public interface IDatabaseServiceA
    {
        Task<List<Message>> GetMessagesAsync();
        Task<Message> GetMessageAsync(int id);
        Task<int> SaveMessageAsync(Message message);
        Task<int> DeleteMessageAsync(int id);
        Task<Settings> GetSettingsAsync();
        Task<int> SaveSettingsAsync(Settings settings);
    }
}
