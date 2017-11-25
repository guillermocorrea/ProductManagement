using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.UI.ViewComponents
{
    public class DataStorageSelectorComponent : ViewComponent
    {
        private AppSettings _appSettings;

        public DataStorageSelectorComponent(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() => View(new DataStorageViewModel() { DataStorage = _appSettings.CurrentDataStorage }));
        }
    }
}
