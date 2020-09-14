using Dominio.Interface.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interface.Infra.Repositorio
{
    public interface IRepositorioBase<TDocument>
        where TDocument: IIdentifier
    {
        Task<IEnumerable<TDocument>> Get();
        Task<TDocument> GetById(string id);
        Task<TDocument> Insert(TDocument application);
        Task<TDocument> Update(string id, TDocument application);
        Task Remove(TDocument application);
        Task Remove(string id);
    }
}
