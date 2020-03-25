using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EstateManager.ViewModels
{
    class StatViewModel
    {

        public StatViewModel()
        {

            var dbContext = DataAccess.EstateManagerContext.Current;

            int nbPostes = 0;



            nbPostes = dbContext.Transactions.Count();

            int nbPostsLastMonth = dbContext.Transactions.Where(t => t.PublicationDate > DateTime.Now.AddMonths(-1)).Count();

            int nbPostsLastYear = dbContext.Transactions.Where(t => t.PublicationDate > DateTime.Now.AddYears(-1)).Count();




        }


    }
}
