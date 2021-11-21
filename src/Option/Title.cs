namespace BlazorECharts;

// time consumed to map all the js options to C# class
// so, just ignore this folder
// we use .NET dynamic feature
public class Title
{
    /// <summary>
    /// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 是否显示标题组件。
    /// </summary>
    public bool Show { get; set; }
    /// <summary>
    /// 主标题文本，支持使用 \n 换行。
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// 主标题文本超链接。
    /// </summary>
    public string Link { get; set; }
    /// <summary>
    /// 指定窗口打开主标题超链接。
    /// 可选：
    /// 'self' 当前窗口打开
    /// 'blank' 新窗口打开 
    /// </summary>
    public string Target { get; set; } = "blank";
    /// <summary>
    /// 整体（包括 text 和 subtext）的水平对齐。
    /// 可选值：'auto'、'left'、'right'、'center'。
    /// </summary>
    public string TextAlign { get; set; } = "auto";
    /// <summary>
    /// 整体（包括 text 和 subtext）的垂直对齐。
    /// 可选值：'auto'、'top'、'bottom'、'middle'。
    /// </summary>
    public string TextVerticalAlign { get; set; } = "auto";
    /// <summary>
    /// 是否触发事件。
    /// </summary>
    public bool TriggerEvent { get; set; }
    /// <summary>
    /// number, Array
    /// 标题内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距。
    /// </summary>
    public object Padding { get; set; }
    /// <summary>
    /// 主副标题之间的间距。
    /// </summary>
    public int ItemGap { get; set; }
    /// <summary>
    /// 所有图形的 zlevel 值。
    /// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
    /// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
    /// </summary>
    public int Zlevel { get; set; }
    /// <summary>
    /// 组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
    /// z相比zlevel优先级更低，而且不会创建新的 Canvas。
    /// </summary>
    public int Z { get; set; }
    /// <summary>
    /// string, number
    /// title 组件离容器左侧的距离。
    /// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
    /// 如果 left 的值为'left', 'center', 'right'，组件会根据相应的位置自动对齐。
    /// </summary>
    public object Left { get; set; } = "auto";


    public class TextStyle
    {
        /// <summary>
        /// 主标题文字的颜色。
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 主标题文字字体的风格。
        /// 可选:
        /// 'normal'
        /// 'italic'
        /// 'oblique'
        /// </summary>
        public string FontStyle { get; set; } = "normal";
        /// </summary>
        /// string, number
        /// 主标题文字字体的粗细
        /// 可选:
        /// 'normal'
        /// 'bold'
        /// 'bolder'
        /// 'lighter'
        /// 100 | 200 | 300...
        /// </summary>
        public object FontWeight { get; set; } = "bolder";
        /// <summary>
        /// 主标题文字的字体系列。
        /// </summary>
        public string FontFamily { get; set; } = "sans-serif";
        /// <summary>
        /// 主标题文字的字体大小。
        /// </summary>
        public int FontSize { get; set; } = 18;
        /// <summary>
        /// 行高。
        /// </summary>
        public int LineHeight { get; set; }
        /// <summary>
        /// 文本显示宽度。
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 文本显示高度。
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 文字本身的描边颜色。
        /// </summary>
        public string TextBorderColor { get; set; }
        /// <summary>
        /// 文字本身的描边宽度。
        /// </summary>
        public int TextBorderWidth { get; set; }
        /// <summary>
        /// string, number, number array
        /// 文字本身的描边类型。
        /// string options: 'solid','dashed','dotted'
        /// </summary>
        public object TextBorderType { get; set; } = "solid";
        /// <summary>
        /// 用于设置虚线的偏移量，可搭配 textBorderType 指定 dash array 实现灵活的虚线效果。
        /// </summary>
        public int TextBorderDashOffset { get; set; }
        /// <summary>
        /// 文字本身的阴影颜色。
        /// </summary>
        public string TextShadowColor { get; set; } = "transparent";
        /// <summary>
        /// 文字本身的阴影长度。
        /// </summary>
        public int TextShadowBlur { get; set; }
        /// <summary>
        /// 文字本身的阴影 X 偏移。
        /// </summary>
        public int TextShadowOffsetX { get; set; }
        /// <summary>
        /// 文字本身的阴影 Y 偏移。
        /// </summary>
        public int TextShadowOffsetY { get; set; }
        /// <summary>
        /// 文字超出宽度是否截断或者换行。配置width时有效
        /// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
        /// 'break' 换行
        /// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
        /// </summary>
        public string Overflow { get; set; } = "none";
        /// <summary>
        /// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
        /// </summary>
        public string Ellipsis { get; set; } = "...";
        /// <summary>
        /// 文本超出高度部分是否截断，配置height时有效。
        /// 'truncate' 在文本行数超出高度部分截断。
        /// </summary>
        public string LineOverflow { get; set; } = "none";

    }
}