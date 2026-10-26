using System.Data;
using DTOResturant.Models.Models;
namespace ResturantWebService.ORM
{
    public class UserCreator : IModelCreator<User>
    {
        public User CreateModel(IDataReader dataReader)
        {
            User user = new User()
            {

            }
        }
    }
}
