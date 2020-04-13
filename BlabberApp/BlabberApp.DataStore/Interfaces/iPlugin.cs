using System;
using System.Collections;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Interfaces
{
    public interface iPlugin
    {
        void Create(iEntity obj);

        IEnumerable ReadAll();

        iEntity ReadById(Guid id);

        void Update(iEntity obj);
        
        void Delete(iEntity obj);
    }
}