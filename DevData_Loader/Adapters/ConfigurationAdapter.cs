using DevData_Loader.Models;
using Newtonsoft.Json;
using System.IO;

namespace DevData_Loader.Adapters
{
    public class ConfigurationAdapter
    {
        public ConfigurationModel Config { get; set; }
        public void GetConfiguration(string configFilePath)
        {
            string configText = File.ReadAllText(configFilePath);
            Config = JsonConvert.DeserializeObject<ConfigurationModel>(configText);
        }
    }
}
