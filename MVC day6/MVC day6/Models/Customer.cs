using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MVC_day6.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "you must enter a name ..")]
		[Display(Name = "Customer Name")]
		public string? Name { get; set; }

		[DataType(DataType.EmailAddress)]
		[Required]
		public string? Email { get; set; }

		[EnumDataType(typeof(Gender))]
		public Gender Gender { get; set; }

		[MinimumAge(18)]
		public int Age { get; set; }
		[PassWord]
		[DataType(DataType.Password)]
		public string? Password { get; set; }

		[DataType(DataType.PhoneNumber, ErrorMessage = "enter a valid phone number")]
		[Display(Name = "Phone Number")]
		[RegularExpression(@"^\+?\d{0,15}$", ErrorMessage = "Invalid phone number")]
		public string? PhoneNum { get; set; }

		public ICollection<Order>? Orders { get; set; }
	}

	public enum Gender
	{
		Male,
		Female
	}

	public class MinimumAge : ValidationAttribute
	{
		private readonly int _minimumAge;

		public MinimumAge(int minimumAge)
		{
			_minimumAge = minimumAge;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{


			if ((int)value >= _minimumAge)
			{
				return ValidationResult.Success!;
			}
			else
			{
				return new ValidationResult($"Minimum age required is {_minimumAge}.");
			}

		}


	}


	public class PassWord : ValidationAttribute
	{
		public PassWord()
		{

		}
		protected override ValidationResult IsValid(object value , ValidationContext context)
		{
			Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$");
			if (regex.IsMatch((string)value ?? string.Empty))
			{
				return ValidationResult.Success!;
			}
			else
			{
				return new ValidationResult($"password must be 8 characters or more and contains upper case , lower case , digits and special characters");
			}
		}
	}
}