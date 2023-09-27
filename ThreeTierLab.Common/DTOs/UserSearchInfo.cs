namespace ThreeTierLab.DTOs
{
    public class UserSearchInfo
    {
        /// <summary>
        /// 使用者 Id 搜尋上限
        /// </summary>
        public int? UpperLimitId { get; set; }

        /// <summary>
        /// 使用者 Id 搜尋下限
        /// </summary>
        public int? LowerLimitId { get; set; }

        /// <summary>
        /// 使用者帳號關鍵字搜尋
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 使用者行動電話關鍵字搜尋
        /// </summary>
        public string? MobilePhone { get; set; }

        /// <summary>
        /// 使用者身分選項搜尋
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// 使用者信箱關鍵字搜尋
        /// </summary>
        public string? Email { get; set; }

    }
}
