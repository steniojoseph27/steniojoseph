using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolioProject.Core.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Responsabilities { get; set; } = string.Empty;
        public string TechnologiesUsed { get; set; } = string.Empty;
    }
}
