using Core.Security.Entities;

namespace Business.Abstracts;

public interface IUserService
{
    User GetById(Guid id);
    User GetByEmail(string email);
    User Add(User user);
}
