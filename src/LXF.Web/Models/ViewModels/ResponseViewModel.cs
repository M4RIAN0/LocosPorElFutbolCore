namespace LXF.Web.Models.ViewModels
{
    public class ResponseViewModel
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
