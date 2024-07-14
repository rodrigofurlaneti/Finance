using Finance.Data.Interface;
using Finance.Data.Repository;
using Finance.Domain;
using Finance.Service.Implementation;
using Finance.Service.Interface;

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
        // Outros serviços configurados
        services.AddHttpClient();

        services.Configure<GoogleReCaptchaSettings>(Configuration.GetSection("GoogleReCaptcha"));

        // Adicione outros serviços necessários, como suporte para MVC
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
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
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
