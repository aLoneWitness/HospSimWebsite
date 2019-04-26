namespace HospSimWebsite.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string errorInfo)
        {
            ErrorInformation = errorInfo;
        }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrorInformation { get; }
    }
}