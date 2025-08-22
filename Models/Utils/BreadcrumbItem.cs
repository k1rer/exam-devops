namespace ExamAspNet_WebMarket.Models.Utils
{
    public record BreadcrumbItem(
        string Text,
        string ControllerName,
        string ActionName
    );
}
