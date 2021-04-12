using System;
using System.Collections.Generic;
using System.Linq;
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

			var find = await GetByCpfCnpj(entity.CpfCnpj);
			if (find == null)
			{
				_context.clients.Add(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			// TODO Should warn the user with some error
			return entity;
		}

		public async Task<Client> GetById(string id) => await _context.clients.FindAsync(id);
		public async Task<Client> GetByCpfCnpj(string cpfCnpj) => await _context.clients.Where(client => client.CpfCnpj == cpfCnpj).FirstOrDefaultAsync();
		public async Task<IEnumerable<Client>> GetAll() => await _context.clients.ToListAsync();
	}
}
