using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ciatecnica.CustomValidation;

namespace Ciatecnica.Models
{
	public class Client
	{
		[Key]
		public int Id { get; set; }
		[Column(TypeName = "varchar(24)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string Type { get; set; }
		[Column(TypeName = "varchar(14)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string CpfCnpj { get; set; }
		[Column(TypeName = "varchar(200)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string NameCorporateName { get; set; }
		[Column(TypeName = "varchar(15)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string SurnameTradeName { get; set; }
		[Column(TypeName = "date")]
		[Required(ErrorMessage = "Campo obrigatório")]
		[Min19Years]
		public DateTime? Birthday { get; set; }
		[Column(TypeName = "varchar(8)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string ZipCode { get; set; }
		[Column(TypeName = "varchar(100)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string City { get; set; }
		[Column(TypeName = "char(2)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string State { get; set; }
		[Column(TypeName = "varchar(200)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string Address { get; set; }
		[Column(TypeName = "smallint")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public int? AddressNumber { get; set; }
		[Column(TypeName = "varchar(100)")]
		[DisplayName("Complemento")]
		public string AddressComplement { get; set; }
		[Column(TypeName = "varchar(100)")]
		[Required(ErrorMessage = "Campo obrigatório")]
		public string District { get; set; }
	}
}
