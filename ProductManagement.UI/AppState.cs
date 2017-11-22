using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.UI
{
    public class AppState
    {
        public DataStorageOption CurrentDataStorage { get; set; }
    }

    public enum DataStorageOption
    {
        Sql = 0,
        InMemory = 1
    }
}
