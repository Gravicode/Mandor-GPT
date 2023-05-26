using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;
using Mandor.AI;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


Task.Run(async () =>
{
    while (true)
    {
        await Task.Delay(10000);
        await Master.Singleton.Tick();
        /*switch (Random.Shared.Next(0,6))
        {
            case 0:
                var a = Master.Singleton.Actions.AddAction("Thinking", LogAction.ThinkIcon);
                await Task.Delay(4000);
                a.Text = "testing text is cool and all but does the transition finally work of what? im quite tired of waiting for it to start working .. i would love to get to other things and stop obsesing about this.";
                break;
            case 1:
                Master.Singleton.Actions.AddAction("Creating a memory", LogAction.MemoryIcon);
                break;
            case 2:
                Master.Singleton.Actions.AddAction("Hello there");
                break;
            case 3:
                Master.Singleton.Notes.Add("Notes are cool and its cool i can show them!");
                break;
            case 4:
                Master.Singleton.Notes.Add("Notes are cool and its\ncool i can show them!");
                break;
            case 5:
                Master.Singleton.Notes.Add("Notes are cool and its cool i can show them! but what if they are looooong as fuck .. will the ui manage or will it breaky?");
                break;

        }*/



    }
}).ConfigureAwait(true);

app.Run();