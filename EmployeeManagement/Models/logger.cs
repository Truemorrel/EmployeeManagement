using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
	public class Logger : ILogger
	{
		private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
		private string logDirectory { get; set; }
		public Logger()
		{
			logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_log/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

			if (!Directory.Exists(logDirectory))
				Directory.CreateDirectory(logDirectory);
		}
		public void WriteEvent(string eventMessage)
		{
			_lock.EnterWriteLock();
			try
			{
				using (StreamWriter writer = new StreamWriter(logDirectory + "events.txt", append: true))
				{
					writer.Write(eventMessage);
				}
			}
			finally
			{
				_lock.ExitWriteLock();
			}
		}
		public void WriteError(string errorMessage)
		{
			_lock.EnterWriteLock();
			try
			{
				using (StreamWriter writer = new StreamWriter("error.txt", append: true))
				{
					writer.Write(errorMessage);
				}
			}
			finally
			{
				_lock.ExitWriteLock();
			}
		}
	}
}
