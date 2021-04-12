using System;
using System.ComponentModel.DataAnnotations;
using Ciatecnica.Models;

namespace Ciatecnica.CustomValidation
{
	class Min19Years : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			Client client = (Client)validationContext.ObjectInstance;
			if (client.Type == "Pessoa Física" && client.Birthday == null)
				return new ValidationResult("Data de aniversário é obrigatório");
			if (client.Type == "Pessoa Jurídica")
				return ValidationResult.Success;


			int age = DateTime.Today.Year - client.Birthday.Value.Year;

			return (age >= 19)
					? ValidationResult.Success
					: new ValidationResult("É necessário ser maior de 19 anos");
		}
	}
}
