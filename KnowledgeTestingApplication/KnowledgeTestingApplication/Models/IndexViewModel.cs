using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingApplication.Models
{
    public class IndexViewModel
    {
        public IEnumerable<IndexTestViewModel> Tests { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}