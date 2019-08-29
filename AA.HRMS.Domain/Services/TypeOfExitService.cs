using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AA.HRMS.Domain.Services
{
    public class TypeOfExitService : ITypeOfExitService

    {
        private readonly ITypeOfExitViewModelFactory typeOfExitViewModelFactory;
        private readonly ITypeOfExitRepository typeOfExitRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IGenerateDocumentService generateDocumentService;
        private readonly ISessionStateService session;
        
        public TypeOfExitService(ITypeOfExitViewModelFactory typeOfExitViewModelFactory, ILookupRepository lookupRepository, ISessionStateService session,
            ITypeOfExitRepository typeOfExitRepository, ICompanyRepository companyRepository, IUsersRepository usersRepository)
        {
            this.typeOfExitViewModelFactory = typeOfExitViewModelFactory;
            this.typeOfExitRepository = typeOfExitRepository;
            this.lookupRepository = lookupRepository;
            this.companyRepository = companyRepository;
            this.usersRepository = usersRepository;
            this.session = session;
        }

        /// <summary>
        /// Creates the type of exit list.
        /// </summary>
        /// <param name="selectedTypeOfExitID">The selected type of exit identifier.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public ITypeOfExitListView CreateTypeOfExitList(int? selectedTypeOfExitID, string selectedCompany, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById(userInfo.CompanyId);

            var companyIdSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo.Username);

            var typeOfExitCollection = lookupRepository.GetTypeOfExitByCompanyId(companyIdSession);
            
            var typeOfExitList =
                this.typeOfExitViewModelFactory.CreateTypeOfExitListView( typeOfExitCollection, companyInfo, processingMessage);

            return typeOfExitList;
        }

        /// <summary>
        /// Gets the type of exit registration view.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public ITypeOfExitView GetTypeOfExitRegistrationView()
        {
            
            var loggedUserDetails = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            var employeeCollection = this.lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var typeOfExitCollection = this.typeOfExitRepository.GetAllMyTypeOfExit(companyInfo.CompanyId);

            var CompanyCollection = this.companyRepository.GetCompaniesForHR(loggedUserDetails.Username);

            var ExitType = this.typeOfExitRepository.GetTypeOfExitByName(loggedUserDetails.Username);

            var viewModel = this.typeOfExitViewModelFactory.CreateTypeOfExitView(companyInfo.CompanyId, typeOfExitCollection, employeeCollection, ExitType, "");

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="typeOfExitInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">typeOfExitInfo</exception>
        public string ProcessTypeOfExitInfo(ITypeOfExitView typeOfExitInfo)
        {
            if (typeOfExitInfo == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitInfo));
            }

            var processingMessage = string.Empty;

            bool isData = true;

            isData = ((this.typeOfExitRepository.GetTypeOfExitByName(typeOfExitInfo.TypeOfExitName)) == null) ? true : false;

            if (!isData)
            {
                processingMessage = Messages.ExitTypeAlreayExist;

                return processingMessage;
            }


            processingMessage = this.typeOfExitRepository.SaveTypeOfExitInfo(typeOfExitInfo);

            return processingMessage;
        }

        /// <summary>
        /// Processes the edit type of exit information.
        /// </summary>
        /// <param name="typeOfExitInfo">The type of exit information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">typeOfExitInfo</exception>
        public string ProcessEditTypeOfExitInfo(ITypeOfExitView typeOfExitInfo)
        {
            if (typeOfExitInfo == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitInfo));
            }

            var processingMessage = string.Empty;

            bool isData = true;

            isData = ((this.typeOfExitRepository.GetTypeOfExitByName(typeOfExitInfo.TypeOfExitName)) == null) ? true : false;

            if (!isData)
            {
                processingMessage = Messages.ExitTypeAlreayExist;

                return processingMessage;
            }



            processingMessage = this.typeOfExitRepository.SaveEditTypeOfExitInfo(typeOfExitInfo);

            return processingMessage;
        }
        
        /// <summary>
        /// Processes the delete type of exit information.
        /// </summary>
        /// <param name="TypeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExitId</exception>
        public string ProcessDeleteTypeOfExitInfo(int TypeOfExitId)
        {
            if (TypeOfExitId <= 0)
            {
                throw new ArgumentNullException(nameof(TypeOfExitId));
            }

            var result = this.typeOfExitRepository.SaveDeleteTypeOfExitInfo(TypeOfExitId);

            return result;
        }

        /// <summary>
        /// Gets the type of exit edit view.
        /// </summary>
        /// <param name="TypeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExitId</exception>
        public ITypeOfExitView GetTypeOfExitEditView(int TypeOfExitId)
        {
            if(TypeOfExitId <= 0)
            {
                throw new ArgumentNullException(nameof(TypeOfExitId));
            }

            var TypeOfExit = this.typeOfExitRepository.GetTypeOfExitByID(TypeOfExitId);

            var viewModel = this.typeOfExitViewModelFactory.CreateEditTypeOfExitView(TypeOfExit);

            return viewModel;
        }

        /// <summary>
        /// Gets the type of exit update view.
        /// </summary>
        /// <param name="TypeOfExit">The type of exit.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExit</exception>
        public ITypeOfExitView GetTypeOfExitUpdateView(ITypeOfExitView TypeOfExit, string processingMessage)
        {
            if (TypeOfExit == null)
            {
                throw new ArgumentNullException(nameof(TypeOfExit));
            }

            var viewModel = this.typeOfExitViewModelFactory.CreateTypeOfExitUpdateView(TypeOfExit, processingMessage);

            return viewModel;
        }

        public string ProcessUploadExceltypeOfExit(HttpPostedFileBase typeOfExitExcelFile)
        {
            throw new NotImplementedException();
        }

        //    ProcessUploadExceltypeOfExit(HttpPostedFileBase typeOfExitExcelFile)
        //    {

        //    if (typeOfExitExcelFile == null) throw new ArgumentNullException(nameof(typeOfExitExcelFile));

        //    var result = string.Empty;

        //    var typeOfExitCollection = this.generateDocumentService.ExcelUpload(typeOfExitExcelFile);

        //    foreach (DataRow r in typeOfExitCollection.Rows)
        //    {
        //        var typeOfExitView = new TypeOfExitView();

        //        typeOfExitView.TypeOfExitName= r.ItemArray[0].ToString();
        //        typeOfExitView.CompanyId = (int)session.GetSessionValue(SessionKey.CompanyId);

        //        var isDataOkay = (typeOfExitRepository.GetTypeOfExitByName(typeOfExitView.TypeOfExitName) == null) ? true : false;
        //        var grade = typeOfExitRepository.GetTypeOfExitByName(typeOfExitView.TypeOfExitName);
        //        if (!isDataOkay)
        //        {
        //            result = Messages.TypeOfExitAlreadyExisted;
        //            return result;
        //        }

        //        result = this.typeOfExitRepository.SaveTypeOfExitInfo(typeOfExitView);


        //        if (!string.IsNullOrEmpty(result)) return result;

        //    }

        //    return result;
        //}
    }
}
