using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Domain.Utilities;
using AA.Infrastructure.Extensions;
using AA.HRMS.Repositories.DataAccess;

namespace AA.HRMS.Domain.Factories
{
    public class PerformanceManagementViewModelFactory : IPerformanceManagementViewModelFactory
    {
        
        #region //=======================APPRAISAL ACTION=====================//

        /// <summary>
        /// Creates the appraisal action view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public IAppraisalActionView CreateAppraisalActionView(int companyId)
        {
            if (companyId <= 0) throw new ArgumentNullException(nameof(companyId));

            var viewModel = new AppraisalActionView
            {
                CompanyId = companyId
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated appraisal action view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public IAppraisalActionView CreateUpdatedAppraisalActionView(IAppraisalActionView appraisalActionInfo, string processingMessage)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            appraisalActionInfo.ProcessingMessage = processingMessage;

            return appraisalActionInfo;
        }

        /// <summary>
        /// Creates the appraisal action update view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public IAppraisalActionView CreateAppraisalActionUpdateView(IAppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var appraisalActionView = new AppraisalActionView
            {
                AppraisalActionId = appraisalActionInfo.AppraisalActionId,
                AppraisalActionName = appraisalActionInfo.AppraisalActionName,
            };

            return appraisalActionView;
        }

        /// <summary>
        /// Creates the edit appraisal action view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        public IAppraisalActionView CreateEditAppraisalActionView(IAppraisalAction appraisalActionInfo)
        {
            //if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var returnAppraisalAction = new AppraisalActionView
            {
                AppraisalActionId = appraisalActionInfo.AppraisalActionId,
                AppraisalActionName = appraisalActionInfo.AppraisalActionName,
                IsActive = appraisalActionInfo.IsActive
            };
            return returnAppraisalAction;
        }

        #endregion

        #region //================APPRAISAL RATING=========================//

        /// <summary>
        /// Creates the appraisal rating view.
        /// </summary>
        /// <returns></returns>
        public IAppraisalRatingView CreateAppraisalRatingView()
        {
            var viewModel = new AppraisalRatingView();

            return viewModel;
        }
        
        /// <summary>
        /// Creates the updated appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public IAppraisalRatingView CreateUpdatedAppraisalRatingView(IAppraisalRatingView appraisalRatingInfo, string processingMessage)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            appraisalRatingInfo.ProcessingMessage = processingMessage;

            return appraisalRatingInfo;
        }

        /// <summary>
        /// Creates the appraisal rating update view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public IAppraisalRatingView CreateAppraisalRatingUpdateView(IAppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            var appraisalRatingView = new AppraisalRatingView
            {
                AppraisalRatingId = appraisalRatingInfo.AppraisalRatingId,
                AppraisalRatingName = appraisalRatingInfo.AppraisalRatingName,
            };

