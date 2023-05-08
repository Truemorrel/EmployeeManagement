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
		public event PropertyChangedEventHandler PropertyChanged;
		private EmployeeRepository _employeeRepository;
		private string _filterMessage;
		public string FilterMessage 
		{
			get
			{
				return _filterMessage;
			}
			set
			{
				_filterMessage = value;
				OnPropertyChanged();
			}
		}
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
				FillFilterMessage();
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
				OnPropertyChanged();
			}
		}
		public EmployeesViewModel()
        {
            _employeeRepository = new EmployeeRepository();
			FillListView();
			FillFilterMessage();
		}
		private void FillListView()
		{
			if (!String.IsNullOrEmpty(_filter))
			{
				_employees = new ObservableCollection<Employee>(
					 _employeeRepository.GetAll()
					 .Where(v => v.FirstName.Contains(_filter)));
			}
			else
			{
				_employees = new ObservableCollection<Employee>(
					 _employeeRepository.GetAll());
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		}
		private void FillFilterMessage()
		{
			if (!String.IsNullOrEmpty(_filter))
			{
				FilterMessage = "По вашему запросу найдено: " + Employees.Count().ToString();
				OnPropertyChanged(nameof(Employees));
			}
			else
			{
				FilterMessage = "Введите данные для поиска";
				OnPropertyChanged(nameof(Employees));
			}
		}
	}
}
