
using Microsoft.AspNetCore.SignalR.Client;
using FluentAssertions;
using Microsoft.AspNetCore.SignalR;

namespace ApplicationTwoTest.Hub
{
	[Collection(nameof(SyncHubTestFixture))]
	public class SyncHubTest
    {
		private readonly SyncHubTestFixture _fixture;
		public SyncHubTest(SyncHubTestFixture fixture) => _fixture = fixture;

		[Fact]
		public async Task SendFromAppOneEnsureEchoedMessageIsSame()
		{
			var message = _fixture.GetValidateMessage();
			var echo = string.Empty;
			var connection = _fixture.GetHubConnectionBuilder();

			connection.On<string>("ReceiveFromAppOne", msg =>
			{
				echo = msg;
			});
			await connection.StartAsync();
			await connection.InvokeAsync("SendFromAppOne", message);

			await Task.Delay(1000);
			echo.Should().Be(message);
			await connection.StopAsync();
		}

		[Fact]
        public async Task SendFromAppTwoEnsureEchoedMessageIsSame()
        {
            var message = _fixture.GetValidateMessage();
            var echo = string.Empty;
            var connection = _fixture.GetHubConnectionBuilder();

            connection.On<string>("ReceiveFromAppTwo", msg =>
            {
                echo = msg;
            });
            await connection.StartAsync();
            await connection.InvokeAsync("SendFromAppTwo", message);
			await Task.Delay(1000);

			echo.Should().Be(message);
            await connection.StopAsync();
        }

		[Fact]
		public async Task SendFromAppTwo_NullMessage_ShouldThrowArgumentException()
		{
			// Arrange
			var connection = _fixture.GetHubConnectionBuilder();

			await connection.StartAsync();

			// Act & Assert
			Func<Task> act = async () => await connection.InvokeAsync("SendFromAppTwo", _fixture.GetNullMessage());
		
			await act.Should().ThrowAsync<HubException>().WithMessage("*Message should not be null*");
			await connection.StopAsync();
		}

		[Fact]
		public async Task SendFromAppTwo_MessageOver100Chars_ShouldThrowHubException()
		{
			var connection = _fixture.GetHubConnectionBuilder();
			var longMessage = _fixture.GetLongMessageInvalid();

			await connection.StartAsync();

			Func<Task> act = async () => await connection.InvokeAsync("SendFromAppTwo", longMessage);
			
			await act.Should().ThrowAsync<HubException>().WithMessage("*Message should be less or equal 300 characters long*");
			await connection.StopAsync();
		}



		[Fact]
		public async Task SendFromAppOne_NullMessage_ShouldThrowArgumentException()
		{
			// Arrange
			var connection = _fixture.GetHubConnectionBuilder();

			await connection.StartAsync();

			// Act & Assert
			Func<Task> act = async () => await connection.InvokeAsync("SendFromAppOne", _fixture.GetNullMessage());
		
			await act.Should().ThrowAsync<HubException>().WithMessage("*Message should not be null*");

			await connection.StopAsync();

			await connection.StopAsync();
		}

		[Fact]
		public async Task SendFromAppOne_MessageOver100Chars_ShouldThrowHubException()
		{
			var connection = _fixture.GetHubConnectionBuilder();
			await connection.StartAsync();

			Func<Task> act = async () => await connection.InvokeAsync("SendFromAppOne", _fixture.GetLongMessageInvalid());
			
			await act.Should().ThrowAsync<HubException>().WithMessage("*Message should be less or equal 300 characters long*");
			await connection.StopAsync();
		}

	}
}
