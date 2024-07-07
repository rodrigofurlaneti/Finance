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
            set => idLogo = value ?? throw new ArgumentNullException(nameof(IdLogo), "IdLogo cannot be null");
        }

        [JsonPropertyName("small")]
        public string Small
        {
            get => small;
            set => small = value ?? throw new ArgumentNullException(nameof(Small), "Small cannot be null");
        }

        [JsonPropertyName("big")]
        public string Big
        {
            get => big;
            set => big = value ?? throw new ArgumentNullException(nameof(Big), "Big cannot be null");
        }
        #endregion
    }
}
