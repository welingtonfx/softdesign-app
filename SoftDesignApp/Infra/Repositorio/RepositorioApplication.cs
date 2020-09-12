using Dominio.Interface.Infra;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioApplication : IRepositorioApplication
    {
        private readonly IMongoCollection<ApplicationModel> _application;

        public RepositorioApplication(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _application = database.GetCollection<ApplicationModel>(settings.ApplicationCollection);
        }

        public async Task<IList<ApplicationModel>> Get()
        {
            return await _application.Find(a => true).ToListAsync(); ;
        }


        public async Task<ApplicationModel> GetById(string id)
        {
            return await _application.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ApplicationModel> Insert(ApplicationModel application)
        {
            await _application.InsertOneAsync(application);
            return application;
        }

        public async Task Update(string id, ApplicationModel application)
        {
            await _application.ReplaceOneAsync(a => a.Id == id, application);
        }

        public async Task Remove(ApplicationModel application)
        {
            await _application.DeleteOneAsync(a => a.Id == application.Id);
        }

        public async Task Remove(string id)
        {
            await _application.DeleteOneAsync(a => a.Id == id);
        }
    }
}
