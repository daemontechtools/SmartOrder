using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Daemon.RazorUI.Input;
public partial class DmnComboBox<T> : InputBase<T> {

    [Inject]
    private ILogger<DmnComboBox<T>>? _logger { get; set; }

    [Parameter]
    public IQueryable<T> Data { get; set; } = default!;
    public IQueryable<T> _filteredData { get; set; } = default!;

    [Parameter]
    public string? TextFieldName { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Class { get; set; }

    private string _searchValue = "";
    private bool _isActive = false;

    protected override void OnInitialized() {
        _filteredData = Data;
    }

    protected override bool TryParseValueFromString(
        string? value, 
        out T result, 
        out string validationErrorMessage) {
        throw new NotImplementedException();
    }

    public object GetPropertyValue(T obj, string propertyName) {
        if(obj == null) {
            throw new ArgumentNullException(nameof(obj));
        }
        var type = (obj as object).GetType();
        var propertyInfo = type.GetProperty(propertyName);
        if (propertyInfo == null) {
            throw new ArgumentException($"Property {propertyName} does not exist on type {type.FullName}");
        }

        return propertyInfo.GetValue(obj)
            ?? throw new Exception($"Property {propertyName} is null");
    }

    private string GetTextValue(T obj) {
        if(obj == null) throw new Exception("Can't get text value from null object");
        if(obj is string) return obj as string ?? "";
        if(TextFieldName == null) throw new Exception("If object is not string, TextFieldName must be set");
        return GetPropertyValue(obj, TextFieldName).ToString() ?? "";
    }

    // private string FormatValue(string value) {
    //     return Data
    //         .Where(x => x)
    //         .FirstOrDefault()?
    //         .Label;
    // }

    private void HandleInput(ChangeEventArgs e) {
        _searchValue = e.Value?.ToString() ?? "";
        if(String.IsNullOrEmpty(_searchValue)) {
            _filteredData = Data;
            return;
        }
        _filteredData = Data
            .Where(x => 
                GetTextValue(x)
                    .Contains(
                        _searchValue, 
                        StringComparison.OrdinalIgnoreCase
                    )
            );
    }

    private void HandleFocus(FocusEventArgs e) {
        _isActive = true;
    }

    private void HandleBlur(MouseEventArgs e) {
        if(Value is not null) {
            _searchValue = GetTextValue(Value);
        }
        _isActive = false;
    }

    private void OnOptionClick(T value) {
        
        Value = value;
        ValueChanged.InvokeAsync(value);
        _searchValue = GetTextValue(value);
        _isActive = false;
    }

}