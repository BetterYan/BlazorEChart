class EChartsHelper {
    constructor(options) {
        if (options == null) throw "invalid options";
        if (options.xAxis == null) throw "invalid options: xAxis";
        if (options.yAxis == null) throw "invalid options: yAxis";
        if (options.series == null) throw "invalid options: series";
        this.options = options;
    }

    setXAisData(value, index) {
        if (index == null) {
            this.options.xAxis.data = value;
        } else {
            this.options.xAxis[index].data = value;
        }
    }

    setYAxisData(value, index) {
        if (index == null) {
            this.options.yAxis.data = value
        }
        else {
            this.options.yAxis[index].data = value;
        }
    }

    setSeriesData(data, index) {
        let length = this.options.series.length;
        if (index > length - 1) {
            for (let i = length; i <= length; i++) {
                this.options.series[i] = Object.assign({}, this.options.series[0]);
                this.options.series[i].data = data;
            }
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