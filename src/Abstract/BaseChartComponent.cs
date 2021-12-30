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
    protected DotNetObjectReference<BaseChartComponent> componentRef { get; set; }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            componentRef = DotNetObjectReference.Create(this);
            await JS.InvokeVoidAsync("import", "./_content/BlazorECharts/echarts.min.js");
            myChart = await JS.InvokeAsync<IJSObjectReference>("echarts.init", container);
            var module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorECharts/echarts-helper.js");
            await module.InvokeVoidAsync("onWindowResizeEvent", componentRef, "ChartResize");
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
        if (componentRef != null)
        {
            componentRef.Dispose();
        }
    }

    public async Task Draw()
    {
        var options = await chartHelper.InvokeAsync<IJSObjectReference>("getOptions");
        await myChart.InvokeVoidAsync("setOption", options);
    }

    public async Task SetXAxisData<T>(IEnumerable<T> data)
    {
        await chartHelper.InvokeVoidAsync("setXAisData", data);
    }

    public async Task SetYAxisData<T>(IEnumerable<T> data)
    {
        await chartHelper.InvokeVoidAsync("setYAisData", data);
    }

    public async Task SetSeriesData<T>(IEnumerable<T> data, int index)
    {
        await chartHelper.InvokeVoidAsync("setSeriesData", data, index);
    }

    [JSInvokable]
    public async Task ChartResize()
    {
        await myChart.InvokeVoidAsync("resize");
    }
}