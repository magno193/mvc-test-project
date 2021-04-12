using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Ciatecnica.Models;

namespace Ciatecnica.CustomValidation
{
	public class CPFCNPJRegex : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			Client client = (Client)validationContext.ObjectInstance;

			if (client.Type == "Pessoa Física")
			{
				var match = Regex.Match(client.CpfCnpj, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
				return (match.Success)
					? ValidationResult.Success
					: new ValidationResult("Formato de CPF inválido");
			}
			else
			{
				var match = Regex.Match(client.CpfCnpj, @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$");
				return (match.Success)
					? ValidationResult.Success
					: new ValidationResult("Formato de CNPJ inválido");
			}

		}
	}
}
