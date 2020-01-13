using System.Windows;
using Caliburn.Micro;
using ConnectionLibrary;
using TestSolution1.ViewModels;

namespace TestSolution1
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}