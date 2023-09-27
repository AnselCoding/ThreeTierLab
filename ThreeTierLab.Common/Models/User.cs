namespace ThreeTierLab.Common.Models
{
    public partial class User
    {
        /// <summary>
        /// 使用者 Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 使用者行動電話
        /// </summary>
        public string? MobilePhone { get; set; }

        /// <summary>
        /// 使用者身分
        /// </summary>
        public string Role { get; set; } = null!;

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// 使用者信箱
        /// </summary>
        public string? Email { get; set; }
    }
}
