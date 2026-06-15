using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Services;

public interface IAuthService
{
    UserModel Authenticate(string username, string password);
}