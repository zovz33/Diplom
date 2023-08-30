using PrimeTableware.WPF.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PrimeTableware.WPF.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string Username);
 
       // void UpdateUser(User changedUser);

        // List<User> GetAllStaff();
        // List<User> GetUsersByContaintsLetters(string letters);
        IEnumerable<UserModel> GetByAll();
        
    }
}
