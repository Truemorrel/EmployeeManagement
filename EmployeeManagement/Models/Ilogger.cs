namespace EmployeeManagement.Models
{
	public interface ILogger
	{
		void WriteError(string errorMessage);
		void WriteEvent(string eventMessage);
	}
}