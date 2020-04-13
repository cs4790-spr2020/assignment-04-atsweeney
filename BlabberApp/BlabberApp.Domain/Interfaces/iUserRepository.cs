using System;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Domain.Interfaces
{
    public interface iUserRepository : iRepository<User>
    {
    }
}