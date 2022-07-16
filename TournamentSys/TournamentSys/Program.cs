using Microsoft.AspNetCore.Authentication.Cookies;
using TournamentSysData.DTOs;
using TournamentSysLogic.Models.DTOs;
using TournamentSysLogic.Services.Interfaces;
using TournamentSysLogic.Services.MapperLogic;
using TournamentSysLogic.Services.TournamentLogic;
using TournamentSysLogic.Services.UserLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<ITournamentService, TournamentService>();


builder.Services.AddRazorPages();



builder.Services.AddTransient<IMaintanable<UserDto>, UserService>();
builder.Services.AddTransient<IMaintanable<PlayerDto>, PlayerService>();
builder.Services.AddTransient<IMapper, Mapper>();
builder.Services.AddTransient<IMaintanable<TournamentDto>, TournamentService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.UseRouting();


var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.None,
};

app.UseAuthorization();

app.MapRazorPages();

app.Run();
