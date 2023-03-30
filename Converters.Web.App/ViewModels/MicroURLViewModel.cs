using Converters.Domain;
using System.ComponentModel.DataAnnotations;

namespace Converters.Web.App.ViewModels;

public class MicroURLViewModel : BaseViewModel
{
    [Required(ErrorMessage = MessageConstants.URLRequiredErrorMessage)]
    [Url(ErrorMessage = MessageConstants.URLInvalidErrorMessage)]
    [Display(Name = "URL")]
    public string Input { get; set; } = string.Empty;

    [Display(Name = "Result")]
    public string Output { get; set; } = string.Empty;
}
