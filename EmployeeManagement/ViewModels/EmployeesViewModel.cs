using EmployeeManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.ViewModels
{
	public class EmployeesViewModel : INotifyPropertyChanged
	{
		private EmployeeRepository _employeeRepository;
		public event PropertyChangedEventHandler PropertyChanged;
		private string _filter;
        public string Filter
        {
            get
			{
				return _filter;
			}
            set
			{
				_filter = value;
				FillListView();
			}
		}
		private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees 
        {
			get
			{
				return _employees;
			}
			set
			{
				_employees = value;
			}
		}

		public EmployeesViewModel()
        {
            _employeeRepository = new EmployeeRepository();
			FillListView();
		}
		private void FillListView()
		{
			if (!String.IsNullOrEmpty(_filter))
			{
				_employees = new ObservableCollection<Employee>(
					 _employeeRepository.GetAll()
					 .Where(v => v.FirstName.Contains(_filter)));
				OnPropertyChanged(nameof(Employees));
			}
			else
				_employees = new ObservableCollection<Employee>(
					 _employeeRepository.GetAll());
			OnPropertyChanged(nameof(Employees));
		}

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
