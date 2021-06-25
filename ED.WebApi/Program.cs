using System.Collections.Generic;
using System.Linq;
using ED.Domain.Model.Models.Entities;
using ED.Infra.Data.EntityConfiguration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ED.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var dataContext = new ApplicationDbContext())
            {
                if (ApplicationDbContext.isCreated)
                {
                    GenerateGenders(dataContext);
                    GenerateCategorys(dataContext);
                    GenerateAuthors(dataContext);
                }
            }

            BuildWebHost(args).Run();
        }

        private static void GenerateCategorys(ApplicationDbContext dataContext)
        {
            dataContext.Category.Add(new Category() { Name = "Autor" });
            dataContext.Category.Add(new Category() { Name = "Compositor" });
            dataContext.Category.Add(new Category() { Name = "Int�rprete" });
            dataContext.Category.Add(new Category() { Name = "M�sico" });
            dataContext.SaveChanges();
        }

        private static void GenerateGenders(ApplicationDbContext dataContext)
        {
            dataContext.Gender.Add(new Gender() { Name = "Samba" });
            dataContext.Gender.Add(new Gender() { Name = "Sertanejo" });
            dataContext.Gender.Add(new Gender() { Name = "Rock" });
            dataContext.Gender.Add(new Gender() { Name = "Pop" });
            dataContext.SaveChanges();
        }

        private static void GenerateAuthors(ApplicationDbContext dataContext)
        {
            var listAuthor = new List<string>();
            listAuthor.Add("Chiquinha Gonzaga");
            listAuthor.Add("Heitor Villa-Lobos");
            listAuthor.Add("Pixinguinha");
            listAuthor.Add("Ary Barroso");

            var categoryes = dataContext.Category.ToList();

            for (int i = 0; i < categoryes.Count; i++)
            {
                dataContext.Author.Add(new Author() { Name = listAuthor[i], Category = categoryes[i] });
            }

            dataContext.SaveChanges();
        }

        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder(args)               
                 .UseStartup<Startup>()
                 .UseIISIntegration()
                 .Build();


    }
}
