export function register_window_resize_event(dotnetHelper, func_name) {
    window.addEventListener('resize', () => {
        dotnetHelper.invokeMethodAsync(func_name);
    });

}