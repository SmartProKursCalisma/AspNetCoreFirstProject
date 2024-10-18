var builder = WebApplication.CreateBuilder(args);

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
    pattern: "{controller=Home}/{action=Parameters}/{id?}");
//baseUrl/{controller}/{action}/{id?} => PathParameter
//baseUrl/{controller}/{action}?{parameterName}={parameterValue} => QueryParameter (birden fazla parametre eklenecekse her parametreden sonra & ifadesi ile parametre sonlandýrýlmalý.)

app.Run();
