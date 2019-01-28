using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JohnBryce
{
    public class UsersLogic : BaseLogic
    {
        public UserModel AddUser(UserModel userModel)
        {

            User user = new User
            {
                FullName = userModel.fullName,
                Username = userModel.username,
                Password = userModel.password,
                Email = userModel.email,
                BirthDate = userModel.birthDate
            };

            DB.Users.Add(user);
            DB.SaveChanges();

            userModel.id = user.UserID;
            return userModel;
        }

        //public UserModel Login(string username, string password)
        //{
        //    return DB.Users
        //        .Where(u => u.Username.ToLower() == username.ToLower() && u.Password.ToLower() == password.ToLower())
        //        .Select(u => new UserModel
        //        {
        //            id = u.UserID,
        //            fullName = u.FullName,
        //            username = u.Username,
        //            password = u.Password,
        //            email = u.Email,
        //            birthDate = u.BirthDate
        //        }).SingleOrDefault();
        //}

        public UserModel GetUserById(int id)
        {
            return DB.Users
                .Where(u => u.UserID == id)
                .Select(u => new UserModel
                {
                    id = u.UserID,
                    fullName = u.FullName,
                    password = u.Password,
                    email = u.Email,
                    birthDate = u.BirthDate
                }).SingleOrDefault();
        }

        public UserModel GetUserByUsernameAndPassword(string username, string password)
        {
            return DB.Users
                .Where(u => u.Username == username && u.Password == password)
                .Select(u => new UserModel
                {
                    id = u.UserID,
                    fullName = u.FullName,
                    password = u.Password,
                    email = u.Email,
                    birthDate = u.BirthDate
                }).SingleOrDefault();        
        }
    }
}
