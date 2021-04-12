using System;
using System.ComponentModel.DataAnnotations;
using Ciatecnica.Models;

namespace Ciatecnica.CustomValidation
{
	class TypeDataValidation : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			Client client = (Client)validationContext.ObjectInstance;

			if (client.Type != "Pessoa Física" && client.Type != "Pessoa Jurídica")
			{
				return new ValidationResult("O valor do tipo de cliente deve ser 'Pessoa Física' ou 'Pessoa Jurídica'");
			}
			else
			{
				return ValidationResult.Success;
			}
		}
	}
}
