using ExamAspNet_WebMarket.Data;
using ExamAspNet_WebMarket.Services;
using ExamAspNet_WebMarket.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace ExamAspNet_WebMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                string? connectionString = builder.Configuration.GetConnectionString("Default");

                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new MissingFieldException("Failed to get Default connection string");

                options.UseSqlServer(connectionString);
            });

            builder.Services.AddSession();

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IAuthService,AuthService>();
            builder.Services.AddScoped<IProductService,ProductService>();
            builder.Services.AddScoped<IReviewService,ReviewService>();
            builder.Services.AddScoped<IUserService,UserService>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
