// Date created: 6/15/2020
// Time: 2 hrs
// Description: Written in C# and MySQL to help the user manage customer 's information 
// Note: Add-in MYSQL for Visual Studio is needed

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerInformation
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmCustInfo());
		}
	}
}
