using System.Collections.Generic;
using System.Linq;

namespace Kudu.SiteManagement
{
    public class Site
    {
        public Site()
        {
            SiteUrls = new List<string>();
        }
        public string ServiceUrl
        {
            get
            {
                return ServiceUrls.FirstOrDefault();
            }
        }
        public string SiteUrl
        {
            get
            {
                return SiteUrls.FirstOrDefault();
            }
        }
        public IList<string> SiteUrls { get; set; }

        IList<string> _serviceUrls = null;
        public IList<string> ServiceUrls
        {
            get
            {
                if (Constants.RunTestAgainstWindows)
#pragma warning disable CS0162 // Unreachable code detected
                    return _serviceUrls;
#pragma warning restore CS0162 // Unreachable code detected

                return new List<string> { "http://localhost:8181/" }; // 7397 and 8181
            }

            set
            {
                _serviceUrls = value;
            }
        }
    }
}