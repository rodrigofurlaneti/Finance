namespace Finance.Domain
{
    public class RecaptchaResponse
    {
        public bool Success { get; set; }
        public string Challenge_ts { get; set; }
        public string Hostname { get; set; }
        public float Score { get; set; }
        public string Action { get; set; }
    }
}
