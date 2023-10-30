using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    //    public IServiceProvider ServiceProvider { get; private set; }

    //    public IConfiguration Configuration { get; private set; }

    //    protected override void OnStartup(StartupEventArgs e)
    //    {
    //        var builder = new ConfigurationBuilder()
    //         .SetBasePath(Directory.GetCurrentDirectory())
    //         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    //        Configuration = builder.Build();

    //        var serviceCollection = new ServiceCollection();
    //        ConfigureServices(serviceCollection);

    //        ServiceProvider = serviceCollection.BuildServiceProvider();

    //        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
    //        mainWindow.Show();
    //    }

    //    private void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddDbContext<EventPlannerContext>
    //    (options => options.UseNpgsql(
    //                Configuration.GetConnectionString("Host=localhost;Port=5432;Username=postgres;Password=Yuiwerghjsdf21;Database=EventPlanner")));

    //        services.AddTransient(typeof(MainWindow));
    //    }
    }
}
