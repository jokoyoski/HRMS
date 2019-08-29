using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    
    public interface IEmployeeRepository
    {

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmployee GetEmployeeById(int employeeId);

        string SaveNextOfKin(INextOfKinView nextOfKin);

        string EditNextOfKin(INextOfKinView nextOfKin);

        string DeleteNextOfKin(int employeeId);

        string SaveBeneficiaries(IBeneficiariesView beneficiaries);

        string EditBeneficiaries(IBeneficiariesView beneficiaries);

        string DeleteBeneficiaries(int employeeId);

        string SaveEmergencyContact(IEmergencyContactView emergency);

        string EditEmergencyContact(IEmergencyContactView emergency);

        string DeleteEmergencyContact(IEmergencyContactView emergency);

        string DeleteChildrenInformation(IChildrenInformationView information);
        string EditChildrenInformation(IChildrenInformationView information);

        string SaveChildrenInformation(IChildrenInformationView children);
        string SaveSpouseInfo(ISpouseViewModel spouseViewModel);

        ISpouseModel GetSpouseById(int spouseId);
        string UpdateSpouseInfo(ISpouseViewModel spouseViewModel);
        string DeleteSpouseInfo(int spouseId);
        IList<ISpouseModel> GetSpouseInfoById(int spouseId);

    }
}
