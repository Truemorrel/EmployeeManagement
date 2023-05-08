using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using EmployeeManagement.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace EmployeeManagement
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			IUnityContainer unityContainer = new UnityContainer();

			unityContainer.RegisterType<ILogger, Logger>();
			unityContainer.RegisterType<IEmployeeViewModel, EmployeeViewModel>();
			unityContainer.RegisterType<IEmployeesViewModel, EmployeesViewModel>();
			unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();

			unityContainer.Resolve<EmployeesView>().Show();
		}
	}
}
