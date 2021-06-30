using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
namespace Onboarding.Datalayer
{
    public class WebContent
    {
        public DataSet WelomePageContent { get; set; }
        private DataAccess WebData = new();
        public WebContent()
        {
            WebData.SqlCmd = "SELECT * FROM landing_page";
            WebData.ConnectionString = @"Server=.;Database=Contentdb; trusted_Connection=True";
            WelomePageContent = WebData.GetDataSet();
        }

        // 
    }
}
