using System.Text.Json.Serialization;

namespace Finance.Domain
{
    public class Logo
    {
        #region Private
        private string idLogo;
        private string small;
        private string big;
        #endregion

        #region Public
        public string IdLogo
        {
            get => idLogo;
            set => idLogo = value;
        }

        [JsonPropertyName("small")]
        public string Small
        {
            get => small;
            set => small = value;
        }

        [JsonPropertyName("big")]
        public string Big
        {
            get => big;
            set => big = value;
        }
        #endregion
    }
}
