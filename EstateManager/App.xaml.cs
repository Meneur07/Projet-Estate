
using EstateManager.DataAccess;
using EstateManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EstateManager
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    /// 


    
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await EstateManagerContext.InitializeAsync();
            SampleDataCreator.createSampleDate();
        }
    }
}
