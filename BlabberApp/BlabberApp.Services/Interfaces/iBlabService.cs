using System.Collections;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services.Interfaces
{
    public interface iBlabService
    {
        void AddBlab(string message, string email);

        void AddBlab(Blab blab);

        Blab CreateBlab(string message, string email);

        Blab CreateBlab(string message, User user);

        IEnumerable FindUserBlabs(string email);

        IEnumerable GetAll();
    }
}