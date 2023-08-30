using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace PrimeTableware.WPF.Repositories
{
    public class StaffRepository : RepositoryBase, IStaffRepository
    {
        #region Создание
        public void AddDepartment(DepartmentModel departmentModel) // создать отдел
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [DepartmentTable] (NameDepartment, DescriptionDepartment, DateAdd, DateEdit) VALUES (@NameDepartment, @DescriptionDepartment, @DateAdd, @DateEdit)";
                command.Parameters.AddWithValue("@NameDepartment", departmentModel.NameDepartment);
                command.Parameters.AddWithValue("@DescriptionDepartment", departmentModel.DescriptionDepartment);
                command.Parameters.AddWithValue("@DateAdd", departmentModel.DateAdd);
                command.Parameters.AddWithValue("@DateEdit", departmentModel.DateEdit);
                command.ExecuteNonQuery();
            }
        }
        public void AddPosition(PositionModel positionModel) // создать позицию
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [PositionTable] (NamePosition, Salary, MaxNumber, idDepartment, DescriptionPosition, DateAdd, DateEdit) VALUES (@NamePosition, @Salary, @MaxNumber, @idDepartment, @DescriptionPosition, @DateAdd, @DateEdit)";
                command.Parameters.AddWithValue("@NamePosition", positionModel.NamePosition);
                command.Parameters.AddWithValue("@Salary", positionModel.Salary);
                command.Parameters.AddWithValue("@MaxNumber", positionModel.MaxNumber);
                command.Parameters.AddWithValue("@DescriptionPosition", positionModel.DescriptionPosition);
                command.Parameters.AddWithValue("@idDepartment", positionModel.idDepartment);
                command.Parameters.AddWithValue("@DateAdd", positionModel.DateAdd);
                command.Parameters.AddWithValue("@DateEdit", positionModel.DateEdit);
                command.ExecuteNonQuery();
            }
        }
        public void AddStaff(StaffModel staffModel) // создать сотрудника
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [StaffTable] (idUser, idPosition, DateStarted, DateTerminated, DateAdd, DateEdit) VALUES (@idUser, @idPosition, @DateStarted, @DateTerminated, @DateAdd, @DateEdit)";
                command.Parameters.AddWithValue("@idUser", staffModel.idUser);
                command.Parameters.AddWithValue("@idPosition", staffModel.idPosition);
                command.Parameters.AddWithValue("@DateStarted", staffModel.DateStarted);
                command.Parameters.AddWithValue("@DateTerminated", staffModel.DateTerminated);
                command.Parameters.AddWithValue("@DateAdd", staffModel.DateAdd);
                command.Parameters.AddWithValue("@DateEdit", staffModel.DateEdit);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Удаление
        public void DeleteDepartment(DepartmentModel departmentModel) // удалить отдел
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM [DepartmentTable] WHERE idDepartment = @idDepartment";
                    command.Parameters.AddWithValue("@idDepartment", departmentModel.idDepartment);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) // Обработка ошибок
            {
              throw new Exception("Ошибка при удалении отдела.", ex);
            }
        }

        public void DeletePosition(PositionModel positionModel) // удалить позицию
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM [PositionTable] WHERE idPosition = @idPosition";
                    command.Parameters.AddWithValue("@idPosition", positionModel.idPosition);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) // Обработка ошибок
            {
                throw new Exception("Ошибка при удалении должности.", ex);
            }
        }

        public void DeleteStaff(StaffModel staffModel) // удалить сотрудника
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM [StaffTable] WHERE idEmployee = @idEmployee";
                    command.Parameters.AddWithValue("@idEmployee", staffModel.idEmployee);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) // Обработка ошибок
            {
                throw new Exception("Ошибка при удалении сотрудника.", ex);
            }
        }
        #endregion

        #region Редактирование

        public void EditDepartment(DepartmentModel departmentModel) // обновить отдел
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [DepartmentTable] SET NameDepartment = @NameDepartment, DescriptionDepartment = @DescriptionDepartment, DateEdit = @DateEdit WHERE idDepartment = @idDepartment";
                command.Parameters.AddWithValue("@idDepartment", departmentModel.idDepartment);
                command.Parameters.AddWithValue("@NameDepartment", departmentModel.NameDepartment);
                command.Parameters.AddWithValue("@DescriptionDepartment", departmentModel.DescriptionDepartment);
                command.Parameters.AddWithValue("@DateEdit", departmentModel.DateEdit);
                command.ExecuteNonQuery();
            }
        }

        public void EditPosition(PositionModel positionModel) // обновить позицию
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [PositionTable] SET NamePosition = @NamePosition, Salary = @Salary, MaxNumber = @MaxNumber, idDepartment = @idDepartment, DescriptionPosition = @DescriptionPosition, DateEdit = @DateEdit WHERE idPosition = @idPosition";
                command.Parameters.AddWithValue("@idPosition", positionModel.idPosition);
                command.Parameters.AddWithValue("@NamePosition", positionModel.NamePosition);
                command.Parameters.AddWithValue("@Salary", positionModel.Salary);
                command.Parameters.AddWithValue("@MaxNumber", positionModel.MaxNumber);
                command.Parameters.AddWithValue("@DescriptionPosition", positionModel.DescriptionPosition);
                command.Parameters.AddWithValue("@idDepartment", positionModel.idDepartment);
                command.Parameters.AddWithValue("@DateEdit", positionModel.DateEdit);
                command.ExecuteNonQuery();
            }
        }

        public void EditStaff(StaffModel staffModel) // обновить сотрудника
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [StaffTable] SET idUser = @idUser, idPosition = @idPosition, DateStarted = @DateStarted, DateTerminated = @DateTerminated, DateEdit = @DateEdit WHERE idEmployee = @idEmployee";
                command.Parameters.AddWithValue("@idEmployee", staffModel.idEmployee);
                command.Parameters.AddWithValue("@idUser", staffModel.idUser);
                command.Parameters.AddWithValue("@idPosition", staffModel.idPosition);
                command.Parameters.AddWithValue("@DateStarted", staffModel.DateStarted);
                command.Parameters.AddWithValue("@DateTerminated", staffModel.DateTerminated);
                command.Parameters.AddWithValue("@DateEdit", staffModel.DateEdit);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Получение всех отделов, должностей и сотрудников 

        public List<DepartmentModel> GetAllDepartments() // получить все отделы
        {
            var departments = new List<DepartmentModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [DepartmentTable]", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var department = new DepartmentModel
                        {
                            idDepartment = (int)reader["idDepartment"],
                            NameDepartment = (string)reader["NameDepartment"],
                            DescriptionDepartment = (string)reader["DescriptionDepartment"],
                            DateAdd = (DateTime)reader["DateAdd"],
                            DateEdit = (DateTime)reader["DateEdit"]
                        };

                        departments.Add(department);
                    }
                }
            }

            return departments;
        }

        public List<PositionModel> GetAllPositions() // получить все должности
        {
            var positions = new List<PositionModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [PositionTable]", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var position = new PositionModel
                        {
                            idPosition = (int)reader["idPosition"],
                            NamePosition = (string)reader["NamePosition"],
                            Salary = (decimal)reader["Salary"],
                            MaxNumber = (int)reader["MaxNumber"],
                            DescriptionPosition = (string)reader["DiscriptionPosition"],
                            idDepartment = (int)reader["idDepartment"],
                            DateAdd = (DateTime)reader["DateAdd"],
                            DateEdit = (DateTime)reader["DateEdit"]
                        };

                        positions.Add(position);
                    }
                }
            }

            return positions;
        }

        public List<StaffModel> GetAllStaff() // получить всех сотрудников
        {
            var employees = new List<StaffModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [StaffTable]", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new StaffModel
                        {
                            idEmployee = (int)reader["idEmployee"],
                            idUser = (int)reader["idUser"],
                            idPosition = (int)reader["idPosition"],
                            DateStarted = (DateTime)reader["DateStarted"],
                            DateTerminated = (DateTime)reader["DateTerminated"],
                            DateEdit = (DateTime)reader["DateEdit"]
                        };

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }
        #endregion

        #region Получение по ID
        
        public PositionModel GetPositionById(int idPosition) // получить должность по ID
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [PositionTable] WHERE idPosition = @idPosition", connection))
            {
                command.Parameters.AddWithValue("@idPosition", idPosition);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var position = new PositionModel
                        {
                            idPosition = (int)reader["idPosition"],
                            NamePosition = (string)reader["NamePosition"],
                            Salary = (decimal)reader["Salary"],
                            MaxNumber = (int)reader["MaxNumber"],
                            DescriptionPosition = (string)reader["DescriptionPosition"],
                            idDepartment = (int)reader["idDepartment"],
                            DateAdd = (DateTime)reader["DateAdd"],
                            DateEdit = (DateTime)reader["DateEdit"]
                        };

                        return position;
                    }
                }
            }

            return null;
        }

        public DepartmentModel GetDepartmentById(int idDepartment) // получить отдел по ID
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [DepartmentTable] WHERE idDepartment = @idDepartment", connection))
            {
                command.Parameters.AddWithValue("@idDepartment", idDepartment);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var department = new DepartmentModel
                        {
                            idDepartment = (int)reader["idDepartment"],
                            NameDepartment = (string)reader["NameDepartment"],
                            DescriptionDepartment = (string)reader["DescriptionDepartment"],
                            DateAdd = (DateTime)reader["DateAdd"],
                            DateEdit = (DateTime)reader["DateEdit"]
                        };

                        return department;
                    }
                }
            }

            return null;
        }

        public List<StaffModel> GetAllStaffByPositionId(int idPosition) // получить всех сотрудников по ID должности
        {
            var employees = new List<StaffModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [StaffTable] WHERE idPosition = @idPosition", connection))
            {
                command.Parameters.AddWithValue("@idPosition", idPosition);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new StaffModel
                        {
                            idEmployee = (int)reader["idEmployee"],
                            idUser = (int)reader["idUser"],
                            idPosition = (int)reader["idPosition"],
                            DateStarted = (DateTime)reader["DateStarted"],
                            DateTerminated = (DateTime)reader["DateTerminated"],
                            DateEdit = (DateTime)reader["DateEdit"]
                        };

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public List<PositionModel> GetAllPositionsByDepartmentId(int idDepartment) // получить все должности по ID отдела
        {
            var positions = new List<PositionModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [PositionTable] WHERE idDepartment = @idDepartment", connection))
            {
                command.Parameters.AddWithValue("@idDepartment", idDepartment);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var position = new PositionModel
                        {
                            idPosition = (int)reader["idPosition"],
                            NamePosition = (string)reader["NamePosition"],
                            Salary = (decimal)reader["Salary"],
                            MaxNumber = (int)reader["MaxNumber"],
                            DescriptionPosition = (string)reader["DescriptionPosition"],
                            idDepartment = (int)reader["idDepartment"],
                            DateAdd = (DateTime)reader["DateAdd"],
                            DateEdit = (DateTime)reader["DateEdit"]
                        };

                        positions.Add(position);
                    }
                }
            }

            return positions;
        }

        #endregion
    }
}