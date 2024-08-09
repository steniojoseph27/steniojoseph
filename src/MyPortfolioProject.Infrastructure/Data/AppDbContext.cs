using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.Core.Entities;

namespace MyPortfolioProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ShowcaseProject> ShowcaseProjects { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Availability> Availabilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for User entity
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                    FirstName = "Stenio",
                    LastName = "Joseph",
                    Email = "steniojosephs@gmail.com",
                    PhoneNumber = "(829) 673-4931",
                    Location = "Santiago, Dominican Republic",
                }
            );

            // Seed data for Experience entity
            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    Id = 1,
                    UserId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                    CompanyName = "Freelance",
                    Position = "Software Engineer",
                    StartDate = new DateTime(2022, 10, 1),
                    EndDate = DateTime.Now,
                    Responsabilities = "Develop and maintain .NET-based web APIs, facilitating robust enterprise systems integration.",
                    TechnologiesUsed = ".NET Core, C#, ASP.NET Core, MVC, WebAPI, Entity Framework, SQL Server, Azure Devops, and Azure Function App"
                }
            );

            // Seed data for Education entity
            modelBuilder.Entity<Education>().HasData(
                new Education
                {
                    Id = 1,
                    UserId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                    Degree = "Bachelors in Computer Information Systems",
                    Institution = "Universidad Dominicana O&M",
                    StartDate = new DateTime(2008, 5, 1),
                    EndDate = new DateTime(2013, 8, 1)
                }
            );

            // Seed data for Skill entity
            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = 1,
                    Name = ".NET Core",
                    ProficiencyLevel = "Advanced"
                },
                new Skill
                {
                    Id = 2,
                    Name = "C#",
                    ProficiencyLevel = "Advanced"
                },
                new Skill
                {
                    Id = 3,
                    Name = "ASP.NET Core",
                    ProficiencyLevel = "Advanced"
                },
                new Skill
                {
                    Id = 4,
                    Name = "SQL Server",
                    ProficiencyLevel = "Advanced"
                },
                new Skill
                {
                    Id = 5,
                    Name = "Azure",
                    ProficiencyLevel = "Advanced"
                },
                new Skill
                {
                    Id = 6,
                    Name = "RabbitMQ",
                    ProficiencyLevel = "Advanced"
                },
                new Skill
                {
                    Id = 7,
                    Name = "Entity Framework",
                    ProficiencyLevel = "Advanced"
                }
            );

            // Seed data for Language entity
            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    Name = "English",
                    ProficiencyLevel = "Fluent"
                },
                new Language
                {
                    Id = 2,
                    Name = "Spanish",
                    ProficiencyLevel = "Fluent"
                }
            );

            // Seed data for ShowcaseProject entity
            modelBuilder.Entity<ShowcaseProject>().HasData(
                new ShowcaseProject
                {
                    Id = 1,
                    UserId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                    ProjectName = "AI-driven procure-to-pay platform",
                    Description = "Enhanced an AI-driven procure-to-pay platform using .NET Core, RabbitMQ, Azure, and SQL Server.",
                    GitHubLink = "https://github.com/steniojoseph/project1"
                }
            );
        }
    }
}
