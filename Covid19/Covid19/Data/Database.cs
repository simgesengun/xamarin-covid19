using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public void DeleteUsersAsync()
        {
            _database.DropTableAsync<User>().Wait();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }
        public Task<User> GetUserAsync(string name, string password)
        {
            return _database.Table<User>().Where(f => (f.email == name || f.username == name) && f.password == password).FirstAsync();
        }
        public async Task<bool> userExistsAsync(string name, string password)
        {
            bool exists = (await _database.Table<User>().Where(f => (f.email == name || f.username == name) && f.password == password).CountAsync()) > 0;

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> emailAvailableAsync(string email)
        {
            bool exists = (await _database.Table<User>().Where(f => f.email == email).CountAsync()) > 0;

            if (exists)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<bool> usernameAvailableAsync(string username)
        {
            bool exists = (await _database.Table<User>().Where(f => f.username == username).CountAsync()) > 0;

            if (exists)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
