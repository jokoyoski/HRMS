using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{

    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly IDbContextFactory dbContextFactory;

        
        public EmployeeRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        public IEmployee GetEmployeeById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS) )
                {
                    var employeeInfo = EmployeeQueries.getEmployeeById(dbContext, employeeId);

                    return employeeInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetEmployeeById", e);
            }
        }

        /// <summary>
        /// Saves the spouse information.
        /// </summary>
        /// <param name="spouseViewModel">The spouse view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseViewModel</exception>
        public string SaveSpouseInfo(ISpouseViewModel spouseViewModel)
        {
            if(spouseViewModel == null)
            {
                throw new ArgumentNullException(nameof(spouseViewModel));
            }
            var result = string.Empty;
            var newRecord = new Spouse
            {
                SpouseName = spouseViewModel.SpouseName,
                Email = spouseViewModel.Email,
                Mobile = spouseViewModel.Mobile,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                DateOfBirth = spouseViewModel.DateOfBirth,
                EmployeeId = spouseViewModel.EmployeeId,
                Address = spouseViewModel.Address,
                IsActive = true,
                IsApproved = false,

            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Spouses.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }catch (Exception e)
            {
                result = string.Format("SaveSpouseInfo - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.InnerException.Message : "");

            }
            return result;
        }

        /// <summary>
        /// Gets the spouse by identifier.
        /// </summary>
        /// <param name="spouseId">The spouse identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetEmployeeById</exception>
        public ISpouseModel GetSpouseById(int spouseId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeInfo = EmployeeQueries.GetSpouseByEmployee(dbContext, spouseId);

                    return employeeInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetEmployeeById", e);
            }
        }

        /// <summary>
        /// Gets the spouse information by identifier.
        /// </summary>
        /// <param name="spouseId">The spouse identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetEmployeeById</exception>
        public IList<ISpouseModel> GetSpouseInfoById(int spouseId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeInfo = EmployeeQueries.GetSpouseInfoByEmployee(dbContext, spouseId).ToList();

                    return employeeInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetEmployeeById", e);
            }
        }

        /// <summary>
        /// Updates the spouse information.
        /// </summary>
        /// <param name="spouseViewModel">The spouse view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseViewModel</exception>
        public string UpdateSpouseInfo(ISpouseViewModel spouseViewModel )
        {
            if (spouseViewModel == null)
                throw new ArgumentNullException(nameof(spouseViewModel));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var data = dbContext.Spouses.Find(spouseViewModel.SpouseId);

                    data.SpouseName = spouseViewModel.SpouseName;
                    data.Address = spouseViewModel.Address;
                    data.DateCreated = spouseViewModel.DateCreated;
                    data.DateModified = spouseViewModel.DateModified;
                    data.Mobile = spouseViewModel.Mobile;
                    data.IsApproved = spouseViewModel.IsApproved;
                    data.IsActive = true;
                    data.EmployeeId = spouseViewModel.EmployeeId;
                    data.Email = spouseViewModel.Email;
                    data.DateOfBirth = spouseViewModel.DateOfBirth;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveSkillSetInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the spouse information.
        /// </summary>
        /// <param name="spouseId">The spouse identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseId</exception>
        /// <exception cref="ApplicationException">spouseId</exception>
        public string DeleteSpouseInfo(int spouseId)
        {
            if (spouseId < 1)
                throw new ArgumentNullException("spouseId");

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var data = dbContext.Spouses.SingleOrDefault(m => m.SpouseId.Equals(spouseId));
                    if (data == null)
                    {
                        throw new ApplicationException("spouseId");
                    }
                    data.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Spouse Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the next of kin.
        /// </summary>
        /// <param name="nextOfKin">The next of kin.</param>
        /// <returns></returns>
        public string SaveNextOfKin(INextOfKinView nextOfKin)
        {
            var result = string.Empty;

            var view = new NextOfKin
            {
                EmployeeId = nextOfKin.EmployeeId,
                Address = nextOfKin.Address,
                Relationship = nextOfKin.Relationship,
                Emial = nextOfKin.Emial,
                Mobile = nextOfKin.Mobile,
                DateOfBirth = nextOfKin.DateOfBirth,
                DateCreated = DateTime.Now,
                IsApproved = false,
                NextOfKinName = nextOfKin.NextOfKinName,

                IsActive = true

            };
            try
            {
                // calling our database 
                using (var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    // calling changes
                    dbContext.NextOfKins.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }
        
        /// <summary>
        /// Edits the next of kin.
        /// </summary>
        /// <param name="nextOfKin">The next of kin.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// nextOfKin
        /// or
        /// NextOfKin
        /// </exception>
        public string EditNextOfKin(INextOfKinView nextOfKin)
        {
            var result = string.Empty;

            if (nextOfKin == null)
            {
                throw new ArgumentNullException(nameof(nextOfKin));
            }
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var NextOfKin = dbContext.NextOfKins.Find(nextOfKin.NextOfKinId);

                    if (NextOfKin == null) throw new ArgumentNullException(nameof(NextOfKin));

                    NextOfKin.EmployeeId = nextOfKin.EmployeeId;
                    NextOfKin.Address = nextOfKin.Address;
                    NextOfKin.Relationship = nextOfKin.Relationship;
                    NextOfKin.Emial = nextOfKin.Emial;
                    NextOfKin.Mobile = nextOfKin.Mobile;
                    NextOfKin.DateOfBirth = nextOfKin.DateOfBirth;
                    NextOfKin.DateCreated = DateTime.Now;
                    NextOfKin.IsApproved = false;
                    nextOfKin.DateModified = DateTime.Now;
                    NextOfKin.NextOfKinName = nextOfKin.NextOfKinName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditNextOfKin - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }

        /// <summary>
        /// Deletes the next of kin.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeId</exception>
        /// <exception cref="ApplicationException">nextview</exception>
        public string DeleteNextOfKin(int employeeId)
        {

            if (employeeId < 1)
            {
                throw new ArgumentOutOfRangeException("employeeId");
            }
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var nextview = dbContext.NextOfKins.SingleOrDefault(x => x.NextOfKinId.Equals(employeeId));
                    if (nextview == null)
                    {
                        throw new ApplicationException("nextview");
                    }
                    nextview.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Next of Kin - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }

        /// <summary>
        /// Saves the beneficiaries.
        /// </summary>
        /// <param name="beneficiaries">The beneficiaries.</param>
        /// <returns></returns>
        public string SaveBeneficiaries(IBeneficiariesView beneficiaries)
        {
            var result = string.Empty;

            var view = new Beneficiary
            {
                EmployeeId = beneficiaries.EmployeeId,
                Address = beneficiaries.Address,
                Email = beneficiaries.Email,
                Mobile = beneficiaries.Mobile,
                DateOfBirth = beneficiaries.DateOfBirth,
                DateCreated = DateTime.Now,
                IsApproved = false,
                BeneficiaryName = beneficiaries.BeneficiaryName,
                DateModified = DateTime.UtcNow,
                IsActive = true

            };
            try
            {
                // calling our database 
                using (var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    // calling changes
                    dbContext.Beneficiaries.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        /// <summary>
        /// Edits the beneficiaries.
        /// </summary>
        /// <param name="beneficiaries">The beneficiaries.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// beneficiaries
        /// or
        /// Beneficiaries
        /// </exception>
        public string EditBeneficiaries(IBeneficiariesView beneficiaries)
        {
            var result = string.Empty;

            if (beneficiaries == null)
            {
                throw new ArgumentNullException(nameof(beneficiaries));
            }
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var Beneficiaries = dbContext.Beneficiaries.SingleOrDefault(x => x.BeneficiaryId == beneficiaries.BeneficiaryId);

                    if (Beneficiaries == null) throw new ArgumentNullException(nameof(Beneficiaries));
                    
                    Beneficiaries.Address = beneficiaries.Address;
                    Beneficiaries.Email = beneficiaries.Email;
                    Beneficiaries.Mobile = beneficiaries.Mobile;
                    Beneficiaries.DateOfBirth = beneficiaries.DateOfBirth;
                    Beneficiaries.DateModified = DateTime.Now;
                    Beneficiaries.IsApproved = false;
                    Beneficiaries.BeneficiaryName = beneficiaries.BeneficiaryName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditBeneficiaries - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }

        /// <summary>
        /// Deletes the beneficiaries.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeId</exception>
        /// <exception cref="ApplicationException">beneficiaries</exception>
        public string DeleteBeneficiaries(int employeeId)
        {

            if (employeeId < 1)
            {
                throw new ArgumentOutOfRangeException("employeeId");
            }
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var beneficiaries = dbContext.Beneficiaries.SingleOrDefault(x => x.EmployeeId.Equals(employeeId));
                    if (beneficiaries == null)
                    {
                        throw new ApplicationException("beneficiaries");
                    }
                    beneficiaries.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Beneficiaries - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }
        
        /// <summary>
        /// Saves the emergency contact.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <returns></returns>
        public string SaveEmergencyContact(IEmergencyContactView emergency)
        {
            var result = string.Empty;

            var view = new Emergency
            {
                EmployeeId = emergency.EmployeeId,
                Address = emergency.Address,
                Email = emergency.Email,
                Mobile = emergency.Mobile,
                DateOfBirth = emergency.DateOfBirth,
                DateCreated = DateTime.Now,
                IsApproved = false,
                EmergencyName = emergency.EmergencyName,

                IsActive = true

            };
            try
            {
                // calling our database 
                using (var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    // calling changes
                    dbContext.Emergencies.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        /// <summary>
        /// Edits the emergency contact.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// emergency
        /// or
        /// EmergencyContact
        /// </exception>
        public string EditEmergencyContact(IEmergencyContactView emergency)
        {
            var result = string.Empty;

            if (emergency == null)
            {
                throw new ArgumentNullException(nameof(emergency));
            }
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var EmergencyContact = dbContext.Emergencies.SingleOrDefault(x => x.EmergencyId == emergency.EmergencyId);

                    if (EmergencyContact == null) throw new ArgumentNullException(nameof(EmergencyContact));

                    EmergencyContact.EmployeeId = emergency.EmployeeId;
                    EmergencyContact.Address = emergency.Address;
                    EmergencyContact.Email = emergency.Email;
                    EmergencyContact.Mobile = emergency.Mobile;
                    EmergencyContact.DateOfBirth = emergency.DateOfBirth;
                    EmergencyContact.DateCreated = emergency.DateCreated;
                    EmergencyContact.DateModified = DateTime.Now;
                    EmergencyContact.IsApproved = false;
                    EmergencyContact.EmergencyName = emergency.EmergencyName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditEmergencyContact - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }

        /// <summary>
        /// Deletes the emergency contact.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// emergency
        /// or
        /// EmergencyContact
        /// </exception>
        public string DeleteEmergencyContact(IEmergencyContactView emergency)
        {
            var result = string.Empty;

            if (emergency == null)
            {
                throw new ArgumentNullException(nameof(emergency));
            }
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var EmergencyContact = dbContext.Emergencies.SingleOrDefault(x => x.EmergencyId == emergency.EmergencyId);

                    if (EmergencyContact == null) throw new ArgumentNullException(nameof(EmergencyContact));

                    EmergencyContact.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditEmergencyContact - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }

        /// <summary>
        /// Saves the children information.
        /// </summary>
        /// <param name="children">The children.</param>
        /// <returns></returns>
        public string SaveChildrenInformation(IChildrenInformationView children)
        {
            var result = string.Empty;

            var view = new Child
            {
                EmployeeId = children.EmployeeId,
                Address = children.Address,
                Email = children.Email,
                Mobile = children.Mobile,
                DateOfBirth = children.DateOfBirth,
                DateCreated = DateTime.Now,
                IsApproved = false,
                ChildName = children.ChildName,
                DateModified =  DateTime.UtcNow,
                IsActive = true

            };
            try
            {
                // calling our database 
                using (var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    // calling changes
                    dbContext.Children.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        /// <summary>
        /// Edits the children information.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// information
        /// or
        /// ChildrenInfo
        /// </exception>
        public string EditChildrenInformation(IChildrenInformationView information)
        {
            var result = string.Empty;

            if (information == null)
            {
                throw new ArgumentNullException(nameof(information));
            }
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var ChildrenInfo = dbContext.Children.SingleOrDefault(x => x.ChildrenId == information.ChildrenId);

                    if (ChildrenInfo == null) throw new ArgumentNullException(nameof(ChildrenInfo));

                    ChildrenInfo.EmployeeId = information.EmployeeId;
                    ChildrenInfo.Address = information.Address;
                    ChildrenInfo.Email = information.Email;
                    ChildrenInfo.Mobile = information.Mobile;
                    ChildrenInfo.DateOfBirth = information.DateOfBirth;
                    ChildrenInfo.DateCreated = information.DateCreated;
                    ChildrenInfo.DateModified = DateTime.Now;
                    ChildrenInfo.IsApproved = false;
                    ChildrenInfo.ChildName = information.ChildName;
                    ChildrenInfo.IsActive = true;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditChildrenInformation - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        }

        /// <summary>
        /// Deletes the children information.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// information
        /// or
        /// ChildrenInfo
        /// </exception>
        public string DeleteChildrenInformation(IChildrenInformationView information)
        {
            var result = string.Empty;

            if (information == null)
            {
                throw new ArgumentNullException(nameof(information));
            }
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var ChildrenInfo = dbContext.Children.SingleOrDefault(x => x.ChildrenId == information.ChildrenId);

                    if (ChildrenInfo == null) throw new ArgumentNullException(nameof(ChildrenInfo));

                    ChildrenInfo.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditChildrenInformation - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;
        
        }
    }
}