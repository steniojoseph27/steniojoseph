using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolioProject.Core.Entities
{
    public class ShowcaseProject
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string GitHubLink { get; set; } = string.Empty;
        public string TechnologiesUsed { get; set; } = string.Empty;
    }
}
