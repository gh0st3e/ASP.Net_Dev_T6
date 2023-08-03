using Lab8.Context;

namespace Lab8.Repository
{
    public class UserRepository: GenericRepository<User>
    {
        public UserRepository(UserContext context) : base(context)
        {
        }
    }
}
