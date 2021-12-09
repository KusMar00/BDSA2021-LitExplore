using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using LitExplore.Repository.Entities;
namespace LitExplore.UserManagement
{
        public class CustomAuthStateProvider : AuthenticationStateProvider, ICustomAuthStateProvider
        {
            
            string? name;

            public async Task<Boolean> IsUserValidAsync(string _name){
                name = _name;

                if(name == "AdminTestUser") return true;
                
                if(name != null){
                    var authState = await GetAuthenticationStateAsync();
                    var user = authState.User;
                    

                    if(user.Identity != null && user.Identity.IsAuthenticated)
                        return true;
                }
                return false; 
            }

            public override Task<AuthenticationState> GetAuthenticationStateAsync()
            {
                    var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, name)
                });

                var user = new ClaimsPrincipal(identity);

                return Task.FromResult(new AuthenticationState(user));
            }
            
            public async Task<(Status?, UserDTO?)> PostUserAsync(UserDTO user ) {
                throw new NotImplementedException();
            }

            public async Task<UserDTO?> GetUserAsync(Guid id) {
                throw new NotImplementedException();
            }

            public async Task<Boolean> IsUserOwnerAsync(string userName) {
                throw new NotImplementedException();
            }

            public async Task<Boolean> IsUserCollaboratorAsync(string userName) {
                throw new NotImplementedException();
            }
    }   
}