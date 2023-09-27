using Nelibur.ObjectMapper;
using ThreeTierLab.Common.Models;
using ThreeTierLab.DTOs;

namespace ThreeTierLab.Mappings
{
    public class MapperConfig
    {
        public static void Register()
        {
            // 這個代碼告訴TinyMapper如何將Source類型的對象映射到Destination類型的對象。
            TinyMapper.Bind<UserParameter, User>(); // User 多一項 id
            TinyMapper.Bind<User, UserResultModel>(config =>
            {
                config.Ignore(x => x.Password);
            }); // UserResultModel 少一項 Password
        }
    }
}
