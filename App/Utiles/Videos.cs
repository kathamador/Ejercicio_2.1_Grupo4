using App.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Utiles
{

    public class Videos
    {
        readonly SQLiteAsyncConnection _connection;

        public Videos(string dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            _connection.CreateTableAsync<Video>().Wait();
        }

        public Task<int> Add(Video video)
        {
            if (video.Id == 0)
            {
                return _connection.InsertAsync(video);
            }
            else
            {
                return _connection.UpdateAsync(video);
            }
        }

        public Task<List<Video>> GetAll()
        {
            return _connection.Table<Video>().ToListAsync();
        }

        public Task<Video> GetById(int id)
        {
            return _connection.Table<Video>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

    }

}