            return appraisalRatingView;
        }
        
        /// <summary>
        /// Creates the edit appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public IAppraisalRatingView CreateEditAppraisalRatingView(IAppraisalRating appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            var returnAppraisalRating = new AppraisalRatingView
            {
                AppraisalRatingId = appraisalRatingInfo.AppraisalRatingId,
                AppraisalRatingName = appraisalRatingInfo.AppraisalRatingName,
                IsActive = appraisalRatingInfo.IsActive
            };
            return returnAppraisalRating;
        }

        #endregion

        #region //====================================Task Module Section=============================//

        /// <summary>
        /// Creates the appraisal rating view.
        /// </summary>
        /// <param name="employeeTaskCollection"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public IEmployeeTaskListView CreateEmployeeTaskListView(IList<IEmployeeTask> employeeTaskCollection, string processingMessage)
        {
            var viewModel = new EmployeeTaskListView
            {
                EmployeeTaskCollection = employeeTaskCollection,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated appraisal rating view.
        /// </summary>
        /// <param name="employeeTaskViewInfo"></param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskViewInfo</exception>
        public IEmployeeTaskView CreateUpdatedEmployeeTaskView(IEmployeeTaskView employeeTaskViewInfo, string processingMessage)
        {
            if (employeeTaskViewInfo == null) throw new ArgumentNullException(nameof(employeeTaskViewInfo));

            employeeTaskViewInfo.processingMessage = processingMessage;

            return employeeTaskViewInfo;
        }

        /// <summary>
        /// Creates the edit appraisal rating view.
        /// </summary>
        /// <param name="employeeTaskInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskInfo</exception>
        public IEmployeeTaskView CreateEditEmployeeTaskView(IEmployeeTask employeeTaskInfo)
        {
            if (employeeTaskInfo == null) throw new ArgumentNullException(nameof(employeeTaskInfo));

            var returnEmployeeTaskView = new EmployeeTaskView
            {
                TaskId = employeeTaskInfo.TaskId,
                TaskName = employeeTaskInfo.TaskName,
                TaskDescription = employeeTaskInfo.TaskDescription,
                StartDate = employeeTaskInfo.StartDate,
                EndDate = employeeTaskInfo.EndDate,
                IsActive = employeeTaskInfo.IsActive,
                AppraisalGoalId = employeeTaskInfo.AppraisalGoalId,

            };
            return returnEmployeeTaskView;
        }

        /// <summary>
        /// Creates the employee task view.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        public IEmployeeTaskView CreateEmployeeTaskView(int appraisalGoalId)
        {
            var viewModel = new EmployeeTaskView
            {
                AppraisalGoalId = appraisalGoalId
            };

            return viewModel;
        }

        #endregion

        #region //====================APPRAISER====================//

        /// <summary>
        /// Creates the appraiser view.
        /// </summary>
        /// <returns></returns>
        public IAppraiserView CreateAppraiserView()
        {
            var viewModel = new AppraiserView();

            return viewModel;
        }
        
        /// <summary>
        /// Creates the updated appraiser view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public IAppraiserView CreateUpdatedAppraiserView(IAppraiserView appraiserInfo, string processingMessage)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            appraiserInfo.ProcessingMessage = processingMessage;

            return appraiserInfo;
        }
        
        /// <summary>
        /// Creates the appraiser update view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public IAppraiserView CreateAppraiserUpdateView(IAppraiserView appraiserInfo)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            var appraiserView = new AppraiserView
            {
                AppraiserId = appraiserInfo.AppraiserId,
                AppraiserName = appraiserInfo.AppraiserName,
            };

            return appraiserView;
        }
        
        /// <summary>
        /// Creates the edit appraiser view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public IAppraiserView CreateEditAppraiserView(IAppraiser appraiserInfo)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            var returnAppraiser = new AppraiserView
            {
                AppraiserId = appraiserInfo.AppraiserId,
                AppraiserName = appraiserInfo.AppraiserName,
                IsActive = appraiserInfo.IsActive
            };
            return returnAppraiser;
        }

        #endregion
        
        #region //====================APPRAISAL GOAL==============//

        /// <summary>
        /// Creates the appraisal goal view.
        /// </summary>
        /// <param name="Appraisal">The appraisal.</param>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="Appraisee">The appraisee.</param>
        /// <param name="Appraiser">The appraiser.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeAppraisal</exception>
        public IAppraisalGoalView CreateAppraisalGoalView(IAppraisal Appraisal, IEmployeeAppraisal employeeAppraisal, IEmployee Appraisee, IEmployee Appraiser)
        {
            if (employeeAppraisal == null)
            {
                throw new ArgumentNullException(nameof(employeeAppraisal));
            }

            var viewModel = new AppraisalGoalView
            {
                Appraisal = Appraisal,
                Appraisee = Appraisee,
                Appraiser = Appraiser,
                EmployeeAppraisal = employeeAppraisal,
                ProcessingMessage = string.Empty
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the appraisal goal ListView.
        /// </summary>
        /// <param name="appraisalGoalCollection">The appraisal goal collection.</param>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalGoalCollection</exception>
        public IAppraisalGoalListView CreateAppraisalGoalListView(IList<IAppraisalGoal> appraisalGoalCollection, IEmployeeAppraisal employeeAppraisal, string processingMessage)
        {
            if (appraisalGoalCollection == null)
            {
                throw new ArgumentNullException(nameof(appraisalGoalCollection));
            }

            var viewModel = new AppraisalGoalListView
            {
                AppraisalCollection = appraisalGoalCollection,
                EmployeeAppraisal = employeeAppraisal,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated appraisal goal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalGoalView CreateUpdatedAppraisalGoalView(IList<IAppraiser> appraisersCollection, IAppraisalGoalView appraisalGoalInfo, IList<IEmployee> employeeCollection, string processingMessage)
        {

            var appraisersDDL = GetDropDownList.AppraiserListItems(employeeCollection, appraisalGoalInfo.AppraiserId);
            
            appraisalGoalInfo.ProcessingMessage = processingMessage;

            return appraisalGoalInfo;
        }
        
        /// <summary>
        /// Creates the appraisal goal update view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalGoalInfo</exception>
        /// <exception cref="ArgumentException">appraisersCollection</exception>
        public IAppraisalGoalView CreateAppraisalGoalUpdateView(IList<IAppraiser> appraisersCollection, IAppraisalGoalView appraisalGoalInfo, IList<IEmployee> employeecollection, string processingMessage)
        {
            if (appraisalGoalInfo == null) throw new ArgumentNullException(nameof(appraisalGoalInfo));
            if (appraisersCollection == null) throw new ArgumentException(nameof(appraisersCollection));

            var appraisersDDL = GetDropDownList.AppraiserListItems(employeecollection, appraisalGoalInfo.AppraiserId);

            appraisalGoalInfo.ProcessingMessage = processingMessage;

            return appraisalGoalInfo;
        }
        
        /// <summary>
        /// Creates the edit appraisal goal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalGoalInfo
        /// or
        /// appraisersCollection
        /// </exception>
        public IAppraisalGoalView CreateEditAppraisalGoalView(IList<IAppraiser> appraisersCollection, IAppraisalGoal appraisalGoalInfo, IList<IEmployee> employeeCollection, string processingMessage)
        {
            if (appraisalGoalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalGoalInfo));
            }

            if (appraisersCollection == null)
            {
                throw new ArgumentNullException(nameof(appraisersCollection));
            }
            
            var viewModel = new AppraisalGoalView
            {
                Goal = appraisalGoalInfo.Goal,
                Measurements = appraisalGoalInfo.Measurements,
                Outcome = appraisalGoalInfo.Outcome,
                DateCreated = appraisalGoalInfo.DateCreated,
                IsActive = appraisalGoalInfo.IsActive,
                ProcessingMessage = processingMessage,
                AppraisalGoalId = appraisalGoalInfo.AppraisalGoalId,
                EmployeeAppraisalId = appraisalGoalInfo.EmployeeAppraisalId
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the edit appraisal question view.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQuestionInfo</exception>
        public IAppraisalQuestionView CreateEditAppraisalQuestionView(IAppraisalQuestion appraisalQuestionInfo, int companyId, string processingMessage)
        {
            if (appraisalQuestionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestionInfo));
            }


            var viewModel = new AppraisalQuestionView
            {
                AppraisalQuestionId = appraisalQuestionInfo.AppraisalQuestionId,
                CompanyId = companyId,
                Question = appraisalQuestionInfo.Question,
                DateCreated = appraisalQuestionInfo.DateCreated,
                IsActive = appraisalQuestionInfo.IsActive,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the delete appraisal question view.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQuestionInfo</exception>
        public IAppraisalQuestionView CreateDeleteAppraisalQuestionView(IAppraisalQuestion appraisalQuestionInfo, int companyId, string processingMessage)
        {
            if (appraisalQuestionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestionInfo));
            }


            var viewModel = new AppraisalQuestionView
            {
                AppraisalQuestionId = appraisalQuestionInfo.AppraisalQuestionId,
                CompanyId = companyId,
                Question = appraisalQuestionInfo.Question,
                DateCreated = appraisalQuestionInfo.DateCreated,
                IsActive = appraisalQuestionInfo.IsActive,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        #endregion

        #region //=====================================APPRAISAL===============================//

        /// <summary>
        /// Creates the appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalPeriodCollection">The appraisal period collection.</param>
        /// <param name="employeeCollection"></param>
        /// <param name="yearCollection">The year collection.</param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public IAppraisalView CreateAppraisalView(IList<IAppraiser> appraisersCollection,
                                           IList<IAppraisalRating> appraisalRatingsCollection,
                                           IList<IAppraisalAction> appraisalActionsCollection,
                                           IList<IAppraisalPeriod> appraisalPeriodCollection,
                                           IList<IEmployee> employeeCollection,
                                           IList<IYear> yearCollection, int companyId)
        {
            var appraisersDDL = GetDropDownList.AppraiserListItems(employeeCollection, -1);
            var appraisalRatingsDDL = GetDropDownList.AppraisalRatingsListItems(appraisalRatingsCollection, -1);
            var appraisalActionsDDL = GetDropDownList.AppraisalActionsListItems(appraisalActionsCollection, -1);
            var appraisalPeriodDDL = GetDropDownList.AppraisalPeriodListItem(appraisalPeriodCollection, -1);
            var yearDDL = GetDropDownList.Year(yearCollection, -1);


            var viewModel = new AppraisalView
            {
                AppraiserDropDown = appraisersDDL,
                AppraisalRatingDropDown = appraisalRatingsDDL,
                AppraisalRecommendedActionDropDown = appraisalActionsDDL,
                AppraisalFinalRatingDropDown = appraisalRatingsDDL,
                AppraisalApprovedActionDropDown = appraisalActionsDDL,
                AppraisalPeriodDropDownList = appraisalPeriodDDL,
                YearDropDown = yearDDL,
                ProcessingMessage = string.Empty,
                CompanyId = companyId,

            };

            return viewModel;
        }

        /// <summary>
        /// Creates the appraisal question view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IAppraisalQuestionView CreateAppraisalQuestionView(int companyId)
        {
            if (companyId <= 0) throw new ArgumentNullException(nameof(companyId));

            var viewModel = new AppraisalQuestionView
            {
                CompanyId = companyId
            };
             
            return viewModel;
        }

        /// <summary>
        /// Creates the updated appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="companyDetail">The company detail.</param>
        /// <returns></returns>
        public IAppraisalView CreateUpdatedAppraisalView(IAppraisal appraisalInfo, IEmployeeAppraisal employeeAppraisal, IEnumerable<IAppraisalQualitativeMetric> appraisalQualitativeMetric, IEnumerable<IAppraisalQuantitativeMetric> appraisalQuantitativeMetric, IList<IAppraisalQuestion> appraisalQuestion, IList<IAppraisalRating> appraisalRatingsList, 
            IEmployee employeeInfo, ICompanyDetail companyInfo, string processingMessage)
        {

            var appraisalRatingsDDL = GetDropDownList.AppraisalRatingsListItems(appraisalRatingsList, -1);


            if (appraisalInfo.IsOpened)
            {
                foreach (var patch in appraisalQualitativeMetric)
                {
                    
                }
            }
            else
            {
                foreach (var patch in appraisalQualitativeMetric)
                {

                }
            }
            

            var viewModel = new AppraisalView
            {

            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated employee appraisal view.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="employeeQuestionRatings">The employee question ratings.</param>
        /// <param name="appraisalRatings">The appraisal ratings.</param>
        /// <param name="appraisee">The appraisee.</param>
        /// <param name="appraiser">The appraiser.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IAppraisalView CreateUpdatedEmployeeAppraisalView(IEmployeeAppraisal employeeAppraisal, IAppraisal appraisal, IList<IEmployeeQuestionRating> employeeQuestionRatings, 
            IList<IAppraisalRating> appraisalRatings,  IEmployee appraisee, IEmployee appraiser, ICompanyDetail companyInfo, string message)
        {
            var viewModel = new AppraisalView
            {

            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated appraisal question view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalQuestionView CreateUpdatedAppraisalQuestionView(IList<ICompanyDetail> companyCollection,
                                                  IAppraisalQuestionView appraisalInfo,
                                                  string processingMessage)
        {
            
            var viewModel = appraisalInfo;
            viewModel.ProcessingMessage = processingMessage;

            return viewModel;
        }

        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="appraisalPeriodCollection">The appraisal period collection.</param>
        /// <param name="yearCollection">The year collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalView CreateAppraisalUpdateView(IAppraisalView appraisalInfo, IList<IAppraisalPeriod> appraisalPeriodCollection,
            IList<IYear> yearCollection, string processingMessage)
        {

            if (appraisalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalInfo));
            }

            if(appraisalPeriodCollection == null)
            {
                throw new ArgumentNullException(nameof(appraisalPeriodCollection));
            }

            if(yearCollection == null)
            {
                throw new ArgumentNullException(nameof(yearCollection));
            }

            var appraisalDDL = GetDropDownList.AppraisalPeriodListItem(appraisalPeriodCollection, appraisalInfo.AppraisalPeriodId);

            var yearDDL = GetDropDownList.Year(yearCollection, appraisalInfo.AppraisalYearId);

            appraisalInfo.YearDropDown = yearDDL;

            appraisalInfo.AppraisalPeriodDropDownList = appraisalDDL;

            appraisalInfo.ProcessingMessage = processingMessage;

            return appraisalInfo;
            
        }


        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="employeeCollection"></param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalInfo
        /// or
        /// appraisersCollection
        /// or
        /// appraisalRatingsCollection
        /// or
        /// appraisalActionsCollection
        /// </exception>
        public IAppraisalView CreateAppraisalUpdateView(IList<IAppraiser> appraisersCollection,
                                                 IList<IAppraisalRating> appraisalRatingsCollection,
                                                 IList<IAppraisalAction> appraisalActionsCollection,
                                                 IAppraisalView appraisalInfo, IList<IEmployee> employeeCollection,
                                                 string processingMessage)
        {
            if (appraisalInfo == null) throw new ArgumentNullException(nameof(appraisalInfo));
            if (appraisersCollection == null) throw new ArgumentNullException(nameof(appraisersCollection));
            if (appraisalRatingsCollection == null) throw new ArgumentNullException(nameof(appraisalRatingsCollection));
            if (appraisalActionsCollection == null) throw new ArgumentNullException(nameof(appraisalActionsCollection));

            //var appraisersDDL = GetDropDownList.AppraiserListItems(employeeCollection, appraisalInfo.AppraiserId);
            //var appraisalRatingsDDL = GetDropDownList.AppraisalRatingsListItems(appraisalRatingsCollection, appraisalInfo.AppraiserRatingId);
            //var appraisalRecommendedActionsDDL = GetDropDownList.AppraisalActionsListItems(appraisalActionsCollection, appraisalInfo.RecommendedActionId);
            //var appraisalFinalRatingsDDL = GetDropDownList.AppraisalRatingsListItems(appraisalRatingsCollection, appraisalInfo.FinalRatingId);
            //var appraisalApprovedActionsDDL = GetDropDownList.AppraisalActionsListItems(appraisalActionsCollection, appraisalInfo.ApprovedActionId);

            //appraisalInfo.ProcessingMessage = processingMessage;
            //appraisalInfo.AppraiserDropDown = appraisersDDL;
            //appraisalInfo.AppraisalRatingDropDown = appraisalRatingsDDL;
            //appraisalInfo.AppraisalRecommendedActionDropDown = appraisalRecommendedActionsDDL;
            //appraisalInfo.AppraisalFinalRatingDropDown = appraisalFinalRatingsDDL;
            //appraisalInfo.AppraisalApprovedActionDropDown = appraisalApprovedActionsDDL;

            return appraisalInfo;
        }

        /// <summary>
        /// Creates the edit appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalInfo
        /// or
        /// appraisersCollection
        /// or
        /// appraisalRatingsCollection
        /// or
        /// appraisalActionsCollection
        /// </exception>
        public IAppraisalView CreateEditAppraisalView(IAppraisal appraisal, IEmployeeAppraisal employeeAppraisal, IList<IAppraisalQualitativeMetric> appraisalQualitativeMetric, IList<IAppraisalQuantitativeMetric> appraisalQuantitativeMetric, IList<IEmployeeAppraisal> employeeAppraisalCollection, 
            IList<IAppraisalQuestion> appraisalQuestions, IEmployee appraiseeInfo, IEmployee appraiserInfo, IUserDetail user, IList<IAppraisalRating> appraisalRatingCollection, 
            IList<IEmployeeQuestionRating> employeeQuestionRatings, IList<IAppraisalGoal> appraisalGoalCollection, IList<IResult> resultCollection)
        {
            if (appraisal == null)
            {
                throw new ArgumentNullException(nameof(appraisal));
            }

            if (employeeAppraisalCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeAppraisalCollection));
            }

            if (appraisalQuestions == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestions));
            }
            
            if (appraiseeInfo == null)
            {
                throw new ArgumentNullException(nameof(appraiseeInfo));
            }
            
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            foreach (var item in employeeAppraisalCollection)
            {
                appraisalQuestions.Where(x=>appraisalQuestions.Equals(x.AppraisalQuestionId));
            }

            foreach (var pappi in appraisalQualitativeMetric)
            {
                pappi.ResultDropDown = GetDropDownList.ResultListItem(resultCollection, pappi.ResultId);
            }

            foreach (var mammi in appraisalQuantitativeMetric)
            {
                mammi.ResultDropDown = GetDropDownList.ResultListItem(resultCollection, mammi.ResultId);
            }


            var appraisalRatingDDL = GetDropDownList.AppraisalRatingsListItems(appraisalRatingCollection, -1);
            var resultDDL = GetDropDownList.ResultListItem(resultCollection, -1);
            
            var viewModel = new AppraisalView
            {
                AppraisalId = appraisal.AppraisalId,
                CompanyId = appraisal.CompanyId,
                DateInitiated = appraisal.DateInitiated,
                AppraisalPeriodName = appraisal.AppraisalPeriodName,
                AppraisalYearName = appraisal.AppraisalYearName,
                AppraisalQuestions = appraisalQuestions,
                AppraisalRatingDropDown = appraisalRatingDDL,
                Appraisee = appraiseeInfo,
                Appraiser = appraiserInfo,
                IsOpened = appraisal.IsOpened,
                EmployeeAppraisal = employeeAppraisal,
                EmployeeQuestionAppraisalCollection = employeeQuestionRatings,
                AppraiseeRatingCollection = appraisalRatingCollection,
                AppraisalGoalCollection = appraisalGoalCollection,
                ResultDropDown = resultDDL,
                ResultCollection = resultCollection,
                AppraisalQualitativeMetric = appraisalQualitativeMetric,
                AppraisalQuantitativeMetric = appraisalQuantitativeMetric
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the delete appraisal view.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="comapny">The comapny.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisal
        /// or
        /// comapny
        /// </exception>
        public IAppraisalView CreateDeleteAppraisalView(IAppraisal appraisal, ICompanyDetail comapny)
        {
            if (appraisal == null)
            {
                throw new ArgumentNullException(nameof(appraisal));
            }

            if (comapny == null)
            {
                throw new ArgumentNullException(nameof(comapny));
            }

            var viewModel = new AppraisalView
            {
                AppraisalId = appraisal.AppraisalId,
                CompanyId = appraisal.CompanyId,
                AppraisalYearName = appraisal.AppraisalYearName,
                AppraisalPeriodName = appraisal.AppraisalPeriodName
            };

            return viewModel;
        }


        /// <summary>
        /// Creates the employee appraisal request view.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public IAppraisalView CreateEmployeeAppraisalRequestView(IList<IAppraisal> appraisal, IList<ICompanyDetail> companyCollection, IList<IEmployee> employee, int employeeId)
        {

            var AppraisalDDL = GetDropDownList.AppraisalListItems(appraisal, -1);
            var EmployeeDDL = GetDropDownList.EmployeeListitems(employee, -1);
            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);


            var model = new AppraisalView
            {
                CompanyDropDownList = companyDDL,
                //EmployeeDropDownList = EmployeeDDL,
                ProcessingMessage = string.Empty,
                //EmployeeId = employeeId


            };
            return model;
        }

        /// <summary>
        /// Creates the specific employee appraisal view.
        /// </summary>
        /// <param name="appraisalCollection">The appraisal collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="company">The company.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalListView CreateSpecificEmployeeAppraisalView(IList<IEmployeeAppraisal> appraisalCollection, IEmployee employee, IEmployee supervisor, ICompanyDetail company,int employeeId, string processingMessage)
        {
         
            var viewModel = new AppraisalListView
            {
                EmployeeAppraisalCollection  = appraisalCollection,
                ProcessingMessage = string.Empty,
                EmployeeId = employeeId,
                Supervisor = supervisor,
                Employee = employee,
                Company = company
               
            };
            return viewModel;
        }

        /// <summary>
        /// Creates the specific employee appraisal view.
        /// </summary>
        /// <param name="appraisalCollection">The appraisal collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="company">The company.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeAppraisalListView CreateSpecificEmployeeAppraisalView(IList<IEmployeeAppraisal> appraisalCollection, IEmployee employee, ICompanyDetail company, string processingMessage)
        {

            var viewModel = new EmployeeAppraisalListView
            {
                EmployeeAppraisalCollection = appraisalCollection,
                ProcessingMessage = string.Empty,
                Employee = employee,
                Company = company

            };
            return viewModel;
        }

        /// <summary>
        /// Gets the appraisal action ListView.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">AppraisalList Cannot Be Null</exception>
        public IAppraisalActionView GetAppraisalActionListView(IList<IAppraisalAction> appraisal, string ProcessingMessage)
        {
            if (appraisal == null)
            {
                throw new ArgumentNullException("AppraisalList Cannot Be Null");
            }



            var view = new AppraisalActionView
            {
                appraisal = appraisal,
                ProcessingMessage = ProcessingMessage ?? ""
            };
            return view;
        }

        /// <summary>
        /// Gets the appraisal question ListView.
        /// </summary>
        /// <param name="appraisalQuestionView">The appraisal question view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQuestionView</exception>
        public IAppraisalQuestionListView GetAppraisalQuestionListView(IList<IAppraisalQuestion> appraisalQuestionView, string processingMessage)
        {
            if (appraisalQuestionView == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestionView));
            }

            var view = new AppraisalQuestionListView
            {
                appraisalquestion = appraisalQuestionView,
                ProcessingMessage = processingMessage ?? ""
            };
            return view;
        }

        /// <summary>
        /// Gets the appraisal ListView.
        /// </summary>
        /// <param name="appraisalView">The appraisal view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalView</exception>
        public IAppraisalListView GetAppraisalListView(IList<IAppraisal> appraisalView, string processingMessage)
        {
            if (appraisalView == null)
            {
                throw new ArgumentNullException(nameof(appraisalView));
            }
             
            var view = new AppraisalListView 
            {
                appraisal = appraisalView,
                ProcessingMessage = processingMessage ?? ""
            };
            return view;
        }

        /// <summary>
        /// Gets the employee appraisal ListView.
        /// </summary>
        /// <param name="employeeAppraisalView">The employee appraisal view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeAppraisalView</exception>
        public IAppraisalView GetEmployeeAppraisalListView(IList<IEmployeeAppraisal> employeeAppraisalView, string processingMessage)
        {
            if (employeeAppraisalView == null)
            {
                throw new ArgumentNullException(nameof(employeeAppraisalView));
            }

            var view = new AppraisalView
            {
                EmployeeAppraisalCollection = employeeAppraisalView,
                ProcessingMessage = processingMessage ?? ""
            };
            return view;
        }

        /// <summary>
        /// Creates the employee appraisal request view.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        public IAppraisalView CreateEmployeeAppraisalRequestView(IList<IAppraisal> appraisal, IList<ICompanyDetail> companyCollection, IList<IEmployee> employee, IEmployee employeeModel)
        {
           
            var EmployeeDDL = GetDropDownList.EmployeeListitems(employee, -1);
            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);


            var model = new AppraisalView
            {
                CompanyDropDownList = companyDDL,
                //EmployeeDropDownList = EmployeeDDL,
                ProcessingMessage = string.Empty,
                //EmployeeId = employeeModel.EmployeeId,
                CompanyId = employeeModel.CompanyId,


            };
            return model;
        }

        /// <summary>
        /// Creates the employee appraisal view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalInfo
        /// or
        /// appraisalInfo
        /// or
        /// appraisal
        /// or
        /// companyCollection
        /// </exception>
        public IAppraisalView CreateEmployeeAppraisalView(IAppraisalView appraisalInfo, int companyId, IList<IAppraisal> appraisal, IList<IEmployee> employee, string processingMessage)
        {
            if (appraisalInfo == null) throw new ArgumentNullException(nameof(appraisalInfo));

            if (appraisalInfo == null) throw new ArgumentNullException(nameof(appraisalInfo));

            if (appraisal == null) throw new ArgumentNullException(nameof(appraisal));

            appraisalInfo.CompanyId = companyId;
            

            appraisalInfo.ProcessingMessage = processingMessage;

            return appraisalInfo;
        }

        /// <summary>
        /// Gets the employee feedback ListView.
        /// </summary>
        /// <param name="employDetails">The employ details.</param>
        /// <param name="feedbackCollection">The feedback collection.</param>
        /// <param name="EmployeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeFeedbackView GetEmployeeFeedbackListView(IList<IEmployee> employDetails, IList<IEmployeeFeedbackModel> feedbackCollection, int EmployeeId, string message)
        {
            
            var returnView = new EmployeeFeedbackView
            {
                feedbackList = feedbackCollection,
                EmployeeId = EmployeeId,
                ProcessingMessages = message,
            
            };
            return returnView;

        }

        /// <summary>
        /// Creates the employee feedback view.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <param name="employeeList">The employee list.</param>
        /// <returns></returns>
        public IEmployeeFeedbackViewModel CreateEmployeeFeedbackView(IEmployee employee, int feedbackId, IList<IEmployee> employeeList)

        {
            var IdentifierCollection = employeeList.Where(x => x.EmployeeId != employee.EmployeeId).ToList();
            var employeeListDDL = GetDropDownList.EmployeeListitems(IdentifierCollection, -1);

            var viewModel = new EmployeeFeedbackViewModel
            {
                CompanyId = employee.CompanyId,
                EmployeeId = employee.EmployeeId,
                FeedbackId = feedbackId,
                EmployeeList = employeeListDDL,
               
            };

            return viewModel;
        }
        
        #endregion

        #region //===========================================Annual Assessing Performance==========================//

        /// <summary>
        /// Creates the annual performance ListView.
        /// </summary>
        /// <param name="annualAssesingPerformanceCollection">The annual assesing performance collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">annualAssesingPerformanceCollection</exception>
        public IAnnualAssessingPerformanceListView CreateAnnualPerformanceListView(IList<IAnnualAssesingPerformance> annualAssesingPerformanceCollection, string processingMessage)
        {
            if (annualAssesingPerformanceCollection == null)
            {
                throw new ArgumentNullException(nameof(annualAssesingPerformanceCollection));
            }




            var result = new AnnualAssessingPerformanceListView
            {
                AnnualAssesingPerformanceCollection = annualAssesingPerformanceCollection,
                ProcessingMessage = processingMessage
            };

            return result;
        }
        
        /// <summary>
        /// Creates the annual performance view.
        /// </summary>
        /// <param name="yearsCollection">The years collection.</param>
        /// <returns></returns>
        public IAnnualAssessingPerformanceView CreateAnnualPerformanceView(IUserDetail user, IList<IYear> yearsCollection)
        {

            var yearDDL = GetDropDownList.Year(yearsCollection, -1);

            var result = new AnnualAssessingPerformanceView
            {
                YearDropDown = yearDDL,
                ProcessingMessage = string.Empty,
                User = user
                
            };

            return result;
        }

        /// <summary>
        /// Creates the annual performance view.
        /// </summary>
        /// <param name="annualAssessingPerformanceView">The annual assessing performance view.</param>
        /// <param name="yearsCollection">The years collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAnnualAssessingPerformanceView CreateAnnualPerformanceView(IAnnualAssessingPerformanceView annualAssessingPerformanceView, IUserDetail user, IList<IYear> yearsCollection, string processingMessage)
        {

            var yearDDL = GetDropDownList.Year(yearsCollection, annualAssessingPerformanceView.YearId);

            annualAssessingPerformanceView.User = user;
            annualAssessingPerformanceView.YearDropDown = yearDDL;
            annualAssessingPerformanceView.ProcessingMessage = processingMessage;

            return annualAssessingPerformanceView;
        }

        #endregion

        #region //===========================================================Employee Annual Performance Assessment Start================================================================//

        /// <summary>
        /// Creates the employee annual assessing performance ListView.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformanceCollection">The employee annual assessing performance collection.</param>
        /// <param name="">The .</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeAnnualAssessingPerformanceListView CreateEmployeeAnnualAssessingPerformanceListView(IList<IEmployeeAnnualAssessingPerformance> employeeAnnualAssessingPerformanceCollection, string message)
        {

            if (employeeAnnualAssessingPerformanceCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeAnnualAssessingPerformanceCollection));
            }

            var result = new EmployeeAnnualAssessingPerformanceListView
            {
                EmployeeAnnualAssessingPerformance = employeeAnnualAssessingPerformanceCollection,
                ProcessingMessage = message,
            };

            return result;

        }

        /// <summary>
        /// Creates the employee annual performance view.
        /// </summary>
        /// <param name="annualPerformanceAssessmentInfo">The annual performance assessment information.</param>
        /// <param name="revieweeInfo">The reviewee information.</param>
        /// <param name="reviewerInfo">The reviewer information.</param>
        /// <param name="ratingCollection">The rating collection.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// annualPerformanceAssessmentInfo
        /// or
        /// revieweeInfo
        /// or
        /// ratingCollection
        /// or
        /// companyInfo
        /// </exception>
        public IEmployeeAnnualAssessingPerformanceView CreateEmployeeAnnualPerformanceView(IAnnualAssesingPerformance annualPerformanceAssessmentInfo, IEmployee revieweeInfo, IEmployee reviewerInfo, IList<IAppraisalRating> ratingCollection, ICompanyDetail companyInfo)
        {

            if (annualPerformanceAssessmentInfo == null)
            {
                throw new ArgumentNullException(nameof(annualPerformanceAssessmentInfo));
            }

            if (revieweeInfo == null)
            {
                throw new ArgumentNullException(nameof(revieweeInfo));
            }

            if (ratingCollection == null)
            {
                throw new ArgumentNullException(nameof(ratingCollection));
            }

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var revieweeRatingDDL = GetDropDownList.AppraisalRatingsListItems(ratingCollection, -1);

            var result = new EmployeeAnnualAssessingPerformanceView
            {
                AnnualAssesingPerformance = annualPerformanceAssessmentInfo,
                RevieweeRatingDropDown = revieweeRatingDDL,
                Reviewee = revieweeInfo,
                Reviewer = reviewerInfo,
                Company = companyInfo,
                RatingColletion = ratingCollection
            };


            return result;
        }

        /// <summary>
        /// Creates the employee annual performance view.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <param name="annualPerformanceAssessmentInfo">The annual performance assessment information.</param>
        /// <param name="revieweeInfo">The reviewee information.</param>
        /// <param name="reviewerInfo">The reviewer information.</param>
        /// <param name="ratingCollection">The rating collection.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// annualPerformanceAssessmentInfo
        /// or
        /// revieweeInfo
        /// or
        /// ratingCollection
        /// or
        /// companyInfo
        /// </exception>
        public IEmployeeAnnualAssessingPerformanceView CreateEmployeeAnnualPerformanceView(IEmployeeAnnualAssessingPerformance employeeAnnualAssessingPerformance, IAnnualAssesingPerformance annualPerformanceAssessmentInfo, IEmployee revieweeInfo, IEmployee reviewerInfo, IList<IAppraisalRating> ratingCollection, ICompanyDetail companyInfo)
        {

            if (annualPerformanceAssessmentInfo == null)
            {
                throw new ArgumentNullException(nameof(annualPerformanceAssessmentInfo));
            }

            if (revieweeInfo == null)
            {
                throw new ArgumentNullException(nameof(revieweeInfo));
            }

            if (ratingCollection == null)
            {
                throw new ArgumentNullException(nameof(ratingCollection));
            }

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var revieweeRatingDDL = GetDropDownList.AppraisalRatingsListItems(ratingCollection, employeeAnnualAssessingPerformance.RevieweeRatingId);
            var reviewerRatingDDL = GetDropDownList.AppraisalRatingsListItems(ratingCollection, employeeAnnualAssessingPerformance.ReviewerRatingId);
            var finalRatingDDL = GetDropDownList.AppraisalRatingsListItems(ratingCollection, employeeAnnualAssessingPerformance.FinalRatingId);

            var result = new EmployeeAnnualAssessingPerformanceView
            {
                EmployeeAnnualAssesssingPerformanceId = employeeAnnualAssessingPerformance.EmployeeAnnualAssesssingPerformanceId,
                AnnualAssessingPerformanceId = employeeAnnualAssessingPerformance.AnnualAssessingPerformanceId,
                CompanyId = employeeAnnualAssessingPerformance.CompanyId,

                Thing_I_Did_Well = employeeAnnualAssessingPerformance.Thing_I_Did_Well,
                Things_I_Did_Not_Do_Well = employeeAnnualAssessingPerformance.Things_I_Did_Not_Do_Well,
                Driven_Exceptional_Client_Service = employeeAnnualAssessingPerformance.Driven_Exceptional_Client_Service,
                Highest_Performing_Teams = employeeAnnualAssessingPerformance.Highest_Performing_Teams,
                Examples_Of_Living_Our_Values = employeeAnnualAssessingPerformance.Examples_Of_Living_Our_Values,
                Enhanced_Quality_And_Effective_Risk_Management = employeeAnnualAssessingPerformance.Enhanced_Quality_And_Effective_Risk_Management,
                
                RevieweeRatingId = employeeAnnualAssessingPerformance.RevieweeRatingId,
                ReviewerRatingId = employeeAnnualAssessingPerformance.ReviewerRatingId,
                FinalRatingId = employeeAnnualAssessingPerformance.FinalRatingId,
                
                RevieweeRatingDropDown = revieweeRatingDDL,
                ReviewerRatingDropDown = reviewerRatingDDL,
                FinalRatingDropDown = finalRatingDDL,

                RevieweeId = employeeAnnualAssessingPerformance.RevieweeId,
                ReviewerId = employeeAnnualAssessingPerformance.ReviewerId,
                FinalReviewerId = employeeAnnualAssessingPerformance.FinalReviewerId,

                ReviewerComment = employeeAnnualAssessingPerformance.ReviewerComment,
                FinalRatingComment = employeeAnnualAssessingPerformance.FinalRatingComment,

                DateOfReviewee = employeeAnnualAssessingPerformance.DateOfReviewee,
                DateOfReviewer = employeeAnnualAssessingPerformance.DateOfReviewer,
                DateOfFinalReview = employeeAnnualAssessingPerformance.DateOfFinalReview,

                AnnualAssesingPerformance = annualPerformanceAssessmentInfo,
                Reviewee = revieweeInfo,
                Reviewer = reviewerInfo,
                Company = companyInfo,

                RatingColletion = ratingCollection
            };


            return result;
        }

        /// <summary>
        /// Creates the employee annual performance view.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <param name="annualPerformanceAssessmentInfo">The annual performance assessment information.</param>
        /// <param name="revieweeInfo">The reviewee information.</param>
        /// <param name="reviewerInfo">The reviewer information.</param>
        /// <param name="ratingCollection">The rating collection.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// annualPerformanceAssessmentInfo
        /// or
        /// revieweeInfo
        /// or
        /// ratingCollection
        /// or
        /// companyInfo
        /// </exception>
        public IEmployeeAnnualAssessingPerformanceView CreateEmployeeAnnualPerformanceView(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance, IAnnualAssesingPerformance annualPerformanceAssessmentInfo, IEmployee revieweeInfo, IEmployee reviewerInfo, IList<IAppraisalRating> ratingCollection, ICompanyDetail companyInfo)
        {

            if (annualPerformanceAssessmentInfo == null)
            {
                throw new ArgumentNullException(nameof(annualPerformanceAssessmentInfo));
            }

            if (revieweeInfo == null)
            {
                throw new ArgumentNullException(nameof(revieweeInfo));
            }

            if (ratingCollection == null)
            {
                throw new ArgumentNullException(nameof(ratingCollection));
            }

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var revieweeRatingDDL = GetDropDownList.AppraisalRatingsListItems(ratingCollection, -1);

            employeeAnnualAssessingPerformance.RevieweeRatingDropDown = revieweeRatingDDL;

            employeeAnnualAssessingPerformance.Company = companyInfo;

            employeeAnnualAssessingPerformance.Reviewee = revieweeInfo;

            employeeAnnualAssessingPerformance.Reviewer = reviewerInfo;

            employeeAnnualAssessingPerformance.AnnualAssesingPerformance = annualPerformanceAssessmentInfo;
            
            return employeeAnnualAssessingPerformance;
        }


        #endregion

        #region //=============================================Feedback Section=============================================//

        /// <summary>
        /// Creates the employee feedback view by identifier.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <param name="employeeList">The employee list.</param>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public IEmployeeFeedbackViewModel CreateEmployeeFeedbackViewByID(int feedbackId, IList<IEmployee> employeeList, IEmployee employee)

        {

            var Identifier = employeeList.Where(x => x.EmployeeId != employee.EmployeeId).ToList();

            var employeeListDDL = GetDropDownList.EmployeeListitems(Identifier, -1);


            var viewModel = new EmployeeFeedbackViewModel
            {
                FeedbackId  = feedbackId,
                EmployeeId = employee.EmployeeId,
                CompanyId = employee.CompanyId,
                ProcessingMessage = string.Empty,
                EmployeeList = employeeListDDL,               
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the view employee feedback.
        /// </summary>
        /// <param name="employeeFeedback">The employee feedback.</param>
        /// <param name="employeeList">The employee list.</param>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public IEmployeeFeedbackViewModel CreateViewEmployeeFeedback(IEmployeeFeedbackModel employeeFeedback, IList<IEmployee> employeeList, IEmployee employee)

        {
            
            var employeeListDDL = GetDropDownList.EmployeeListitems(employeeList, employeeFeedback.FeedbackOnEmployeeId);


            var viewModel = new EmployeeFeedbackViewModel
            {
                EmployeeFeedbackId = employeeFeedback.EmployeeFeedbackId,
                EmployeeId = employeeFeedback.EmployeeId,
                FeedbackOnEmployeeId = employeeFeedback.FeedbackOnEmployeeId,
                FeedbackId = employeeFeedback.FeedbackId,
                Experience = employeeFeedback.Experience,
                WhatAreas = employeeFeedback.WhatAreas,
                InWhatContext = employeeFeedback.InWhatContext,
                ProvideOverview = employeeFeedback.ProvideOverview,
                CompanyId = employeeFeedback.CompanyId,
                DateCreated = employeeFeedback.DateCreated,
                DateOfFeedback = employeeFeedback.DateOfFeedback,
                IsActive = employeeFeedback.IsActive,
                ProcessingMessage = string.Empty,
                EmployeeList = employeeListDDL,
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the employee feedback view by identifier.
        /// </summary>
        /// <param name="employeeFeedback">The employee feedback.</param>
        /// <param name="employeeList">The employee list.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeFeedbackViewModel CreateEmployeeFeedbackViewByID(IEmployeeFeedbackViewModel employeeFeedback, IList<IEmployee> employeeList, string message)

        {

            var Identifier = employeeList.Where(x => x.EmployeeId != employeeFeedback.EmployeeId).ToList();

            var employeeListDDL = GetDropDownList.EmployeeListitems(Identifier, employeeFeedback.FeedbackOnEmployeeId);

            employeeFeedback.EmployeeList = employeeListDDL;
            employeeFeedback.ProcessingMessage = message;

            return employeeFeedback;
        }
        
        /// <summary>
        /// Creates the feedback view.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">year</exception>
        public IFeedbackViewModel CreateFeedbackView(IList<IYear> year, ICompanyDetail companyCollection, string processingMessage)
        {
            if (year == null) throw new ArgumentNullException(nameof(year));



            //var EmployeeDDL = GetDropDownList.EmployeeListitems(employee, appraisalInfo.EmployeeId);
            var yearDDL = GetDropDownList.Year(year, -1);

            var feedbackViewModel = new FeedbackViewModel
            {
              YearDropDownList = yearDDL,
              ProcessingMessage = processingMessage,
              CompanyId = companyCollection.CompanyId,
              
            };
          
            return feedbackViewModel;
        }

        /// <summary>
        /// Creates the feedback view.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">year</exception>
        public IFeedbackViewModel CreateFeedbackView(IFeedbackModel feed, IList<IYear> year, ICompanyDetail companyInfo, string processingMessage)
        {
            if (year == null) throw new ArgumentNullException(nameof(year));

            if (feed == null) throw new ArgumentNullException(nameof(feed));

            if (companyInfo == null) throw new ArgumentNullException(nameof(companyInfo));

            var yearDDL = GetDropDownList.Year(year, -1);

            var feedbackViewModel = new FeedbackViewModel
            {
                YearDropDownList = yearDDL,
                ProcessingMessage = processingMessage,
                CompanyId = companyInfo.CompanyId,
                FeedbackId = feed.FeedbackId,
                YearId = feed.YearId,
                IsLock = feed.IsLock,
                NoOfFeedback = feed.noOfFeedbacks,

            };

            return feedbackViewModel;
        }

        /// <summary>
        /// Creates the feed back view.
        /// </summary>
        /// <param name="feedbackModel">The feedback model.</param>
        /// <param name="company">The company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IFeedbackListview CreateFeedBackView(IList<IFeedbackModel> feedbackModel , IList<ICompanyDetail> company, string processingMessage)
        {
            
            var viewModel = new FeedbackListview
            {
                feedbackModel = feedbackModel,
                ProcessingMessage = processingMessage,
                companyDetail = company,
                //yearCollection = year,
                //employeeFeedback = employeeFeedbackModel

            };
            return viewModel;
        }


        #endregion

        #region //=======================================Milestone Section==============================================//

        /// <summary>
        /// Creates the task mile stone list.
        /// </summary>
        /// <param name="milestoneCollection">The milestone collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">milestoneCollection</exception>
        public IMilestoneListView CreateTaskMileStoneList(IList<IMilestone> milestoneCollection, string processingMessage)
        {
            if (milestoneCollection == null) throw new ArgumentNullException(nameof(milestoneCollection));

            var returnModel = new MilestoneListView
            {
                MilestoneCollection = milestoneCollection,
                ProcessingMessage = processingMessage
            };

            return returnModel;
        }

        #endregion

    }
}