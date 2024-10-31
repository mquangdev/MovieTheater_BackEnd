﻿namespace Application.Dtos.Authentication
{
    public class AuthResponseDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}