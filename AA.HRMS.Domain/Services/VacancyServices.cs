using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Services
{
    public class VacancyServices : IVacancyService
    {
        private readonly IVacancyRepository vacancyRepository;
        private readonly IVacancyViewModelFactory vacancyViewModelFactory;

        public VacancyServices(IVacancyRepository vacancyRepository, IVacancyViewModelFactory vacancyViewModelFactory)
        {
            this.vacancyRepository = vacancyRepository;
            this.vacancyViewModelFactory = vacancyViewModelFactory;
        }

        public IVacancyView GetVacancyView()
        {
            var viewModel = this.vacancyViewModelFactory.CreateVacancyView();

            return viewModel;
        }

        public IVacancyView ProcessVacancyInfo(IVacancyView vacancyInfo)
        {
            if(vacancyInfo == null)
            {
                throw new System.ArgumentNullException(nameof(vacancyInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            var vacancyData = this.vacancyRepository.GetVacancyByCompany(vacancyInfo.CompanyId, vacancyInfo.DepartmentId, vacancyInfo.JobTitleId, vacancyInfo.GradeId);
            var isRecordExist = (vacancyData == null) ? false : true;

            if (isRecordExist)
            {
                processingMessage = Messages.VacancyAlreadyExistText;
                isDataOkay = false;
            }

            var returnViewModel = this.vacancyViewModelFactory.CreateUpdatedVacancyView(vacancyInfo, processingMessage);

            if (!isDataOkay)
            {
                return returnViewModel;
            }

            var saveData = this.vacancyRepository.SaveRegistrationInfo(vacancyInfo);

            

            return returnViewModel;

        }
    }
}
