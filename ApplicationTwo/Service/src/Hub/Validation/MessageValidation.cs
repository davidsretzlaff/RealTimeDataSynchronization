
using Microsoft.AspNetCore.SignalR;

namespace Api.Validation
{
	public static class MessageValidation
	{
		/// <summary>
		/// Validates a message to ensure it is not null and does not exceed the specified maximum length.
		/// </summary>
		/// <param name="message">The message to validate.</param>
		/// <param name="maxLength">The maximum length allowed for the message.</param>
		/// <returns>The validated message.</returns>
		/// <exception cref="HubException">Thrown when the message is null or exceeds the maximum length.</exception>
		public static string ValidateMessage(this string message, int maxLenght)
		{
			if (message is null)
			{
				throw new HubException($"Message should not be null");
			}

			if (message.Length > maxLenght)
			{
				throw new HubException($"Message should be less or equal {maxLenght} characters long");
			}

			return message;
		}
	}
}
