using EmployeeManagement.Models;
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
	/// Interaction logic for EmployessView.xaml
	/// </summary>
	public partial class EmployessView : Window
	{
		public EmployessView()
		{
			InitializeComponent();
		}

		private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{

        }

		private void ListView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var item = (sender as ListView).SelectedItem;
			if (item is null) { return;}
			var firstName = (item as Employee).FirstName;
			var lastName = (item as Employee).LastName;
			var age = (item as Employee).Age;
			var companyName = (item as Employee).CompanyName;
			var position = (item as Employee).Position;
			var cityName = (item as Employee).CityName;
			MessageBox.Show($"Имя: {firstName}{Environment.NewLine}Фамилия: {lastName}{Environment.NewLine}" +
				$"Возраст: {age}{Environment.NewLine}Название компании: {companyName}{Environment.NewLine}" +
				$"Должность: {position}{Environment.NewLine}Город: {cityName}");
		}
	}
}
