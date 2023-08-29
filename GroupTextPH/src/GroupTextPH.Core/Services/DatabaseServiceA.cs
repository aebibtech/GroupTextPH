using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GroupTextPH.Core.Models;
using SQLite;

namespace GroupTextPH.Core.Services
{
    public class DatabaseServiceA : IDatabaseServiceA
    {
        private readonly SQLiteAsyncConnection _db;
        public DatabaseServiceA()
        {
            _db = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "grouptextph.db3"));
            _db.CreateTablesAsync<Message, Settings>().Wait();
        }

        public async Task<int> DeleteMessageAsync(int id)
        {
            Message msg = await GetMessageAsync(id);
            return await _db.DeleteAsync(msg);
        }
        public Task<Message> GetMessageAsync(int id)
        {
            return _db.Table<Message>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public Task<List<Message>> GetMessagesAsync()
        {
            return _db.Table<Message>().ToListAsync();
        }
        public Task<Settings> GetSettingsAsync() => throw new NotImplementedException();
        public Task<int> SaveMessageAsync(Message message)
        {
            if (message.Id != 0)
            {
                return _db.UpdateAsync(message);
            }

            return _db.InsertAsync(message);
        }
        public Task<int> SaveSettingsAsync(Settings settings) => throw new NotImplementedException();
    }
}
