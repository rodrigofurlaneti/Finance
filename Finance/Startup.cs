using Finance.Data.Interface;
using Finance.Data.Repository;
using Finance.Service.Implementation;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Este método é chamado pelo runtime. Use este método para adicionar serviços ao contêiner.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        // Registro dos serviços de dados
        services.AddScoped<IAllStockExchangeData, AllStockExchangeData>();
        services.AddScoped<IBrazilianDepositaryReceiptsData, BrazilianDepositaryReceiptsData>();
        services.AddScoped<IRealEstateInvestmentFundData, RealEstateInvestmentFundData>();
        services.AddScoped<IStockExchangeData, StockExchangeData>();

        // Registro dos serviços
        services.AddScoped<IAllStockExchangeService, AllStockExchangeService>(); 
        services.AddScoped<IBrazilianDepositaryReceiptsService, BrazilianDepositaryReceiptsService>(); 
        services.AddScoped<ICalculationOfTheBarsiService, CalculationOfTheBarsiService>(); 
        services.AddScoped<IGrahamMethodologyService, GrahamMethodologyService>(); 
        services.AddScoped<IRealEstateInvestmentFundService, RealEstateInvestmentFundService>(); 
        services.AddScoped<IStockExchangeService, StockExchangeService>(); 

    }

    // Este método é chamado pelo runtime. Use este método para configurar o pipeline de solicitação HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // O valor padrão do HSTS é 30 dias. Pode ser alterado para cenários de produção, veja https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
