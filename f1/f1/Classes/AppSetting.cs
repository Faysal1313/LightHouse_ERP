using System.Configuration;

namespace f1.Classes
{
  internal class AppSetting
  {
    private Configuration config;

    public AppSetting()
    {
      //base.\u002Ector();
      this.config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    }

    public string GetConnectionString(string key)
    {
      return this.config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
    }

    public void SaveConnectionString(string key, string value)
    {
      this.config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
      this.config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
      this.config.Save(ConfigurationSaveMode.Modified);
    }
  }
}
