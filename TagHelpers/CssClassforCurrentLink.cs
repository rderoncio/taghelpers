using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.CssClassforCurrentLink;

[HtmlTargetElement(tag: "a", Attributes = TargetAttributeName)]
public class CssClassforCurrentLink : TagHelper
{
    private const string TargetAttributeName = "asp-link-class";

    [ViewContext]
    public ViewContext? ViewContext { get; set; } 

    [HtmlAttributeName("class")]
    public string? Classes { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var action = context.AllAttributes["asp-action"].Value.ToString();
        var controller = context.AllAttributes["asp-controller"].Value.ToString();

        // <a class="nav-link" asp-controller="Home" asp-action="Index" asp-link-class="link-ativo">Principal</a>
        var tagHelperClasses = context.AllAttributes[TargetAttributeName].Value.ToString(); 
    
        var currentAction = ViewContext?.HttpContext.Request.RouteValues["action"]?.ToString();
        var currentController = ViewContext?.HttpContext.Request.RouteValues["controller"]?.ToString();

        if(action == currentAction && controller == currentController)
            Classes += $" {tagHelperClasses}";

        output.Attributes.Add("class", Classes); 
        output.Attributes.Remove(context.AllAttributes[TargetAttributeName]);
    }
}

