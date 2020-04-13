using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Interfaces
{
    public interface iUserPlugin : iPlugin
    {
        iEntity ReadByUserEmail(string email);
    }
}