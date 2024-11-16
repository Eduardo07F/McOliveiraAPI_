using McOliveiraAPI_.Data;
using Microsoft.EntityFrameworkCore;
using McOliveiraAPI_.Repositorio;
using McOliveiraAPI_.Repositorio.Interfaces;
using Entidades;

namespace McOliveiraAPI_
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            //Injecao de DBContext
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<MCDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            //

            //Injecao de dependecia dos repositorios (Toda vez que a interface for chamado, a classe que resolver instanciar sera a demarcada no tipo do escopo)
            builder.Services.AddScoped<IClienteRepositorio,ClienteRepositorio>();
            builder.Services.AddScoped<IFornecedorRepositorio,FornecedorRepositorio>();
            builder.Services.AddScoped<IProdutoRepositorio,ProdutosRepositorio>();
            builder.Services.AddScoped<IUserRepositorio,UserRepositorio>();
            builder.Services.AddScoped<IVendedorRepositorio,VendedorRepositorio>();
            builder.Services.AddScoped<IPedidoRepositorio,PedidoRepositorio>();
            builder.Services.AddScoped<IPedidoLinhaRepositorio,PedidoLinhaRepositorio>();
            builder.Services.AddScoped<ITipoPagamentoRepositorio,TipoPagamentoRepositorio>();
            //
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("corsapp");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}