using Azure;
using Azure.Security.KeyVault.Secrets;

namespace MyTriApp.Secrets
{
    public class SecretsProvider
    {
        private readonly SecretClient _secretClient;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public SecretsProvider(SecretClient secretClient, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _secretClient = secretClient;
            _configuration = configuration;
            _environment = environment;
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            string secretValue = string.Empty;
            if (_environment.IsDevelopment())
            {
                secretValue = _configuration[secretName];
            }
            else
            {
                try
                {
                    KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);
                    secretValue = secret.Value;
                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        return secretValue;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return secretValue;
        }
    }
}
