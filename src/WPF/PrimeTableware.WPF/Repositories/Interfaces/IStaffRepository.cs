using PrimeTableware.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTableware.WPF.Repositories.Interfaces
{
    public interface IStaffRepository
    {
        void AddDepartment(DepartmentModel departmentModel);
        void AddPosition(PositionModel positionModel);
        void AddStaff(StaffModel staffModel);

        void DeleteDepartment(DepartmentModel departmentModel);
        void DeletePosition(PositionModel positionModel);
        void DeleteStaff(StaffModel staffModel);

        void EditDepartment(DepartmentModel departmentMode);
        void EditPosition(PositionModel positionModeL);
        void EditStaff(StaffModel staffModel);

        List<DepartmentModel> GetAllDepartments();
        List<PositionModel> GetAllPositions();
        List<StaffModel> GetAllStaff();

        PositionModel GetPositionById(int idPosition);
        DepartmentModel GetDepartmentById(int idDepartment);

        List<StaffModel> GetAllStaffByPositionId(int idPosition);
        List<PositionModel> GetAllPositionsByDepartmentId(int idDepartment);

    }
}
