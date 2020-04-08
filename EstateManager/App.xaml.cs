
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


            //CreateSampleData();





        }



        //private void CreateSampleData()
        //{
        //    var pubDate = new DateTime();
        //    Random r = new Random();
        //    pubDate = DateTime.Now;
        //    if (r.Next(0, 3) == 0)
        //    {
        //        pubDate = DateTime.Now.AddYears(-1).AddDays(-5);
        //    }
        //    if (r.Next(0, 3) == 1)
        //    {
        //        pubDate = DateTime.Now.AddMonths(-1).AddDays(-5);
        //    }



        //}


        //private Models.Person GeneratePerson()
        //{
        //    string[] arrayNames = { "Jean", "Paule", "Pierre", "Jacqueline", "Michel", "David", "Léo", "Claudette", "Cloé", "Gertrude" };
        //    Random r = new Random();
        //    string firstName = arrayNames[r.Next(arrayNames.Length)];
        //    string lastName = arrayNames[r.Next(arrayNames.Length)];
        //    string cellPhone = "";
        //    string mail = firstName + "." + lastName + "@truc.fr";
        //    string Adress = r.Next(0, 200) + " rue du " + lastName;
        //    string ZipCode = "";
        //    string city = lastName + firstName;

        //    for (int j = 0; j < 5; j++)
        //    {
        //        ZipCode += r.Next(0, 10);
        //    }
        //    for (int j = 0; j < 10; j++)
        //    {
        //        cellPhone += r.Next(0, 10);
        //    }


        //    return new Models.Person()
        //    {
        //        FirstName = firstName,
        //        LastName = lastName,
        //        ZipCode = ZipCode,
        //        Address = Adress,
        //        City = city,
        //        CellPhone = cellPhone
        //    };


        //}
    }
}
