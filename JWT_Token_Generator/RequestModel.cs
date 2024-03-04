namespace JWT_Token_Generator
{
    public class CliamsModel
    {
       public string CliamType { get; set; }
        public string CliamValue { get; set; }
    }

    public class RequestModel
    {
        public RequestModel()
        {
            Cliams = new List<CliamsModel>();
        }
        public List<CliamsModel> Cliams { get; set; }
        public double TokenExpiresInHours { get; set; }
    }

    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime TokenExpriesAt { get; set; }
    }
}
