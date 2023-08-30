using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using Microsoft.Data.SqlClient;
using PrimeTableware.WPF.Repositories.Interfaces;

namespace PrimeTableware.WPF.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        #region Все методы
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;
            try
            {
                using (var connection = GetConnection()) // объект подключения к базе данных с помощью метода GetConnection() из родительского класса RepositoryBase.
                using (var command = new SqlCommand()) //  объект команды SqlCommand для выполнения SQL-запросов к базе данных.
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select *from [UsersTable] where Login=@username COLLATE SQL_Latin1_General_CP1_CS_AS and [Password]=@password COLLATE SQL_Latin1_General_CP1_CS_AS"; // проверка на соответствие 
                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                    command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                    validUser = command.ExecuteScalar() != null;
                }
            }
            catch (Exception ex) // Обработка ошибок
            {
                throw new Exception("Ошибка аутентификации пользователя.", ex);
            }
            return validUser; // Успешная аунтификация
        }
        public void Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;


                command.CommandText = "INSERT INTO [UsersTable] (Login, Password, Mail, idRole, MobilePhone, Name, Surname, FName, Gender, Adress, HomePhone, DateOfBorn, ProfileImage) VALUES (@Login, @Password, @Mail, @idRole, @MobilePhone, @Name, @Surname, @FName, @Gender, @Adress, @HomePhone, @DateOfBorn, @ProfileImage)";
                command.Parameters.AddWithValue("@Login", userModel.Login);
                command.Parameters.AddWithValue("@Password", userModel.Password);
                command.Parameters.AddWithValue("@Mail", userModel.Mail);
                command.Parameters.AddWithValue("@idRole", userModel.idRole);
                command.Parameters.AddWithValue("@MobilePhone", userModel.MobilePhone);
                command.Parameters.AddWithValue("@Name", userModel.Name);
                command.Parameters.AddWithValue("@Surname", userModel.Surname);
                command.Parameters.AddWithValue("@FName", userModel.FName);
                command.Parameters.AddWithValue("@Gender", userModel.Gender);
                command.Parameters.AddWithValue("@Adress", userModel.Adress);
                command.Parameters.AddWithValue("@HomePhone", userModel.HomePhone);
                command.Parameters.AddWithValue("@DateOfBorn", userModel.DateOfBorn);
                command.Parameters.AddWithValue("@ProfileImage", userModel.ProfileImage);
                command.ExecuteNonQuery();
            }
        }
        public void Edit(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [UsersTable] SET Login=@Login, Password=@Password, Mail=@Mail, idRole=@idRole, MobilePhone=@MobilePhone, Name=@Name, Surname=@Surname, FName=@FName, Gender=@Gender, Adress=@Adress, HomePhone=@HomePhone, DateOfBorn=@DateOfBorn, ProfileImage=@ProfileImage WHERE idUser=@idUser";
                command.Parameters.AddWithValue("@Login", userModel.Login);
                command.Parameters.AddWithValue("@Password", userModel.Password);
                command.Parameters.AddWithValue("@Mail", userModel.Mail);
                command.Parameters.AddWithValue("@idRole", userModel.idRole);
                command.Parameters.AddWithValue("@MobilePhone", userModel.MobilePhone);
                command.Parameters.AddWithValue("@Name", userModel.Name);
                command.Parameters.AddWithValue("@Surname", userModel.Surname);
                command.Parameters.AddWithValue("@FName", userModel.FName);
                command.Parameters.AddWithValue("@Gender", userModel.Gender);
                command.Parameters.AddWithValue("@Adress", userModel.Adress);
                command.Parameters.AddWithValue("@HomePhone", userModel.HomePhone);
                command.Parameters.AddWithValue("@DateOfBorn", userModel.DateOfBorn);
                command.Parameters.AddWithValue("@DateAdd", userModel.DateAdd);
                command.Parameters.AddWithValue("@DateEdit", userModel.DateEdit);
                command.Parameters.AddWithValue("@ProfileImage", userModel.ProfileImage);
                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<UserModel> GetByAll()
        {
            List<UserModel> users = new List<UserModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [UsersTable]";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserModel user = new UserModel()
                        {
                            idUser = reader.GetInt32(0),
                            Login = reader[1].ToString(),
                            Password = string.Empty,
                            Mail = reader[3].ToString(),
                            idRole = reader.GetInt32(4),
                            MobilePhone = reader[5].ToString(),
                            Name = reader[6].ToString(),
                            Surname = reader[7].ToString(),
                            FName = reader[8].ToString(),
                            Gender = reader[9].ToString(),
                            Adress = reader[10].ToString(),
                            HomePhone = reader[11].ToString(),
                            DateOfBorn = reader.GetDateTime(12),
                            DateAdd = reader.GetDateTime(13),
                            DateEdit = reader.GetDateTime(14),
                            ProfileImage = reader[15].ToString(),
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
        public UserModel GetById(int id)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [UsersTable] WHERE idUser=@idUser";
                command.Parameters.AddWithValue("@idUser", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            idUser = reader.GetInt32(0),
                            Login = reader[1].ToString(),
                            Password = string.Empty,
                            Mail = reader[3].ToString(),
                            idRole = reader.GetInt32(4),
                            MobilePhone = reader[5].ToString(),
                            Name = reader[6].ToString(),
                            Surname = reader[7].ToString(),
                            FName = reader[8].ToString(),
                            Gender = reader[9].ToString(),
                            Adress = reader[10].ToString(),
                            HomePhone = reader[11].ToString(),
                            DateOfBorn = reader.GetDateTime(12),
                            DateAdd = reader.GetDateTime(13),
                            DateEdit = reader.GetDateTime(14),
                            ProfileImage = reader[15].ToString(),
                        };
                    }
                }
            }
            return user;
        }
        public void Remove(int id)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM [UsersTable] WHERE idUser=@idUser";
                    command.Parameters.AddWithValue("@idUser", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) // Обработка ошибок
            {
                throw new Exception("Ошибка при удалении пользователя.", ex);
            }
        }
        public UserModel GetByUsername(string username)
        {
            UserModel user=null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [UsersTable] where Login=@username COLLATE SQL_Latin1_General_CP1_CS_AS";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader()) 
                { 
                    if(reader.Read()) 
                    {
                        user = new UserModel()
                        {
                            idUser = reader.GetInt32(0),
                            Login = reader[1].ToString(),
                            Password = string.Empty,
                            Mail = reader[3].ToString(),
                            idRole = reader.GetInt32(4),
                            MobilePhone = reader[5].ToString(),
                            Name = reader[6].ToString(),
                            Surname = reader[7].ToString(),
                            FName = reader[8].ToString(),
                            Gender = reader[9].ToString(),
                            Adress = reader[10].ToString(),
                            HomePhone = reader[11].ToString(),
                            DateOfBorn = reader.GetDateTime(12),
                            DateAdd = reader.GetDateTime(13),
                            DateEdit = reader.GetDateTime(14),
                            ProfileImage = reader[15].ToString(),
                        };
                    }
                }
            }
            return user;
        }
        #endregion

    }
}
