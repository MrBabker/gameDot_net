
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var url = builder.Configuration["Supabase:Url"];
var key = builder.Configuration["Supabase:Key"];
// تسجيل Supabase Client في DI
builder.Services.AddSingleton(provider =>
{
    var client = new Client(url, key);
    client.InitializeAsync().Wait(); // مهم تهيئه
    return client;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
