﻿namespace ThreeTierLab.Common.Models
{
    public partial class UserRefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RefreshToken { get; set; } = null!;
    }
}
