
namespace Converters.Web.App.ViewModels;

public class ErrorViewModel : BaseViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrWhiteSpace(RequestId);
}
