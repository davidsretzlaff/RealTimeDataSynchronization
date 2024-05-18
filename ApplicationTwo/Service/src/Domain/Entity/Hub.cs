using Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
	public class Hub
	{
		public string Message { get; private set; }

		public void SetMessage(string message)
		{
			Validate();
			Message = message;
		}

		public void Validate()
		{
			DomainValidation.NotNull(Message, nameof(Message));
			DomainValidation.MaxLength(Message, 200, nameof(Message));
		}
	}
}
