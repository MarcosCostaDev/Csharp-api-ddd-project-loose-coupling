namespace api_baixo_acoplamento.Infra.Migrations
{
    using api_baixo_acoplamento.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<api_baixo_acoplamento.Infra.persistence.EntityFramework.dbContext.AplicacaoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(api_baixo_acoplamento.Infra.persistence.EntityFramework.dbContext.AplicacaoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.LogMessage.AddOrUpdate(p => p.Id,
                new LogMessage() { Application = "Aplicacao1", CurrentDate = DateTime.Now, message = "conectou agora", MessageType = "simples" },
                new LogMessage() { Application = "Aplicacao2", CurrentDate = DateTime.Now, message = "conectou agora", MessageType = "simples" },
                new LogMessage() { Application = "Aplicacao3", CurrentDate = DateTime.Now, message = "conectou agora", MessageType = "simples" },
                new LogMessage() { Application = "Aplicacao4", CurrentDate = DateTime.Now, message = "conectou agora", MessageType = "simples" }
                );

           
        }
    }
}
