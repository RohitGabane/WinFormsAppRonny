namespace WinFormsAppRonny
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}

/*
 Create a SqlConnection object using a connection string.

Handle exceptions.

Open the connection.

Create a SQLCommand. To represent a SQLCommand like (select * from studentdetails) and attach the existing connection to it. Specify the type of SQLCommand (text/storedprocedure).

Execute the command (use executereader).

Get the Result (use SqlDataReader). This is a forwardonly/readonly dataobject.

Close the connection
Process the result
Display the Result

 
 */