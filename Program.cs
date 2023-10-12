
using QuestPDF.Infrastructure;
using Sms.Host;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Container.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
if (app.Environment.IsDevelopment())
{
	
}

app.UseHttpsRedirection();
QuestPDF.Settings.License = LicenseType.Community;

ApiStudentCenter.ConfigureApi(app);
ApiFeeManagement.ConfigureApi(app);
ApiStaffManagement.ConfigureApi(app);
//app.MapControllers();
app.Run();
