namespace E_Comm.Server.ModelDto
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; }
        public string errorMessage { get; set; }
        public object data { get; set; }

    }
}
