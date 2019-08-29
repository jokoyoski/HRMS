using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AA.HRMS.DI.Windsor.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        /// <summaryAA.HRMS
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().If(c => c.Name.EndsWith("Controller")).LifestyleTransient());
        }

    }
}