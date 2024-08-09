
namespace MyPortfolioProject.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<Language> Languages { get; set; } = new List<Language>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<ShowcaseProject> ShowcaseProjects { get; set; } = new List<ShowcaseProject>();
    }
}