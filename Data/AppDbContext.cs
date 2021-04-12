using System;
using Ciatecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace Ciatecnica.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Client> clients { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Client>(client =>
			{
				client.HasIndex(c => c.CpfCnpj).IsUnique();
			});
		}
	}
}
