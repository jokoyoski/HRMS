using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IHomeViewModelFactory" />
    public class HomeViewModelFactory : IHomeViewModelFactory
    {
        /// <summary>
        /// Creates the home page jobs view.
        /// </summary>
        /// <param name="selectedVacancy"></param>
        /// <param name="vacancyDetail">The vacancy detail.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">vacancyDetail</exception>
        public IHomeView CreateHomePageJobsView(string selectedVacancy, IList<IVacancyDetail> vacancyDetail)
        {
            if (vacancyDetail == null)
            {
                throw new ArgumentNullException(nameof(vacancyDetail));
            }

            var addedRecCount = 0;
            var k = 1;
            var vacancyInThrees = new List<IVacancyInThreeColumns>();
            var aRow = new VacancyInThreeColumn();

            var filterList = vacancyDetail.Where(x => x.JobTitle.Contains(string.IsNullOrEmpty(selectedVacancy)
                ? x.JobTitle :
                selectedVacancy)).ToList();

            foreach (var aRecord in filterList)
            {
                addedRecCount++;
                switch (k) // Counting Number of record
                {
                    case 1:
                        aRow.Column1 = aRecord;
                        break;
                    case 2:
                        aRow.Column2 = aRecord;
                        break;
                    case 3:
                        aRow.Column3 = aRecord;
                        break;
                }

                if ((k == 3) || (addedRecCount == filterList.Count))
                {
                    //Add Compledted Row Column to the List
                    vacancyInThrees.Add(aRow);


                    //Initialise variables
                    aRow = new VacancyInThreeColumn();
                    k = 0;
                }

                k++;
            }

           

            var returnView = new HomeModelView();
            returnView.VacancyList = vacancyInThrees;

            return returnView;
        }
    }
}