using Api.Validation;
using Microsoft.AspNetCore.SignalR;

namespace ApplicationTwo
{
	/// <summary>
	/// Hub for synchronizing messages between Application 1 and Application 2.
	/// </summary>
	public class SyncHub : Hub
	{
		/// <summary>
		/// Sends a message from Application 1 to all instances of the application 2.
		/// </summary>
		/// <param name="message">The message to send from Application 1.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public async Task SendFromAppOne(string message)
		{
			message.ValidateMessage(300);
			await Clients.All.SendAsync("ReceiveFromAppOne", message);
		}

		/// <summary>
		/// Sends a message from Application 2 to all instances of the application 1.
		/// </summary>
		/// <param name="message">The message to send from Application 2.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public async Task SendFromAppTwo(string message)
		{
			message.ValidateMessage(300);
			await Clients.All.SendAsync("ReceiveFromAppTwo", message);
		}
	}
}
