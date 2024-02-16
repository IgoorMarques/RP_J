using Entidades.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<AplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options)
        {
        }
        //Aqui vem todas as tabelas do banco de dados do projeto
        //ex: public DbSet<nomeTabela> nomeTabela { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=NBQSP-FC693;Initial Catalog=FINANCEIRO_2023;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            //return "Data Source=NBQSP-FC693;Initial Catalog=FINANCEIRO_2023;Integrated Security=True"; // Evitar
        }
    }
}
