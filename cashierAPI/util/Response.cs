namespace cashierAPI.src.util
{
    public class Response<Data>
    {
        public Response(List<Data> data)
        {
            this.data = data;
        }

        public List<Data>? data { get; set; }
        public int total => data?.Count ?? 0;
    }

    public class ResponseErr
    {
        public ResponseErr(String? message, String error){
            this.Message = message ?? "Internal Server rror";
            this.ExceptionType = error ?? "error";
        }

        public String? Message { get; set; }
        public String? ExceptionType { get; set; }

    }

    public class ResponseNotFound
    {
        public ResponseNotFound(string type, string title, int status, string traceId)
        {
            Type = type;
            Title = title;
            Status = status;
            TraceId = traceId;
        }

        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
    }
}


