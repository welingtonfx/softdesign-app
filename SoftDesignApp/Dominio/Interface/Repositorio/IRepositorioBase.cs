﻿using Dominio.Interface.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interface.Repositorio
{
    public interface IRepositorioBase<TDocument>
        where TDocument: IIdentifier
    {
        Task<IList<TDocument>> Get();
        Task<TDocument> GetById(string id);
        Task<TDocument> Insert(TDocument application);
        Task<TDocument> Update(string id, TDocument application);
        Task Remove(TDocument application);
        Task Remove(string id);
    }
}