using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolioProject.Core.Entities
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }
}
