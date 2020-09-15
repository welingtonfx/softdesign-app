using Dominio.Interface.Infra;
using Dominio.Interface.Infra.Repositorio;
using Dominio.Model;
using Infra.Comum;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioApplication : DbContext, IRepositorioApplication
    {
        public RepositorioApplication(IRepositorioFactory repositorioFactory, IDatabaseSettings settings) : base(repositorioFactory, settings)
        {
        }

        public async Task<IEnumerable<ApplicationModel>> Get()
        {
            return await this.Applications.Find(f => true).ToListAsync();
        }

        public async Task<ApplicationModel> GetById(string id)
        {
            var retorno = await this.Applications.Find(f => f.Id == id).FirstOrDefaultAsync();

            if (retorno == null)
                throw new SoftDesignException() { StatusCode = System.Net.HttpStatusCode.NotFound };

            return retorno;
        }

        public ApplicationModel Insert(ApplicationModel application)
        {
            this.Applications.Insert(application);
            return application;
        }

        public void Remove(ApplicationModel application)
        {
            this.Applications.Remove(f => f.Id == application.Id);
        }

        public void Remove(string id)
        {
            this.Applications.Remove(f => f.Id == id);
        }

        public ApplicationModel Update(string id, ApplicationModel application)
        {
            this.Applications.FindOneAndReplaceAsync(f => f.Id == id, application);
            return application;
        }
    }
}
