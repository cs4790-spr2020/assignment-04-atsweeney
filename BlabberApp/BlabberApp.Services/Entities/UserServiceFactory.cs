using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.DataStore.Plugins;

namespace BlabberApp.Services.Entities
{
    public class UserServiceFactory
    {
        //Methods
        public UserAdapter CreateUserAdapter(iUserPlugin plugin = null)
        {
            if(plugin == null)
            {
                plugin = this.CreateUserPlugin();
            }

            return new UserAdapter(plugin);
        }

        public iUserPlugin CreateUserPlugin(string type = "")
        {
            if(type.ToUpper().Equals("MYSQL"))
            {
                return new MySqlUser();
            }

            return new InMemory();
        }

        public UserService CreateUserService(UserAdapter adapter = null)
        {
            if(adapter == null)
            {
                adapter = this.CreateUserAdapter();
            }

            return new UserService(adapter);
        }
    }
}