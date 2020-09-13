using Dominio.Interface.Infra;
using Dominio.Interface.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Comum
{
    public class RepositorioBase<TDocument>
        where TDocument: IIdentifier
    {
        private readonly IMongoCollection<TDocument> _connection;

        public RepositorioBase(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _connection = database.GetCollection<TDocument>(settings.ApplicationCollection);
        }

        public async Task<IList<TDocument>> Get()
        {
            return await _connection.Find(a => true).ToListAsync();
        }


        public async Task<TDocument> GetById(string id)
        {
            return await _connection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TDocument> Insert(TDocument application)
        {
            await _connection.InsertOneAsync(application);
            return application;
        }

        public async Task<TDocument> Update(string id, TDocument application)
        {
            return await _connection.FindOneAndReplaceAsync(f => f.Id == application.Id, application);
        }

        public async Task Remove(TDocument application)
        {
            await _connection.DeleteOneAsync(a => a.Id == application.Id);
        }

        public async Task Remove(string id)
        {
            await _connection.DeleteOneAsync(a => a.Id == id);
        }
    }
}
