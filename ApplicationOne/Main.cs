using Microsoft.AspNetCore.SignalR.Client;
using System.Configuration;

namespace ApplicationOne
{
	public partial class Main : Form
	{
		private HubConnection connection;
		public Main()
		{
			InitializeComponent();
			InitializeSignalR();
		}

		private void label_Input(object sender, EventArgs e)
		{

		}

		private void label_Output(object sender, EventArgs e)
		{

		}

		private void text_Output(object sender, EventArgs e)
		{

		}

		private void Main_Load(object sender, EventArgs e)
		{

		}

		private async void buttonSend_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textInput.Text))
			{
				errorProvider.SetError(textInput, "This field is required");
			}
			else
			{
				errorProvider.SetError(textInput, "");
				string message = textInput.Text;
				textInput.Text = string.Empty;
				await connection.InvokeAsync("SendFromAppOne", message);
			}
		}

		private async void InitializeSignalR()
		{
			// Retrieve the SignalR hub URL from the configuration file
			string hubUrl = ConfigurationManager.AppSettings["SignalRHubUrl"];

			// Build the connection to the SignalR Hub using the retrieved URL
			connection = new HubConnectionBuilder()
				.WithUrl(hubUrl)
				.Build();


			connection.On<string>("ReceiveFromAppTwo", (message) =>
			{
				DisplayMessage(message);
			});

			try
			{
				// Start the SignalR connection
				await connection.StartAsync();
				MessageBox.Show("Connected to SignalR Hub!");
			}
			catch (Exception ex)
			{
				// Display an error message if connection fails
				MessageBox.Show("Error connecting to SignalR Hub: " + ex.Message);
			}
		}

		// Função para exibir a mensagem na interface do usuário
		private void DisplayMessage(string message)
		{
			if (textOutput.InvokeRequired)
			{
				// If we are not on the main thread, invoke the function again on the main thread
				textOutput.Invoke(new Action(() => textOutput.Text = message));
			}
			else
			{
				// If we are already on the main thread, we can directly update the control
				textOutput.Text = message;
			}
		}

		private void textInput_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
