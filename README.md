# WinFormsAppRonny
------------Task_Managment-------------------------

This is a simple Task Management application built using C# and Windows Forms. It allows users to add, edit, and delete tasks, with the tasks stored in a SQL Server database.

Table of Contents
Prerequisites
Installation
Usage
Contributing
License
Prerequisites
Before you begin, ensure you have met the following requirements:

Visual Studio installed on your machine.
SQL Server instance with a database named FirstApplication.
Basic understanding of C# and Windows Forms.
Installation
Clone the repository to your local machine:

bash
Copy code
git clone https://github.com/your-username/TaskManagementApp.git
Open the solution in Visual Studio:

Navigate to the WinFormsAppRonny folder.
Double-click on the WinFormsAppRonny.sln file.
Update the connection string:

Open the Task1.cs file in the Classes folder.
Locate the connectionString variable and update it with your SQL Server connection details.
Build the solution:

Press Ctrl + Shift + B to build the solution.
Usage
Run the application:

Press F5 or click on the "Start Debugging" button in Visual Studio.
Add a new task:

Click on the "Add New Task" button.
Enter the task details in the form and click "Save."
Edit a task:

Click on the "Edit" button in the DataGridView for the task you want to edit.
Update the task details and click "Save Changes."
Delete a task:

Click on the "Delete" button in the DataGridView for the task you want to delete.
Confirm the deletion.
Contributing
If you'd like to contribute to this project, follow these steps:

Fork the repository.
Create a new branch: git checkout -b feature/your-feature.
Commit your changes: git commit -m 'Add some feature'.
Push to the branch: git push origin feature/your-feature.
Submit a pull request.
