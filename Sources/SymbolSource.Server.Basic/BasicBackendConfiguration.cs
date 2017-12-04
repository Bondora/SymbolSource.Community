using System;
using System.Web;

namespace SymbolSource.Server.Basic
{
    public class BasicBackendConfiguration : IBasicBackendConfiguration
    {
        public string DataPath
        {
            get { return GetPath("DataDir", "~/Data"); }
        }

        public string IndexPath
        {
            get { return GetPath("IndexDir", "~/Index"); }
        }

        public string RemotePath
        {
            get
            {
                return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/Data";
            }
        }

        private static string GetPath(string resource, string defaultPath)
        {
            var path = System.Configuration.ConfigurationManager.AppSettings.Get(resource) ?? defaultPath;
            return path.StartsWith("~/") ? HttpContext.Current.Server.MapPath(path) : path;
        }
    }
}