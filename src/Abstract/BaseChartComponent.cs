using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Dynamic;

namespace BlazorECharts.Abstract;

public class BaseChartComponent : ComponentBase, IAsyncDisposable
{
    #region Style
    [Parameter]
    public string Width { get; set; } = "600px";
    [Parameter]
    public string Height { get; set; } = "400px";
    #endregion

    #region JS interop
    [Inject]
    protected IJSRuntime JS { get; set; }
    protected ElementReference container;
    protected IJSObjectReference myChart { get; set; }
    protected DotNetObjectReference<BaseChartComponent> componentRef { get; set; }
    #endregion

    #region Options
    [Parameter]
    public Dictionary<string, ExpandoObject> Option { get; set; } = new();

    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeVoidAsync("import", "./_content/BlazorECharts/echarts.min.js");
            myChart = await JS.InvokeAsync<IJSObjectReference>("echarts.init", container);
            componentRef = DotNetObjectReference.Create(this);
            await RegisterWindowResiveEvent();
        }
    }

    private async Task RegisterWindowResiveEvent()
    {
        var module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorECharts/helper.js");
        await module.InvokeVoidAsync("register_window_resize_event", componentRef, "ChartResize");
    }

    public async ValueTask DisposeAsync()
    {
        if (myChart != null)
        {
            await myChart.InvokeVoidAsync("dispose");
            await myChart.DisposeAsync();
            componentRef.Dispose();
        }
    }

    public async Task Draw()
    {
        await myChart.InvokeVoidAsync("setOption", Option);
    }

    [JSInvokable]
    public async Task ChartResize()
    {
        await myChart.InvokeVoidAsync("resize");
    }
}