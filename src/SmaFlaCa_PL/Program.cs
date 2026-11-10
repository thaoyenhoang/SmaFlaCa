using SmaFlaCa_BLL.Interfaces;
using SmaFlaCa_BLL.Services;
using SmaFlaCa_DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
try
{
    var connectionString = builder.Configuration.GetConnectionString("FlashcardDB");
    builder.Services.AddScoped<IDeckRepository>(
    _ => new DeckRepository(connectionString));
    builder.Services.AddScoped<IDeckService, DeckService>();
    builder.Services.AddScoped<IFlashcardRepository>(
        _ => new FlashcardRepository(connectionString));
    builder.Services.AddScoped<IFlashcardService, FlashcardService>();  
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
