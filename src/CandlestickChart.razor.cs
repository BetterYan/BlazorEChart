using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECharts
{
    public partial class CandlestickChart : Abstract.BaseChartComponent
    {
        protected override async Task<IJSObjectReference> LoadChartOptions()
        {
            var module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorECharts/options/candlestick-chart-options.js");
            return await module.InvokeAsync<IJSObjectReference>("getOption");
        }

        private List<double> CalculateMA(int dayCount, double[] data)
        {
            var result = new List<double>();
            for (var i = 0; i < data.Length; i++)
            {
                if (i < dayCount)
                {
                    result.Add(double.NaN);
                    continue;
                }
                var sum = 0.0;
                for (var j = 0; j < dayCount; j++)
                {
                    sum += data[i - j];
                }
                result.Add(sum / dayCount);
            }
            return result;
        }
    }
}
