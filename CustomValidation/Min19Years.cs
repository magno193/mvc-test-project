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

			if (client.Birthday == null)
				return new ValidationResult("Data de aniversário é obrigatório");

			int age = DateTime.Today.Year - client.Birthday.Value.Year;

			return (age >= 19)
					? ValidationResult.Success
					: new ValidationResult("É necessário ser maior de 19 anos");
		}
	}
}
