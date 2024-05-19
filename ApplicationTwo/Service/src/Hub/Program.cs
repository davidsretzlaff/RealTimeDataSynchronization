using ApplicationTwo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("reactApp", builder =>
	{
		builder.WithOrigins("http://localhost:3000")
			.AllowCredentials()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

var app = builder.Build();

app.MapHub<SyncHub>("/synchub");

app.UseCors("reactApp");

app.Run();
