using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWindowService
{
    public class MyLogic
    {
        private readonly ILogger<MyLogic> logger;

        public MyLogic(ILogger<MyLogic> logger)
        {
            this.logger = logger;
        }

        public void Logic()
        {
            logger.LogInformation("My Logic logging at: {time}", DateTimeOffset.Now);
        }

    }
}
