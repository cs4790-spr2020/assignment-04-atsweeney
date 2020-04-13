using System.Collections;

namespace BlabberApp.DataStore.Interfaces
{
    public interface iBlabPlugin: iPlugin
    {
        IEnumerable ReadByUserId(string Id);
    }
}