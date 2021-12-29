class EChartsHelper {
    constructor(options) {
        if (options == null) throw "invalid options";
        if (options.xAxis == null) throw "invalid options";
        if (options.yAxis == null) throw "invalid options";
        this.options = options;
    }

    set xAxisData(value) {
        this.options.xAxis.data = value;
    }

    set yAxisData(value) {
        this.options.yAxis.data = value;
    }

    getOptions() {
        return this.options;
    }
}

export function getInstance(options) {
    return new EChartsHelper(options);
}