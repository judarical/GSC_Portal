using System.Collections.Generic;

namespace JSC_Portal.Models
{
    public class NavBarModel
    {
        // public string id { get; set; }

        public string Url { get; set; }

        public string Text { get; set; }

        public bool IsActive { get; set; }

        // public string DefaultClass { get; set; }

        public long Priority { get; set; }

        public List<NavBarModel> Children { get; set; }
    }
}
