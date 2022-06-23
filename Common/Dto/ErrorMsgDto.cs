using System.Net;

namespace Common.Dto
{
    public class ErrorMsgDto
    {
        public string BU { get; set; }
        public string Message { get; set; }
        public string PaymentId { get; set; }
        public HttpStatusCode? Status { get; set; }
    }

    public class Message
    {
        public string message { get; set; }
    }
}