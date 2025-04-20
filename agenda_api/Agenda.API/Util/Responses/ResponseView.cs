namespace Agenda.API.Util.Responses
{
    public class ResponseView
    {
        public ResponseView(string message, bool success, dynamic data)
        {
            Message = message;
            Success = success;
            Data = data;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }
    }
}