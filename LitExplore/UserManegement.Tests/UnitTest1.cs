using Xunit;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using LitExplore.UserManagement;
using LitExplore.Repository;

namespace LitExplore.UserManegement.Tests
{
    public class UnitTest1 : IDisposable
    {
        [Fact]
        public void Test1()
        {

        } 
        [Fact]
        public void SampleTest()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Jordan")
            }));
        
            var context = new Database();

            
        }

        public void Dispose(){

        }
    }
}