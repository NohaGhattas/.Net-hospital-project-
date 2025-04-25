namespace HospitalManagementSystem.Presentation.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
