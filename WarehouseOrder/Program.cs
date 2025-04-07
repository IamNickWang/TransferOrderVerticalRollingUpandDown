using WarehouseOrder.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using WarehouseOrder.Model;
using WarehouseOrder.Service;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContextFactory<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn"), sqlServerOptionsAction: SqlOperations =>
    {
        SqlOperations.EnableRetryOnFailure();
    })
    ;

});
builder.Services.AddTransient<ITransferOrder, TransferOrderService>();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
builder.Services.AddRazorComponents().AddInteractiveServerComponents()
            .AddCircuitOptions(options =>
            {
                options.DetailedErrors = true;
            });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}



app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

