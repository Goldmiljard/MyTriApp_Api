using MyTriApp.Services.DTOs;
using MyTriApp.Validators;

namespace MyTriApp.Data.Entities
{
    public class StravaAccessToken : Entity
    {
        public string TokenType { get; set; } = string.Empty;
        public int ExpiresAt { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public long AthleteId {  get; set; }
        public Guid UserId { get; set; } //required foreign key property
        public User User { get; set; } = null!; // required reference navigation to principal

        public static StravaAccessToken From(AccessTokenDTO dto, Guid userId)
        {
            dto.NotNull(nameof(dto));
            dto.token_type.NotNull(nameof(dto.token_type));
            dto.refresh_token.NotNull(nameof(dto.refresh_token));
            dto.access_token.NotNull(nameof(dto.access_token));

            return new StravaAccessToken
            {
                Id = dto.id,
                ExternalId = Guid.NewGuid(),
                TokenType = dto.token_type,
                ExpiresAt = dto.expires_at,
                ExpiresIn = dto.expires_in,
                RefreshToken = dto.refresh_token,
                AccessToken = dto.access_token,
                AthleteId = dto.athlete.id,
                UserId = userId
            };
        }
    }
}
