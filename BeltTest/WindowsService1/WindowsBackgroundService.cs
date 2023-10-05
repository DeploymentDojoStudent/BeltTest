using Microsoft.Win32;
using System.Text;
using System.Timers;

namespace WindowsService1
{
    public class WindowsBackgroundService : BackgroundService
    {
        private readonly ILogger<WindowsBackgroundService> _logger;
        private readonly System.Timers.Timer _timer;

        private string _path;
        private int _count = 0;

        public WindowsBackgroundService(ILogger<WindowsBackgroundService> logger)
        {
            _logger = logger;
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            UpdateFile($"Running count: {++_count:000}");

        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            InitializePath();

            UpdateFile($"Start count: {_count}");
            _timer.Start();

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Stop();

            UpdateFile($"Stop count: {_count}");

            return base.StopAsync(cancellationToken);
        }

        private void UpdateFile(string text)
        {
            var bytes = Encoding.UTF8.GetBytes($"[{DateTime.Now:u}] {text}");

            for (var attempt = 0; attempt < 5; attempt++)
            {
                try
                {
                    using FileStream file = File.Open(_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                    file.Write(bytes, 0, bytes.Length);

                    break;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
        }
        private void InitializePath()
        {
            try
            {
                string path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFilePath", null) as string;

                _path = Path.GetFullPath((string)path!);
            }
            catch { }

            if (string.IsNullOrEmpty(_path))
            {
                _path = Path.Combine(AppContext.BaseDirectory, "WindowsService1.txt");
            }

            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }
    }
}