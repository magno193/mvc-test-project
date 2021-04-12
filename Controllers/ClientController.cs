using System.Collections.Generic;
using System.Threading.Tasks;
using Ciatecnica.Models;
using Ciatecnica.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ciatecnica.Controllers
{
	public class ClientController : Controller
	{
		private readonly IClientService _clientService;

		public ClientController(IClientService clientService)
			=> _clientService = clientService;
		public async Task<IActionResult> Index()
		{
			IEnumerable<Client> clientList = await _clientService.GetAll();
			return View(clientList);
		}

		// GET - CREATE
		public IActionResult Create()
		{
			return View();
		}

		// POST - CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Client client)
		{
			if (ModelState.IsValid)
			{
				await _clientService.Create(client);
				return RedirectToAction("Index");
			}
			return View(client);
		}

	}
}
