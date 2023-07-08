using TA.UserAccount.Repository;
using TA.UserAccount.RepositoryInterface;
using TA.UserAccount.Service;
using TA.UserAccount.ServiceInterface;

namespace TA.UserAccount
{
    public class Bootstrapper
    {
        public static void SetupRepositories(IServiceCollection services)
        {
            services.AddTransient<IJwtTokenManagerRepository, JwtTokenManagerRepository>();
            services.AddTransient<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddTransient<IUserMembershipRepository, UserMembershipRepository>();
            services.AddTransient<IUserInRoleRepository, UserInRoleRepository>();
            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
        }

        public static void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IUserMembershipService, UserMembershipService>();
            services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
        }
    }
}
