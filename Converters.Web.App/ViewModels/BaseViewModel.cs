using Converters.Web.App.Abstractions.ViewModels;

namespace Converters.Web.App.ViewModels;

public abstract class BaseViewModel : IBaseViewModel
{
    public bool IsPostBack { get; set; } = false;
}
