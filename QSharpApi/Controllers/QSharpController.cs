using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Quantum.Simulation.Simulators;
using HydrogenAtomSimulation;

namespace QSharpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QSharpController : ControllerBase
    {
        private readonly ILogger<QSharpController> _logger;

        public QSharpController(ILogger<QSharpController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QSharp>>> Get()
        {
            var rng = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new QSharp
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();

            foreach (var forecast in forecasts)
            {
                using var qsim = new QuantumSimulator();
                var energyLevel = await HydrogenAtomSimulation.EnergyLevel.Run(qsim, forecast.TemperatureC);
                forecast.QuantumEnergyLevel = energyLevel;
            }

            return Ok(forecasts);
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
