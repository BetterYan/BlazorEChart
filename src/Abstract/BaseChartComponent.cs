using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Dynamic;

namespace BlazorECharts.Abstract;

public abstract class BaseChartComponent : ComponentBase, IAsyncDisposable
{
    #region Style
    [Parameter]
    public string Width { get; set; } = "100%";
    [Parameter]
    public string Height { get; set; } = "400px";
    #endregion

    #region JS interop
    [Inject]
    protected IJSRuntime JS { get; set; }
    protected ElementReference container;
    protected IJSObjectReference myChart { get; set; }
    protected IJSObjectReference chartHelper { get; set; }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeVoidAsync("import", "./_content/BlazorECharts/echarts.min.js");
            myChart = await JS.InvokeAsync<IJSObjectReference>("echarts.init", container);
            var module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorECharts/echarts-helper.js");
            var options = await LoadChartOptions();
            chartHelper = await module.InvokeAsync<IJSObjectReference>("getInstance", options);
        }
    }

    protected abstract Task<IJSObjectReference> LoadChartOptions();

    public async ValueTask DisposeAsync()
    {
        if (myChart != null)
        {
            await myChart.InvokeVoidAsync("dispose");
            await myChart.DisposeAsync();
        }
        if (chartHelper != null)
        {
            await chartHelper.DisposeAsync();
        }
    }

    public async Task Draw()
    {
        var options = await chartHelper.InvokeAsync<IJSObjectReference>("getOptions");
        await myChart.InvokeVoidAsync("setOption", options);
    }
}