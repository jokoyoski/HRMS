using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Queries
{
    internal static class CompanyQueries
    {
        internal static IEnumerable<ICompanyDetail> getCompanyList(HRMSEntities db)
        {
            var result = (from d in db.Companies
                          select new CompanyRegistrationModel
                          {
                              CompanyId = d.CompanyId,
                              CompanyAddressLine1 = d.CompanyAddressLine1,
                              CompanyAddressLine2 = d.CompanyAddressLine2,
                              CompanyCity = d.CompanyCity,
                              IsActive = d.IsActive,
                              CompanyEmail = d.CompanyEmail,
                              CompanyAlias = d.CompanyAlias,
                              CompanyCountryId = d.CompanyCountryId,

                              DateCreated = d.DateCreated,
                              LogoDigitalFileId = d.LogoDigitalFileId,
                              CompanyName = d.CompanyName,
                              CompanyPhone = d.CompanyPhone,
                              CompanyState = d.CompanyState,
                              CompanyWebsite = d.CompanyWebsite,
                              CompanyZipCode = d.CompanyZipCode,
                              ParentCompanyId = d.ParentCompanyId,

                              CACRegistrationNumber = d.CACRegistrationNumber
                          }). Where(x=>x.IsActive ==true).OrderBy(x => x.CompanyName);

            return result;
        }

        internal static IList<int> GetCompanyIDsForHRList(HRMSEntities db, string HrAdminUsername)
        {
            /* This method will return a list of company ids including parent and child companies for 
             * the HR admin. 
             * I think this will solve the duplication problem from the other method
             */

            var companyIds = (from d in db.CompanyAdministrators
                              where d.Username == HrAdminUsername
                              select d.CompanyId).ToList();

            var childCompanyIds = new List<int>();

            foreach (int companyId in companyIds)
            {
                childCompanyIds.AddRange(
                    (from d in db.Companies
                     where d.ParentCompanyId.Equals(companyId)
                     select d.CompanyId).ToList()
                );
            }

            foreach (int companyId in childCompanyIds)
            {
                if (companyIds.Contains(companyId))
                {
                    continue;
                }
                else
                {
                    companyIds.Add(companyId);
                }
            }

            return companyIds;
        }

        internal static IEnumerable<ICompanyDetail> getCompanyForHRList(HRMSEntities db, string username)
        {
            /* I read through this code again and I remembered that the key assumption made here
             * is that one HR admin could be the admin for more than one company, hence I went ahead to get a list
             * of companies from the companyAdministrator table.
             * I'm not sure if this assumption is correct, but if it isn't, then this doesn't need to retrieve a list of companies
             * and if it is, there will be duplication in the event that the same HR is the admin of both a parent company and its child
             * TODO: That duplication should be fixed, I'll get to fixing it if it's still here when I'm less busy. 
             */

            // get the company Ids that are associated with the HR username
            var companyIds = (from d in db.CompanyAdministrators
                              where d.Username == username
                              select d.CompanyId).ToList();

            var companyList = new List<ICompanyDetail>();

            // get the company and child company details for each companyId in the companyIds list
            foreach (int companyId in companyIds)
            {
                companyList.AddRange(getMyCompaniesList(db, companyId).ToList());
            }

            return companyList;
        }

        internal static ICompanyDetail getCompanyForHrAdmin(HRMSEntities db, string HrAdminUsername)
        {
            var companyId = (from d in db.CompanyAdministrators
                             where d.Username.Equals(HrAdminUsername)
                             select d.CompanyId).FirstOrDefault();

            var companyForHr = getCompanyById(db, companyId);
            return companyForHr;
        }

        internal static IEnumerable<ICompanyDetail> getMyCompaniesList(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Companies
                          where (d.ParentCompanyId == companyId || d.CompanyId == companyId)
                          select new CompanyRegistrationModel
                          {
                              CompanyId = d.CompanyId,
                              CompanyAddressLine1 = d.CompanyAddressLine1,
                              CompanyAddressLine2 = d.CompanyAddressLine2,
                              CompanyCity = d.CompanyCity,
                              IsActive = d.IsActive,
                              CompanyEmail = d.CompanyEmail,
                              CompanyAlias = d.CompanyAlias,
                              CompanyCountryId = d.CompanyCountryId,

                              DateCreated = d.DateCreated,
                              LogoDigitalFileId = d.LogoDigitalFileId,
                              CompanyName = d.CompanyName,
                              CompanyPhone = d.CompanyPhone,
                              CompanyState = d.CompanyState,
                              CompanyWebsite = d.CompanyWebsite,
                              CompanyZipCode = d.CompanyZipCode,
                              ParentCompanyId = d.ParentCompanyId,

                              CACRegistrationNumber = d.CACRegistrationNumber
                          }).Where(x => x.IsActive == true).Where(x => x.IsActive == true).OrderBy(x => x.CompanyName);

            return result;
        }
        
        internal static ICompanyDetail getCompanyById(HRMSEntities db, int CompanyId)
        {
            var result = (from d in db.Companies
                          where d.CompanyId.Equals(CompanyId) && d.IsActive.Equals(true)
                          join c in db.Countries on d.CompanyCountryId equals c.CountryId
                          select new CompanyRegistrationModel
                          {
                              CompanyId = d.CompanyId,
                              CompanyName = d.CompanyName,
                              CACRegistrationNumber = d.CACRegistrationNumber,
                              CompanyAddressLine1 = d.CompanyAddressLine1,
                              CompanyAddressLine2 = d.CompanyAddressLine2,
                              CompanyCity = d.CompanyCity,
                              CompanyCountryId = d.CompanyCountryId,
                              CompanyEmail = d.CompanyEmail,
                              CompanyPhone = d.CompanyPhone,
                              CompanyState = d.CompanyState,
                              CompanyWebsite = d.CompanyWebsite,
                              CompanyZipCode = d.CompanyZipCode,
                              DateCreated = d.DateCreated,
                              ParentCompanyId = d.ParentCompanyId,
                              CompanyAlias = d.CompanyAlias,
                              IsActive = d.IsActive,
                              LogoDigitalFileId = d.LogoDigitalFileId,
                              IndustryId = d.IndustryId,
                              CompanyCountry = c.Name
                          }).FirstOrDefault();
            return result;
        }
        
        internal static ICompanyDetail getCompanyByCACNumber(HRMSEntities db, string CACNumber)
        {
            var result = (from d in db.Companies
                          where d.CACRegistrationNumber.Equals(CACNumber)
                          select new CompanyRegistrationModel
                          {
                              CompanyId = d.CompanyId,
                              CompanyName = d.CompanyName,
                              CACRegistrationNumber = d.CACRegistrationNumber,
                              CompanyAddressLine1 = d.CompanyAddressLine1,
                              CompanyAddressLine2 = d.CompanyAddressLine2,
                              CompanyCity = d.CompanyCity,
                              CompanyCountryId = d.CompanyCountryId,
                              CompanyEmail = d.CompanyEmail,
                              CompanyPhone = d.CompanyPhone,
                              CompanyState = d.CompanyState,
                              CompanyWebsite = d.CompanyWebsite,
                              CompanyZipCode = d.CompanyZipCode,
                              DateCreated = d.DateCreated,
                              ParentCompanyId = d.ParentCompanyId,
                              CompanyAlias = d.CompanyAlias,
                              IsActive = d.IsActive,
                              LogoDigitalFileId = d.LogoDigitalFileId,
                          }).FirstOrDefault();
            return result;
        }
        
        internal static IEnumerable<IEmployeeFeedbackModel> getEmployeeFeedbackList(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeFeedbacks
                          join s in db.Employees on d.EmployeeId equals s.EmployeeId
                          join q in db.Employees on d.FeedbackOnEmployeeId equals q.EmployeeId
                          join w in db.Companies on d.CompanyId equals w.CompanyId
                          join t in db.FeedBacks on d.FeedbackId equals t.FeedbackId
                          join r in db.Years on t.YearId equals r.YearId
                          where d.EmployeeId == companyId
                          select new EmployeeFeedbackModel
                          {
                              EmployeeFeedbackId = d.EmployeeFeedbackId,
                              CompanyId = w.CompanyId,
                              EmployeeId = s.EmployeeId,
                              InWhatContext = d.InWhatContext,
                              FeedbackOnEmployeeId = d.FeedbackOnEmployeeId,
                              FeedbackOnEmployee = q.LastName + " " + q.FirstName,
                              DateCreated = d.DateCreated,
                              FeedbackId = d.FeedbackId,
                              ProvideOverview = d.ProvideOverview,
                              DateOfFeedback = d.DateOfFeedback,
                              Experience = d.Experience,
                              WhatAreas = d.WhatAreas,
                              employeeName = s.FirstName + " " + s.LastName,
                              CompanyName = w.CompanyName,
                              year = r.Year1
                          }).ToList();

            return result;
        }

        internal static IFeedbackModel getFeedbackByCompanyYearId(HRMSEntities db, int companyId, int yearId)
        {
            var result = (from d in db.FeedBacks
                          join w in db.Companies on d.CompanyId equals w.CompanyId
                          join r in db.Years on d.YearId equals r.YearId
                          where d.CompanyId == companyId && d.YearId == yearId
                          select new FeedbackModel
                          {
                              FeedbackId = d.FeedbackId,
                              CompanyId = d.CompanyId,
                              IsActive = d.IsActive,
                              IsLock = d.IsLock,
                              noOfFeedbacks = d.NoOfFeedBacks,
                              DateCreated = d.DateCreated,
                              YearId = d.YearId
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IEmployeeFeedbackModel> getEmployeeFeedbackByFeedbackId(HRMSEntities db, int feedbackId)
        {
            var result = (from d in db.EmployeeFeedbacks
                          join s in db.Employees on d.EmployeeId equals s.EmployeeId
                          join c in db.Employees on d.FeedbackOnEmployeeId equals c.EmployeeId
                          join w in db.Companies on d.CompanyId equals w.CompanyId
                          join t in db.FeedBacks on d.FeedbackId equals t.FeedbackId
                          join r in db.Years on t.YearId equals r.YearId
                          where d.FeedbackId == feedbackId
                          select new EmployeeFeedbackModel
                          {
                              EmployeeFeedbackId = d.EmployeeFeedbackId,
                              CompanyId = w.CompanyId,
                              EmployeeId = s.EmployeeId,
                              FeedbackOnEmployee = c.LastName + " " +c.FirstName,
                              InWhatContext = d.InWhatContext,
                              FeedbackOnEmployeeId = d.FeedbackOnEmployeeId,
                              DateCreated = d.DateCreated,
                              FeedbackId = d.FeedbackId,
                              ProvideOverview = d.ProvideOverview,
                              Experience = d.Experience,
                              WhatAreas = d.WhatAreas,
                              employeeName = s.FirstName + " " + s.LastName,
                              CompanyName = w.CompanyName,
                              DateOfFeedback = d.DateOfFeedback,
                              year = r.Year1
                          }).ToList();

            return result;
        }
        
        internal static IEmployeeFeedbackModel getEmployeeFeedbackListById(HRMSEntities db, int employeeFeedBackId)
        {
            var result = (from d in db.EmployeeFeedbacks
                         where d.EmployeeFeedbackId == employeeFeedBackId
                          select new EmployeeFeedbackModel
                          {
                              EmployeeFeedbackId = d.EmployeeFeedbackId,
                              CompanyId = d.CompanyId,
                              EmployeeId = d.EmployeeId ?? 0,
                              InWhatContext = d.InWhatContext,
                              FeedbackOnEmployeeId = d.FeedbackOnEmployeeId,
                              DateCreated = d.DateCreated,
                              FeedbackId = d.FeedbackId,
                              ProvideOverview = d.ProvideOverview,
                              Experience = d.Experience,
                              WhatAreas = d.WhatAreas,
                         DateOfFeedback = d.DateOfFeedback,
                         
                          }).FirstOrDefault();

            return result;
        }
    }
}