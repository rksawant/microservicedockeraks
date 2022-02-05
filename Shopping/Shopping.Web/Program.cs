var builder = WebApplication.CreateBuilder(args);



builder.Services.AddHttpClient("ShoppingAPIClient", client =>
{
    //client.BaseAddress = new Uri("https://localhost:7273/"); // Shopping.API url
    //client.BaseAddress = new Uri("http://host.docker.internal:49157/");
    client.BaseAddress = new Uri(builder.Configuration["ShoppingAPIUrl"]);
    //client.BaseAddress = new Uri("http://con-shoppingapi:80");
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
