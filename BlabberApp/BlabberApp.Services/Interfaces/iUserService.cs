using System.Collections;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services.Interfaces
{
    public interface iUserService
    {
        void AddNewUser(string email);

        User CreateUser(string email);

        User FindUser(string email);

        IEnumerable GetAll();
    }
}