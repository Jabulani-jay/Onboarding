using Onboarding.Datalayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public class LandingPageRepository : ILandingPage

    {
        // Retrieve data from data access
        private DataAccess dataAccess = new();

       public LandingPage landingPageContent()
        {
            DataSet  dataset = dataAccess.getLandingPageSet(); // data from dataset.
            LandingPage landingPageModel = null;

            foreach (DataTable table in dataset.Tables) // iterate tables
            {
                foreach (DataRow row in table.Rows) // iterate row
                {
                    landingPageModel =  new LandingPage()
                    {
                        ContentId = Convert.ToInt32(row[0]),
                        Heading = Convert.ToString(row[1]),
                        Description = Convert.ToString(row[2])
                    };

                }//end foreach row
            }

            return landingPageModel;
        }
    }
}
