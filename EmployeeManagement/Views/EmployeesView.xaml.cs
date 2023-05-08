using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeManagement.Views
{
	/// <summary>
	/// Interaction logic for EmployeesView.xaml
	/// </summary>
	public partial class EmployeesView : Window
	{
		IEmployeeViewModel _employeeViewModel;
		IEmployeesViewModel _employeesViewModel;
		public EmployeesView(
			IEmployeesViewModel employeesViewModel,
			IEmployeeViewModel employeeViewModel)
		{
			_employeesViewModel = employeesViewModel;
			_employeeViewModel = employeeViewModel;

			InitializeComponent();
			DataContext = _employeesViewModel;
		}

		private void ListView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var item = (sender as ListView).SelectedItem;

			if (item is null) { return;}

			var employee = item as Employee;

			_employeeViewModel.Employee = employee;

			var employeeView = new EmployeeView(_employeeViewModel);

			employeeView.Show();

			
		}
		//private string Message(Employee employee)
		//{
		//	return $"Имя: {employee.FirstName}{Environment.NewLine}Фамилия: {employee.LastName}{Environment.NewLine}" +
		//		$"Возраст: {employee.Age}{Environment.NewLine}Название компании: {employee.CompanyName}{Environment.NewLine}" +
		//		$"Должность: {employee.Position}{Environment.NewLine}Город: {employee.CityName}";
		//}
	}
}
