namespace Application.Dtos.Authentication
{
    public class RefreshTokenResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}