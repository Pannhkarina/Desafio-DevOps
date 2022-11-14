using DesafioDevOps.Data;
using DesafioDevOps.Helper;
using DesafioDevOps.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace DesafioDevOps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer("Server=DESKTOP-7LI3NJJ;Database=DB_DESAFIO_DEVOPS;Trusted_Connection=True;"));
            
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddScoped<ISnippetRepositorio, SnippetRespositorio>();
            builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRespositorio>();
            builder.Services.AddScoped<IEmail, Email>();

            builder.Services.AddSession(o =>
            { 
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}