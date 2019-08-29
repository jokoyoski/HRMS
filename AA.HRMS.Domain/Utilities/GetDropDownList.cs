using AA.HRMS.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Utilities
{
    public static class GetDropDownList
    {
        internal static IList<SelectListItem> AboutUsSourceListItems(IList<IHowSource> aboutUsSourceCollection,
            int selectedAboutUsSourceId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectAboutUsSourceText,
                    Value = "-1",
                    Selected = (selectedAboutUsSourceId < 1)
                }
            };

            if (aboutUsSourceCollection.Any())
            {
                list.AddRange(aboutUsSourceCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.AboutUsSourceId.ToString(),
                    Selected = (t.AboutUsSourceId.Equals(selectedAboutUsSourceId))
                }));
            }

            return list;
        }
        

        internal static IList<SelectListItem> QueryListItems(IList<IQuery> queryCollection,
            int selectedQueryId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectedQuery,
                    Value = "-1",
                    Selected = (selectedQueryId < 1)
                }
            };

            if (queryCollection.Any())
            {
                list.AddRange(queryCollection.Select(t => new SelectListItem
                {
                    Text = t.Consequences,
                    Value = t.QueryId.ToString(),
                    Selected = (t.QueryId.Equals(selectedQueryId))
                }));
            }

            return list;
        }

        
        internal static IList<SelectListItem> GenderListItems(IList<IYourGender> genderCollection,
           int selectedGenderId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectGenderText,
                    Value = "-1",
                    Selected = (selectedGenderId < 1)
                }
            };

            if (genderCollection.Any())
            {
                list.AddRange(genderCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.GenderId.ToString(),
                    Selected = (t.GenderId.Equals(selectedGenderId))
                }));
            }

            return list;
        }

       

        
        internal static IList<SelectListItem> DepartmentListItems(IList<IDepartment> departmentCollection,
            int? selectedDepartmentId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectDepartmentText,
                    Value = "-1",
                    Selected = (selectedDepartmentId < 1)
                }
            };

            if (departmentCollection.Any())
            {
                list.AddRange(departmentCollection.Select(t => new SelectListItem
                {
                    Text = t.DepartmentName,
                    Value = t.DepartmentId.ToString(),
                    Selected = (t.DepartmentId.Equals(selectedDepartmentId))
                }));
            }

            return list;
        }

        
        internal static IList<SelectListItem> DepartmentListItemsByCompany(IList<IDepartment> departmentCollection,
            int selectedDepartmentId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectDepartmentText,
                    Value = "-1",
                    Selected = (selectedDepartmentId < 1)
                }
            };

            if (departmentCollection.Any())
            {
                list.AddRange(departmentCollection.Select(t => new SelectListItem
                {
                    Text = t.DepartmentName,
                    Value = t.DepartmentId.ToString(),
                    Selected = (t.DepartmentId.Equals(selectedDepartmentId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Companies the list items.
        /// </summary>
        /// <param name="companyCollection">The companyt collection.</param>
        /// <param name="selectedCompanytId">The selected companyt identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> CompanyListItems(IList<ICompanyDetail> companyCollection,
            int selectedCompanytId)
        {
            var list = new List<SelectListItem>
            {
               new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectCompanyText,
                    Value = "-1",
                    Selected = (selectedCompanytId < 1)
                }
            };

            if (companyCollection.Any())
            {
                list.AddRange(companyCollection.Select(t => new SelectListItem
                {
                    Text = t.CompanyName,
                    Value = t.CompanyId.ToString(),
                    Selected = (t.CompanyId.Equals(selectedCompanytId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Jobs the titles list items.
        /// </summary>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="selectedjobTitleId">The selectedjob title identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> JobTitlesListItems(IList<IJobTitle> jobTitleCollection,
            int selectedjobTitleId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectJobTitleText,
                    Value = "-1",
                    Selected = (selectedjobTitleId < 1)
                }
            };

            if (jobTitleCollection.Any())
            {
                list.AddRange(jobTitleCollection
                    .Select(t => new SelectListItem
                    {
                        Text = t.JobTitleName,
                        Value = t.JobTitleId.ToString(),
                        Selected = (t.CompanyId.Equals(selectedjobTitleId))
                    }));
            }

            return list;
        }

        /// <summary>
        /// Grades the list items.
        /// </summary>
        /// <param name="gradesCollections">The grades collections.</param>
        /// <param name="selectedGradeId">The selected grade identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> GradeListItems(IList<IGrade> gradesCollections,
            int selectedGradeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectGradeText,
                    Value = "-1",
                    Selected = (selectedGradeId < 1)
                }
            };

            if (gradesCollections.Any())
            {
                list.AddRange(gradesCollections.Select(t => new SelectListItem
                {
                    Text = t.GradeName,
                    Value = t.GradeId.ToString(),
                    Selected = (t.GradeId.Equals(selectedGradeId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Levels the list items.
        /// </summary>
        /// <param name="levelCollections">The level collections.</param>
        /// <param name="selectedLevelId">The selected level identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> LevelListItems(IList<ILevel> levelCollections,
            int selectedLevelId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectLevelText,
                    Value = "-1",
                    Selected = (selectedLevelId < 1)
                }
            };

            if (levelCollections.Any())
            {
                list.AddRange(levelCollections.Select(t => new SelectListItem
                {
                    Text = t.LevelName,
                    Value = t.LevelId.ToString(),
                    Selected = (t.LevelId.Equals(selectedLevelId))
                }));
            }

            return list;
        }

        

        /// <summary>
        /// Parents the company list items.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="selectedId">The selected identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ParentCompanyListItems(IList<ICompanyDetail> companyCollection,
            int selectedId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectParentCompanyText,
                    Value = "-1",
                    Selected = (selectedId < 1)
                }
            };

            if (companyCollection.Any())
            {
                list.AddRange(companyCollection.Select(t => new SelectListItem
                {
                    Text = t.CompanyName,
                    Value = t.CompanyId.ToString(),
                    Selected = (t.CompanyId.Equals(selectedId))
                }));
            }

            return list;
        }

        /// <summary>
        /// is the indsutry list items.
        /// </summary>
        /// <param name="industryCollection">The industry collection.</param>
        /// <param name="selectedId">The selected identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> IIndsutryListItems(IList<IIndustry> industryCollection,
            int selectedId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectIndustry,
                    Value = "-1",
                    Selected = (selectedId < 1)
                }
            };

            if (industryCollection.Any())
            {
                list.AddRange(industryCollection.Select(t => new SelectListItem
                {
                    Text = t.IndustryName,
                    Value = t.IndustryId.ToString(),
                    Selected = (t.IndustryId.Equals(selectedId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Experiences the list item.
        /// </summary>
        /// <param name="experienceCollection">The experience collection.</param>
        /// <param name="selectedId">The selected identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ExperienceListItem(IList<IExperience> experienceCollection, 
            int selectedId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectExperience,
                    Value = "-1",
                    Selected = (selectedId < 1)
                }
            };

            if (experienceCollection.Any())
            {
                list.AddRange(experienceCollection.Select(t => new SelectListItem
                {
                    Text = t.Experience,
                    Value = t.ExperienceId.ToString(),
                    Selected = (t.ExperienceId.Equals(selectedId))
                }));
            }
            return list;
        }

        /// <summary>
        /// Monthes the specified month collection.
        /// </summary>
        /// <param name="monthCollection">The month collection.</param>
        /// <param name="selectedId">The selected identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> Month(IList<IMonth> monthCollection,
            string selectedId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectMonth,
                    Value = "",
                    Selected = (selectedId == null)
                }
            };
            if (monthCollection.Any())
            {
                list.AddRange(monthCollection.Select(t => new SelectListItem
                {
                    Text = t.MonthName,
                    Value = t.MonthCode.ToString(),
                    Selected = (t.MonthCode.Equals(selectedId))

                }));
            }
            return list;
        }

        /// <summary>
        /// Years the specified year collection.
        /// </summary>
        /// <param name="yearCollection">The year collection.</param>
        /// <param name="selectId">The select identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> Year(IList<IYear> yearCollection,
            int selectId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectYear,
                    Value = "-1",
                    Selected = (selectId < 1)
                }
            };
            if (yearCollection.Any())
            {
                list.AddRange(yearCollection.Select(t => new SelectListItem
                {
                    Text = t.Year,
                    Value = t.YearId.ToString(),
                    Selected = (t.YearId.Equals(selectId))
                }));
            }
            return list;
        }

        /// <summary>
        /// Leaves the type list items.
        /// </summary>
        /// <param name="leaveTypeCollection">The leave type collection.</param>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> LeaveTypeListItems(IList<ILeaveType> leaveTypeCollection,
            int leaveTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectLeaveTypeText,
                    Value = "-1",
                    Selected = (leaveTypeId < 1)
                }
            };

            if (leaveTypeCollection.Any())
            {
                list.AddRange(leaveTypeCollection.Select(t => new SelectListItem
                {
                    Text = t.LeaveTypeName,
                    Value = t.LeaveTypeID.ToString(),
                    Selected = (t.LeaveTypeID.Equals(leaveTypeId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Leaves the status list items.
        /// </summary>
        /// <param name="leaveRequestCollection">The leave request collection.</param>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> LeaveStatusListItems(IList<ILeaveStatus> leaveRequestCollection,
            int leaveStatusId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectLeaveStatusText,
                    Value = "-1",
                    Selected = (leaveStatusId < 1)
                }
            };

            if (leaveRequestCollection.Any())
            {
                list.AddRange(leaveRequestCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.LeaveStatusId.ToString(),
                    Selected = (t.LeaveStatusId.Equals(leaveStatusId))
                }));
            }

            return list;
        }


        /// <summary>
        /// Genders the list items.
        /// </summary>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="selectedGenderId">The selected gender identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> GenderListItems(IList<IYourGender> genderCollection,
       int? selectedGenderId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectGenderText,
                    Value = "-1",
                    Selected = (selectedGenderId < 1)
                }
            };

            if (genderCollection.Any())
            {
                list.AddRange(genderCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.GenderId.ToString(),
                    Selected = (t.GenderId.Equals(selectedGenderId))
                }));
            }

            return list;
        }


        /// <summary>
        /// Maritals the status list items.
        /// </summary>
        /// <param name="maritalStatusCollection">The marital status collection.</param>
        /// <param name="selectedMaritalStatusId">The selected marital status identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> MaritalStatusListItems(IList<IMaritalStatus> maritalStatusCollection,
          int? selectedMaritalStatusId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectMaritalStatusText,
                    Value = "-1",
                    Selected = (selectedMaritalStatusId < 1)
                }
            };

            if (maritalStatusCollection.Any())
            {
                list.AddRange(maritalStatusCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.MaritalStatusId.ToString(),
                    Selected = (t.MaritalStatusId.Equals(selectedMaritalStatusId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Religions the list items.
        /// </summary>
        /// <param name="religionCollection">The religion collection.</param>
        /// <param name="selectedReligionId">The selected religion identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ReligionListItems(IList<IReligion> religionCollection,
           int? selectedReligionId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectReligionText,
                    Value = "-1",
                    Selected = (selectedReligionId < 1)
                }
            };

            if (religionCollection.Any())
            {
                list.AddRange(religionCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.ReligionId.ToString(),
                    Selected = (t.ReligionId.Equals(selectedReligionId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Applications the role list items.
        /// </summary>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <param name="selectedAppRoleId">The selected application role identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> AppRoleListItems(IList<IAppRole> appRoleCollection,
            int? selectedAppRoleId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectAppRoleText,
                    Value = "-1",
                    Selected = (selectedAppRoleId < 1)
                }

            };

            if (appRoleCollection.Any())
            {
                list.AddRange(appRoleCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.AppRoleId.ToString(),
                    Selected = (t.AppRoleId.Equals(selectedAppRoleId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Appraisers the list items.
        /// </summary>
        /// <param name="appraiserCollection">The appraiser collection.</param>
        /// <param name="selectedAppraiserId">The selected appraiser identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> AppraiserListItems(IList<IEmployee> appraiserCollection,
            int? selectedAppraiserId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectAppraiserText,
                    Value = "-1",
                    Selected = (selectedAppraiserId < 1)
                }
            };

            if (appraiserCollection.Any())
            {
                list.AddRange(appraiserCollection.Select(t => new SelectListItem
                {
                    Text = t.LastName + " " + t.FirstName,
                    Value = t.EmployeeId.ToString(),
                    Selected = (t.EmployeeId.Equals(selectedAppraiserId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Appraisals the ratings list items.
        /// </summary>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="selectedAppraisalRatingId">The selected appraisal rating identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> AppraisalRatingsListItems(IList<IAppraisalRating> appraisalRatingsCollection,
           int? selectedAppraisalRatingId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectAppraisalRatingText,
                    Value = "-1",
                    Selected = (selectedAppraisalRatingId < 1)
                }
            };

            if (appraisalRatingsCollection.Any())
            {
                list.AddRange(appraisalRatingsCollection.Select(t => new SelectListItem
                {
                    Text = t.AppraisalRatingId.ToString(),
                    Value = t.AppraisalRatingId.ToString(),
                    Selected = (t.AppraisalRatingId.Equals(selectedAppraisalRatingId))
                }));
            }

            return list;
        }

        internal static IList<SelectListItem> ResultListItem(IList<IResult> resultCollection,
           int? selecctedResultId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectAppraisalRatingText,
                    Value = "-1",
                    Selected = (selecctedResultId < 1)
                }
            };

            if (resultCollection.Any())
            {
                list.AddRange(resultCollection.Select(t => new SelectListItem
                {
                    Text = t.ResultName.ToString(),
                    Value = t.ResultId.ToString(),
                    Selected = (t.ResultId.Equals(selecctedResultId))
                }));
            }

            return list;
        }


        

        /// <summary>
        /// Appraisals the actions list items.
        /// </summary>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="selectedAppraisalActionId">The selected appraisal action identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> AppraisalActionsListItems(IList<IAppraisalAction> appraisalActionsCollection,
          int? selectedAppraisalActionId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectAppraisalActionText,
                    Value = "-1",
                    Selected = (selectedAppraisalActionId < 1)
                }
            };

            if (appraisalActionsCollection.Any())
            {
                list.AddRange(appraisalActionsCollection.Select(t => new SelectListItem
                {
                    Text = t.AppraisalActionName,
                    Value = t.AppraisalActionId.ToString(),
                    Selected = (t.AppraisalActionId.Equals(selectedAppraisalActionId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Employees the list items.
        /// </summary>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> EmployeeTrainingListItems(IList<IEmployeeTrainingModel> employeeTrainingCollection,
          int? selectedEmployeeTrainingId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectEmployeeText,
                    Value = "-1",
                    Selected = (selectedEmployeeTrainingId < 1)
                }
            };

            if (employeeTrainingCollection.Any())
            {
                list.AddRange(employeeTrainingCollection.Select(t => new SelectListItem
                {
                    Text = t.EmployeeName,
                    Value = t.EmployeeTrainingId.ToString(),
                    Selected = (t.EmployeeTrainingId.Equals(selectedEmployeeTrainingId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Types the of exit list items.
        /// </summary>
        /// <param name="typeOfExitCollection">The type of exit collection.</param>
        /// <param name="selectedTypeOfExitId">The selected type of exit identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> TypeOfExitListItems(IList<ITypeOfExit> typeOfExitCollection,
          int? selectedTypeOfExitId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectTypeOfExitText,
                    Value = "-1",
                    Selected = (selectedTypeOfExitId < 1)
                }
            };

            if (typeOfExitCollection.Any())
            {
                list.AddRange(typeOfExitCollection.Select(t => new SelectListItem
                {
                    Text = t.TypeOfExitName,
                    Value = t.TypeOfExitId.ToString(),
                    Selected = (t.TypeOfExitId.Equals(selectedTypeOfExitId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Employees the listitems.
        /// </summary>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> EmployeeListitems(IList<IEmployee> employeeCollection,
        int? selectedEmployeeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectEmployeeText,
                    Value = "-1",
                    Selected = (selectedEmployeeId < 1)
                }
            };

            if (employeeCollection.Any())
            {
                list.AddRange(employeeCollection.Select(t => new SelectListItem
                {
                    Text = t.FirstName + " " + t.LastName,
                    Value = t.EmployeeId.ToString(),
                    Selected = (t.EmployeeId.Equals(selectedEmployeeId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Employments the type list item.
        /// </summary>
        /// <param name="employmentTypeCollection">The employment type collection.</param>
        /// <param name="selectedEmploymentTypeId">The selected employment type identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> EmploymentTypeListItem(IList<IEmploymentType> employmentTypeCollection,
        int? selectedEmploymentTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectEmploymentTypeText,
                    Value = "-1",
                    Selected = (selectedEmploymentTypeId < 1)
                }
            };

            if (employmentTypeCollection.Any())
            {
                list.AddRange(employmentTypeCollection.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.EmploymentTypeId.ToString(),
                    Selected = (t.EmploymentTypeId.Equals(selectedEmploymentTypeId))
                }));
            }

            return list;
        }

        

        /// <summary>
        /// Taxes the list items.
        /// </summary>
        /// <param name="taxCollection">The tax collection.</param>
        /// <param name="selectedTaxId">The selected tax identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> TaxListItems(IList<ITax> taxCollection,
        int? selectedTaxId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectTaxText,
                    Value = "-1",
                    Selected = (selectedTaxId < 1)
                }
            };

            if (taxCollection.Any())
            {
                list.AddRange(taxCollection.Select(t => new SelectListItem
                {
                    Text = t.TaxRate.ToString(),
                    Value = t.TaxId.ToString(),
                    Selected = (t.TaxId.Equals(selectedTaxId))
                }));
            }

            return list;
        }

        internal static IList<SelectListItem> TrainingListItems(IList<ITraining> trainingCollection,
      int? selectedTrainingID)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectTrainingText,
                    Value = "-1",
                    Selected = (selectedTrainingID < 1)
                }
            };

            if (trainingCollection.Any())
            {
                list.AddRange(trainingCollection.Select(t => new SelectListItem
                {
                    Text = t.TrainingName.ToString(),
                    Value = t.TrainingID.ToString(),
                    Selected = (t.TrainingID.Equals(selectedTrainingID))
                }));
            }

            return list;
        }

        /// <summary>
        /// Loans the list items.
        /// </summary>
        /// <param name="loanCollection">The loan collection.</param>
        /// <param name="selectedLoanId">The selected loan identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> LoanListItems(IList<ILoan> loanCollection,
        int? selectedLoanId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectLoanText,
                    Value = "-1",
                    Selected = (selectedLoanId < 1)
                }
            };

            if (loanCollection.Any())
            {
                list.AddRange(loanCollection.Select(t => new SelectListItem
                {
                    Text = t.LoanType,
                    Value = t.LoanTypeId.ToString(),
                    Selected = (t.LoanTypeId.Equals(selectedLoanId))
                }));
            }

            return list;
        }


        internal static IList<SelectListItem> FrequencyOfDeliveryListItems(IList<IFrequencyOfDeliveryModel> FrequencyOfDeliveryCollection,
       int? selectedFrequencyOfDeliveryId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectFrequencyOfDeliveryText,
                    Value = "-1",
                    Selected = (selectedFrequencyOfDeliveryId < 1)
                }
            };

            if (FrequencyOfDeliveryCollection.Any())
            {
                list.AddRange(FrequencyOfDeliveryCollection.Select(t => new SelectListItem
                {
                    Text = t.FrequencyOfDelivery1,
                    Value = t.FrequencyOfDeliveryId.ToString(),
                    Selected = (t.FrequencyOfDeliveryId.Equals(selectedFrequencyOfDeliveryId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Trainings the status list items.
        /// </summary>
        /// <param name="trainingStatusCollection">The training status collection.</param>
        /// <param name="selectedTrainingStatusId">The selected training status identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> TrainingStatusListItems(IList<ITrainingStatus> trainingStatusCollection,
        int? selectedTrainingStatusId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectTrainingStatusText,
                    Value = "-1",
                    Selected = (selectedTrainingStatusId < 1)
                }
            };

            if (trainingStatusCollection.Any())
            {
                list.AddRange(trainingStatusCollection.Select(t => new SelectListItem
                {
                    Text = t.Status,
                    Value = t.TrainingStatusId.ToString(),
                    Selected = (t.TrainingStatusId.Equals(selectedTrainingStatusId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Currencies the list items.
        /// </summary>
        /// <param name="currencyCollection">The currency collection.</param>
        /// <param name="selectedCurrencyId">The selected currency identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> CurrencyListItems(IList<ICurrency> currencyCollection,
        int? selectedCurrencyId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectCurrency,
                    Value = "-1",
                    Selected = (selectedCurrencyId < 1)
                }
            };

            if (currencyCollection.Any())
            {
                list.AddRange(currencyCollection.Select(t => new SelectListItem
                {
                    Text = t.Currency1,
                    Value = t.CurrencyId.ToString(),
                    Selected = (t.CurrencyId.Equals(selectedCurrencyId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Methonds the of delivery list items.
        /// </summary>
        /// <param name="methodOfCollection">The method of collection.</param>
        /// <param name="selectedMethodOfDeliveryId">The selected method of delivery identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> MethondOfDeliveryListItems(IList<IMethodOfDelivery> methodOfCollection,
        int? selectedMethodOfDeliveryId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectedMethodOfDelivery,
                    Value = "-1",
                    Selected = (selectedMethodOfDeliveryId < 1)
                }
            };

            if (methodOfCollection.Any())
            {
                list.AddRange(methodOfCollection.Select(t => new SelectListItem
                {
                    Text = t.MethodOfDeliveryTraining,
                    Value = t.MethodOfDeliveryTrainingId.ToString(),
                    Selected = (t.MethodOfDeliveryTrainingId.Equals(selectedMethodOfDeliveryId))
                }));
            }

            return list;
        }

        internal static IList<SelectListItem> TrainingEvaluationListItems(IList<ITrainingEvaluationRating> TrainingEvaluationCollection,
       int? selectedTrainingEvaluationID)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectTrainingEvaluationText,
                    Value = "-1",
                    Selected = (selectedTrainingEvaluationID < 1)
                }
            };

            if (TrainingEvaluationCollection.Any())
            {
                list.AddRange(TrainingEvaluationCollection.Select(t => new SelectListItem
                {
                    Text = t.TrainingEvaluationRating1,
                    Value = t.TrainingEvaluationRatingId.ToString(),
                    Selected = (t.TrainingEvaluationRatingId.Equals(selectedTrainingEvaluationID))
                }));
            }

            return list;
        }
        
             internal static IList<SelectListItem> TrainingCalendarListItems(IList<ITrainingCalendar> TrainingCalendarCollection,
       int? selectedTrainingCalendarID)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.selectedTrainingCalendarText,
                    Value = "-1",
                    Selected = (selectedTrainingCalendarID < 1)
                }
            };

            if (TrainingCalendarCollection.Any())
            {
                list.AddRange(TrainingCalendarCollection.Select(t => new SelectListItem
                {
                    Text = t.TrainingName + " " + t.DeliveryStartDate,
                    Value = t.TrainingCalenderId.ToString(),
                    Selected = (t.TrainingCalenderId.Equals(selectedTrainingCalendarID))
                }));
            }

            return list;
        }


        internal static IList<SelectListItem> QueryStatusListItem(IList<IQueryStatus> queryCollection,
        int? selectedQueryId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectedQuery,
                    Value = "-1",
                    Selected = (selectedQueryId < 1)
                }
            };

            if (queryCollection.Any())
            {
                list.AddRange(queryCollection.Select(t => new SelectListItem
                {
                    Text = t.QueryStatusName,
                    Value = t.QueryStatusId.ToString(),
                    Selected = (t.QueryStatusId.Equals(selectedQueryId))
                }));
            }

            return list;
        }


        /// <summary>
        /// Actions the taken list item.
        /// </summary>
        /// <param name="actionTakenCollection">The action taken collection.</param>
        /// <param name="selectedActionTakenId">The selected action taken identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ActionTakenListItem(IList<IActionTaken> actionTakenCollection,
        int? selectedActionTakenId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectedActionTaken,
                    Value = "-1",
                    Selected = (selectedActionTakenId < 1)
                }
            };

            if (actionTakenCollection.Any())
            {
                list.AddRange(actionTakenCollection.Select(t => new SelectListItem
                {
                    Text = t.ActionTakenName,
                    Value = t.ActionTakenId.ToString(),
                    Selected = (t.ActionTakenId.Equals(selectedActionTakenId))
                }));
            }

            return list;
        }


        /// <summary>
        /// Certificates the list item.
        /// </summary>
        /// <param name="certificateCollection">The certificate collection.</param>
        /// <param name="selectedCertificationId">The selected certification identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> CertificateListItem(IList<ICertificationModel> certificateCollection,
        int? selectedCertificationId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectedActionTaken,
                    Value = "-1",
                    Selected = (selectedCertificationId < 1)
                }
            };

            if (certificateCollection.Any())
            {
                list.AddRange(certificateCollection.Select(t => new SelectListItem
                {
                    Text = t.CertificationName,
                    Value = t.CertificationId.ToString(),
                    Selected = (t.CertificationId.Equals(selectedCertificationId))
                }));
            }

            return list;
        }


        internal static IList<SelectListItem> TrainingReportListItem(IList<ITrainingReport> trainingReportCollection,
       int? selectedTrainingReportId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectedActionTaken,
                    Value = "-1",
                    Selected = (selectedTrainingReportId < 1)
                }
            };

            if (trainingReportCollection.Any())
            {
                list.AddRange(trainingReportCollection.Select(t => new SelectListItem
                {
                    Text = t.TrainerName,
                    Value = t.TrainingReportId.ToString(),
                    Selected = (t.TrainingReportId.Equals(selectedTrainingReportId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Appraisals the list items.
        /// </summary>
        /// <param name="appraisalCollection">The appraisal collection.</param>
        /// <param name="selectedAppraisalId">The selected appraisal identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> AppraisalListItems(IList<IAppraisal> appraisalCollection,
        int? selectedAppraisalId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectAppraisalText,
                    Value = "-1",
                    Selected = (selectedAppraisalId < 1)
                }
            };

            if (appraisalCollection.Any())
            {
                list.AddRange(appraisalCollection.Select(t => new SelectListItem
                {
                    Text = t.AppraisalPeriodName + " " + t.AppraisalYearName.ToString(),
                    Value = t.AppraisalId.ToString(),
                    Selected = (t.AppraisalId.Equals(selectedAppraisalId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Appraisals the period list item.
        /// </summary>
        /// <param name="appraisalPeriodCollection">The appraisal period collection.</param>
        /// <param name="selectedAppraisalPeriodId">The selected appraisal period identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> AppraisalPeriodListItem(IList<IAppraisalPeriod> appraisalPeriodCollection,
        int? selectedAppraisalPeriodId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectedAppraisalPeriod,
                    Value = "-1",
                    Selected = (selectedAppraisalPeriodId < 1)
                }
            };

            if (appraisalPeriodCollection.Any())
            {
                list.AddRange(appraisalPeriodCollection.Select(t => new SelectListItem
                {
                    Text = t.Appraisalperiod1,
                    Value = t.AppraisalPeriodId.ToString(),
                    Selected = (t.AppraisalPeriodId.Equals(selectedAppraisalPeriodId))
                }));
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryCollection"></param>
        /// <param name="selectedCountryId"></param>
        /// <returns></returns>
        internal static IList<SelectListItem> CountryListItem(IList<ICountry> countryCollection,
        int? selectedCountryId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectCountry,
                    Value = "-1",
                    Selected = (selectedCountryId == 161)
                }
            };

            if (countryCollection.Any())
            {
                list.AddRange(countryCollection.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.CountryId.ToString(),
                    Selected = (t.CountryId.Equals(selectedCountryId))
                }));
            }

            return list;
        }
        /// <summary>
        /// States the list item.
        /// </summary>
        /// <param name="stateCollection">The state collection.</param>
        /// <param name="selectedStateId">The selected state identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> StateListItem(IList<IState> stateCollection,
        int? selectedStateId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectState,
                    Value = "-1",
                    Selected = (selectedStateId < 1)
                }
            };

            if (stateCollection.Any())
            {
                list.AddRange(stateCollection.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.StateId.ToString(),
                    Selected = (t.StateId.Equals(selectedStateId))
                }));
            }

            return list;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="benefitCollection"></param>
        /// <param name="selectedBenefitId"></param>
        /// <returns></returns>
        internal static IList<SelectListItem> BenefitListItem(IList<IBenefit> benefitCollection,
        int? selectedBenefitId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectBenefit,
                    Value = "-1",
                    Selected = (selectedBenefitId < 1)
                }
            };

            if (benefitCollection.Any())
            {
                list.AddRange(benefitCollection.Select(t => new SelectListItem
                {
                    Text = t.BenefitName,
                    Value = t.BenefitId.ToString(),
                    Selected = (t.BenefitId.Equals(selectedBenefitId))
                }));
            }

            return list;
        }

        internal static IList<SelectListItem> DeductionListItem(IList<IDeduction> deductionCollection,
    int? selectedDeductionId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectDeduction,
                    Value = "-1",
                    Selected = (selectedDeductionId < 1)
                }
            };

            if (deductionCollection.Any())
            {
                list.AddRange(deductionCollection.Select(t => new SelectListItem
                {
                    Text = t.DeductionName,
                    Value = t.DeductionId.ToString(),
                    Selected = (t.DeductionId.Equals(selectedDeductionId))
                }));
            }

            return list;
        }

        

        internal static IList<SelectListItem> RewardListItems(IList<IReward> rewardCollection,
        int? selectedRewardId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectRewards,
                    Value = "-1",
                    Selected = (selectedRewardId < 1)
                }
            };

            if (rewardCollection.Any())
            {
                list.AddRange(rewardCollection.Select(t => new SelectListItem
                {
                    Text = t.RewardName,
                    Value = t.RewardId.ToString(),
                    Selected = (t.RewardId.Equals(selectedRewardId))
                }));
            }

            return list;
        }

        internal static IList<SelectListItem> PayScaleListItem(IList<IPayScale> payScaleCollection,
        int? selectPayScaleId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = AA.HRMS.Domain.Resources.Common.SelectPayScale,
                    Value = "-1",
                    Selected = (selectPayScaleId < 1)
                }
            };

            if (payScaleCollection.Any())
            {
                list.AddRange(payScaleCollection.Select(t => new SelectListItem
                {
                    Text = t.GradeName + " " + t.LevelName,
                    Value = t.PayScaleId.ToString(),
                    Selected = (t.PayScaleId.Equals(selectPayScaleId))
                }));
            }

            return list;
        }

        

    }
}