using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeTrainingRepository
    {

        /// <summary>
        /// Saves the employee training.
        /// </summary>
        /// <param name="employeeTrainingView">The employee training view.</param>
        /// <returns></returns>
        string saveEmployeeTraining(IEmployeeTrainingView employeeTrainingView);
        /// <summary>
        /// Gets the employee training.
        /// </summary>
        /// <param name="EmployeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeTrainingModel> GetEmployeeTraining(int EmployeeId);
        /// <summary>
        /// Gets the employee training by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IEmployeeTrainingModel GetEmployeeTrainingById(int Id);
        /// <summary>
        /// Updates the employee training.
        /// </summary>
        /// <param name="employeeTrainingView">The employee training view.</param>
        /// <returns></returns>
        string UpdateEmployeeTraining(IEmployeeTrainingView employeeTrainingView);
        /// <summary>
        /// Delets the employee training information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string DeletEmployeeTrainingInfo(int employeeTrainingId);
        /// <summary>
        /// Gets the employee training by employee identifier.
        /// </summary>
        /// <param name="EmployeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeTrainingModel> GetEmployeeTrainingByEmployeeId(int EmployeeId);
    }
}
