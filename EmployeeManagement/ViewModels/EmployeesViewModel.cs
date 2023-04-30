using EmployeeManagement.Models;
using System.Collections.ObjectModel;

namespace EmployeeManagement.ViewModels
{
	public class EmployeesViewModel
	{
        private EmployeeRepository _employeeRepository { get; }
        public EmployeesViewModel()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public ObservableCollection<Employee> Employees 
        {
            get {
                return new ObservableCollection<Employee>(
                    this._employeeRepository.GetAll());
            }
        }
    }
}
