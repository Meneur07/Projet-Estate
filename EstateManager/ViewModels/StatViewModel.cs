using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace EstateManager.ViewModels
{
    class StatViewModel : BaseNotifyPropertyChanged
    {


        public SeriesCollection SeriesCol
        {
            get { return GetProperty<SeriesCollection>(); }
            set { SetProperty<SeriesCollection>(value); }
        }


        public String StatNbTrans
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
        }
        public String StatNbTransMonth
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
        }
        public String StatNbTransYear
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
        }

        public StatViewModel()
        {
            var dayConfig = Mappers.Xy<Models.DateModel>()
              .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromDays(1).Ticks)
              .Y(dayModel => dayModel.Value);

            var dbContext = DataAccess.EstateManagerContext.Current;

            int nbPostes = 0;
            List<Models.DateModel> dates = dbContext.Transactions.GroupBy(t=>t.PublicationDate.Date , t => t.Id).Select(x => new Models.DateModel { DateTime = x.Key, Value = x.Count()}).ToList();
            
            SeriesCol = new SeriesCollection(dayConfig)
{
                new LineSeries
                {
                    Values = new ChartValues<Models.DateModel>(dates)
                    
                   
                },
            };

            Formatter = value => new System.DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("D");
            nbPostes = dbContext.Transactions.Count();
            StatNbTrans = "TOTAL ESTATES : " + nbPostes;
            int nbPostsLastMonth = dbContext.Transactions.Where(t => t.PublicationDate < DateTime.Now.AddMonths(-1) && t.PublicationDate > DateTime.Now.AddMonths(-2)).Count();
            StatNbTransMonth = "ESTATES LAST MONTH : " + nbPostsLastMonth;
            int nbPostsLastYear = dbContext.Transactions.Where(t => t.PublicationDate < DateTime.Now.AddYears(-1) && t.PublicationDate > DateTime.Now.AddYears(-2)).Count();
            StatNbTransYear = "ESTATES LAST YEAR : " + nbPostsLastYear;



        }

        public Func<double, string> Formatter { get; set; }
    }
}
