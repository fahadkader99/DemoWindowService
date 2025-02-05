namespace DemoWindowService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly MyLogic myLogic;

        public Worker(MyLogic myLogic, ILogger<Worker> logger)
        {
            this.myLogic = myLogic;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    myLogic.Logic();
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
