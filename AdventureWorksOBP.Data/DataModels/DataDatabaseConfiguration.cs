using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksOBP.Data.DataModels
{
    public class DataDatabaseConfiguration : DataConfigurationBase
    {
        private string DataConnectionKey = "AdventureWorksOBPDataConnection";

        public string GetDataConnectionString()
            => GetConfiguration().GetConnectionString(DataConnectionKey);
    }
}
