using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IMarketDataFeed
    {
        string Stock { get; }
        event Action<MarketTick> Tick;
    }

    public interface IIndicator
    {
        event Action<double> IndicatorUpdated;
    }

    /// <summary>
    /// Calculate the average half spread (difference between mid and bid) 
    /// in percentage on a stream of market data updates
    /// </summary>
    public class AverageHalfSpreadIndicator : IIndicator
    {
        private List<MarketTick> _lastTicks;

        public AverageHalfSpreadIndicator(IMarketDataFeed marketDataFeed)
        {
            marketDataFeed.Tick += OnTick;
        }

        private void OnTick(MarketTick ticks)
        {
            _lastTicks.Add(ticks);
            if (_lastTicks.Count == 20)
            {
                _lastTicks.RemoveAt(0);
            }

            var start = DateTime.Now;
            var spreads = _lastTicks.Select(x => 100 * (x.Mid - x.Bid) / x.Bid);
            Console.WriteLine("Time (computing spreads): " + (DateTime.Now - start).TotalMilliseconds + " ms");

            var averageSpread = spreads.Average();
            Console.WriteLine("Time (total): " + (DateTime.Now - start).TotalMilliseconds + " ms");

            IndicatorUpdated(averageSpread);
        }

        public event Action<double> IndicatorUpdated;
    }

    public class MarketTick
    {
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double Last { get; set; }

        public double Mid
        {
            get { return (Bid + Ask) / 2; }
        }
    }
}
