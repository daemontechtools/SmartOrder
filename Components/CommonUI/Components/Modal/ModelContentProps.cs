using Microsoft.AspNetCore.Components;
using Daemon.RazorUI.Icons;

namespace Daemon.RazorUI.Modal;

public struct ModalContentProps {
    public IconProps? IconProps { get; set; }
    public Type? IconType { get; set; }
    public string? IconBackgroundClass { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Func<bool, Task> OnConfirm { get; set; }
    public string? ButtonClass { get; set; }
}