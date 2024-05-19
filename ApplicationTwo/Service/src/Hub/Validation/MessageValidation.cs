
using Microsoft.AspNetCore.SignalR;

namespace Api.Validation
{
	public static class MessageValidation
	{
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
