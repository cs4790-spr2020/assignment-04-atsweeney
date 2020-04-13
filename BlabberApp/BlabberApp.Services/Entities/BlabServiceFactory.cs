using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.DataStore.Plugins;

namespace BlabberApp.Services.Entities
{
    public class BlabServiceFactory
    {
        //Methods
        public BlabAdapter CreateBlabAdapter(iBlabPlugin plugin = null)
        {
            if(plugin == null)
            {
                plugin = this.CreateBlabPlugin();
            }

            return new BlabAdapter(plugin);
        }

        public iBlabPlugin CreateBlabPlugin(string type = "")
        {
            if(type.ToUpper().Equals("MYSQL"))
            {
                return new MySqlBlab();
            }

            return new InMemory();
        }

        public BlabService CreateBlabService(BlabAdapter adapter = null)
        {
            if(adapter == null)
            {
                adapter = this.CreateBlabAdapter();
            }

            return new BlabService(adapter);
        }
    }
}
