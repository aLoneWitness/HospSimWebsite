namespace HospSimWebsite.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        
        public string ErrorInformation { get; }

        public ErrorViewModel(string errorInfo)
        {
            ErrorInformation = errorInfo;
        }
    }
}