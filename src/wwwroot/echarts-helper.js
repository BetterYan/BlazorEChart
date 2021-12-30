class EChartsHelper {
    constructor(options) {
        if (options == null) throw "invalid options";
        if (options.xAxis == null) throw "invalid options: xAxis";
        if (options.yAxis == null) throw "invalid options: yAxis";
        if (options.series == null) throw "invalid options: series";
        this.options = options;
    }

    setXAisData(value) {
        this.options.xAxis.data = value;
    }

    setYAxisData(value) {
        this.options.yAxis.data = value;
    }

    setSeriesData(data, index) {
        if (this.options.series[index] == null) {
            throw "The index is out of range";
        }
        this.options.series[index].data = data;
    }

    getOptions() {
        return this.options;
    }
}

export function getInstance(options) {
    return new EChartsHelper(options);
}

export function onWindowResizeEvent(dotnetHelper, func_name) {
    window.addEventListener('resize', () => {
        dotnetHelper.invokeMethodAsync(func_name);
    });
}