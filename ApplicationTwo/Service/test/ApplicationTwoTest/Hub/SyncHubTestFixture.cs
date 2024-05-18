using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using ApplicationTwo;
using System.Data.Common;

namespace ApplicationTwoTest.Hub
{
	/// <summary>
	/// Fixture for setting up the SignalR SyncHub test environment.
	/// </summary>
	public class SyncHubTestFixture
	{
		/// <summary>
		/// Gets a predefined message for validation purposes in tests.
		/// </summary>
		/// <returns>A string message "Integration Testing in Microsoft AspNetCore SignalR".</returns>
		public string GetValidateMessage()
		{
			return "Integration Testing in Microsoft AspNetCore SignalR";
		}

		/// <summary>
		/// Gets a message that is invalid for validation purposes in tests.
		/// </summary>
		/// <returns>Return string with 301 characters</returns>
		public string GetLongMessageInvalid()
		{
			return new string('x', 301);
		}

		/// <summary>
		/// Gets a null message for validation purposes in tests.
		/// </summary>
		public string GetNullMessage()
		{
			return null;
		}

		/// <summary>
		/// Configures and returns a HubConnection for testing the SyncHub.
		/// </summary>
		/// <returns>An initialized HubConnection to the SyncHub.</returns>
		public HubConnection GetHubConnectionBuilder()
		{
			// Configure the test server
			var webHostBuilder = new WebHostBuilder()
				.ConfigureServices(services =>
				{
					services.AddSignalR();
				})
				.Configure(app =>
				{
					app.UseRouting();
					app.UseEndpoints(endpoints =>
					{
						endpoints.MapHub<SyncHub>("/synchub");
					});
				});

			var server = new TestServer(webHostBuilder);

			// Configure the client connection
			var connection = new HubConnectionBuilder()
				.WithUrl("http://localhost/synchub", options =>
				{
					options.HttpMessageHandlerFactory = _ => server.CreateHandler();
				})
			.Build();

			
			return connection;
		}
	}

	/// <summary>
	/// Collection definition for SyncHubTestFixture to enable shared context across multiple test classes.
	/// </summary>
	[CollectionDefinition(nameof(SyncHubTestFixture))]
	public class SyncHubTestFixtureFixtureCollection : ICollectionFixture<SyncHubTestFixture> { }
}
