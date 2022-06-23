namespace Common.Dto
{
    internal class AppResultMessage
    {
        public AppResultMessage(string Message)
        {
            this.Message = Message;
        }

        public string Message { get; set; }
    }
}