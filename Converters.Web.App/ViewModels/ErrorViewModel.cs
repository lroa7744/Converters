
namespace Converters.Web.App.ViewModels;

public partial class ErrorViewModel : BaseViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrWhiteSpace(RequestId);
}
