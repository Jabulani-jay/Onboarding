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
        private WebDataAccess WebData = new();
        public WebContent()
        {
            WelomePageContent = WebData.GetDataSet("SELECT * FROM landing_page");
        }

        // 
    }
}
