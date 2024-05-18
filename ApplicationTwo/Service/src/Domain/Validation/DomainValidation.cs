using Domain.Exceptions;
using System.Text;

namespace Domain.Validation
{
	public class DomainValidation
	{
		public static void NotNull(object? target, string fieldName)
		{
			if (target is null)
				throw new EntityValidationException($"{fieldName} should not be null");
		}

		public static void MaxLength(string target, int maxLength, string fieldName)
		{
			if (target.Length > maxLength)
			{
				throw new EntityValidationException($"{fieldName} should be less or equal {maxLength} characters long");
			}
		}
	}
}
