namespace MvcApp
{
    public class Global
    {
        public static string SiteName {
            get {
                return Startup.Configuration.Get("site_name");
            }
        }
    }
}