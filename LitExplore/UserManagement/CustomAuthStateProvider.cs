using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace LitExplore.UserManagement
{
        public class CustomAuthStateProvider : AuthenticationStateProvider
        {
            string? name;

            public async Task<Boolean> isUserValidAsync(string _name){
                name = _name;
                var authState = await GetAuthenticationStateAsync();
                var user = authState.User;

                if(user.Identity != null && user.Identity.IsAuthenticated)
                    return true;

                return false;   
            }

            public override Task<AuthenticationState> GetAuthenticationStateAsync()
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, name),
                });

                var user = new ClaimsPrincipal(identity);

                return Task.FromResult(new AuthenticationState(user));
            }
    }   
}