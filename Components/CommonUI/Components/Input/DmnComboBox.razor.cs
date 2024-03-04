using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Daemon.RazorUI.Input;

public partial class DmnComboBox : InputBase<object> {

    [Inject]
    private ILogger<DmnComboBox> _logger { get; set; }

    [Parameter]
    public IQueryable<object> Data { get; set; }
    public IQueryable<object> _filteredData { get; set; }

    [Parameter]
    public string TextFieldName { get; set; }

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public string Class { get; set; }


    // [Parameter]
    // public Expression<Func<ValidationTValue>> ValidationValueExpression { get; set; }

    private string _searchValue = "";
    private bool _isActive = false;

    protected override void OnInitialized()
    {
        _filteredData = Data;
        //ValidationValueExpression ??= ValueExpression;
    }

    protected override bool TryParseValueFromString(
        string value, 
        out object result, 
        out string validationErrorMessage)
    {
        throw new NotImplementedException();
    }

    public object GetPropertyValue(object obj, string propertyName)
    {
        var type = obj.GetType();
        var propertyInfo = type.GetProperty(propertyName);
        if (propertyInfo == null)
        {
            throw new ArgumentException($"Property {propertyName} does not exist on type {type.FullName}");
        }

        return propertyInfo.GetValue(obj);
    }

    private string GetTextValue(object obj) {
        if(obj is string) return obj as string;
        return GetPropertyValue(obj, TextFieldName).ToString();
    }

    // private string FormatValue(string value) {
    //     return Data
    //         .Where(x => x)
    //         .FirstOrDefault()?
    //         .Label;
    // }

    private void HandleInput(ChangeEventArgs e) {
        _searchValue = e.Value.ToString();
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

    private void OnOptionClick(object value) {
        
        Value = value;
        ValueChanged.InvokeAsync(value);
        _searchValue = GetTextValue(value);
        _isActive = false;
    }

}