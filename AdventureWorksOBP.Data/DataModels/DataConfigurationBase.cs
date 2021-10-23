using Microsoft.Extensions.Configuration;
using System;

namespace AdventureWorksOBP.Data.DataModels
{
    public abstract class DataConfigurationBase
    {
        protected IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("datasettings.json")
                .Build();
        }

        protected void RaiseValueNotFoundException(string configurationKey)
        {
            throw new Exception($"datasettings key ({configurationKey}) not found");
        }
    }
}
