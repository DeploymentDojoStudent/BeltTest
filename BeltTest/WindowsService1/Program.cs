using WindowsService1;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddWindowsService();
        services.AddHostedService<WindowsBackgroundService>();
    })
    .Build();

host.Run();
