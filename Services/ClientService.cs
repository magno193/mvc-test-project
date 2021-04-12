using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ciatecnica.Data;
using Ciatecnica.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Ciatecnica.Services
{
	public interface IClientService
	{
		Task<Client> Create(Client entity);
		Task<IEnumerable<Client>> GetAll();
		Task<Client> GetById(string id);
	}

	public class ClientService : IClientService
	{
		private readonly AppDbContext _context;
		public ClientService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Client> Create(Client entity)
		{
			string formatZip = entity.ZipCode.Replace("-", "");
			entity.ZipCode = formatZip;
			if (entity.Type == "Pessoa Física")
			{
				var age = DateTime.Today.Year - entity.Birthday.Value.Year;
				if (age < 19)
				{
				}
			}
			_context.clients.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<Client> GetById(string id) => await _context.clients.FindAsync(id);
		public async Task<IEnumerable<Client>> GetAll() => await _context.clients.ToListAsync();
	}
}
