namespace SAST_Demo.Services
{
    public class HardcodedSecretsService
    {
        // ❌ SAST will flag
        private string apiKey = "HARDCODED_API_KEY_123";

        public string GetKey() => apiKey;
    }
}
