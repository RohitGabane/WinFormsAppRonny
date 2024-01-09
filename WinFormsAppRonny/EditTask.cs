using WinFormsAppRonny.Classes;
using System;
using System.Windows.Forms;

namespace WinFormsAppRonny
{
    public partial class EditTask : Form
    {
        private int SelectedTask;

        public EditTask(int TaskId)
        {
            InitializeComponent();
            SelectedTask = TaskId;
            GetTaskData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                EditTaskData();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please correct the validation errors before updating the task.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetTaskData()
        {
            Task1 t1 = new Task1();
            t1 = t1.GetTaskData(SelectedTask);
            textBox1.Text = t1.Title;
            textBox2.Text = t1.Description;
            dateTimePicker1.Value = t1.DueDate;
        }

        private void EditTaskData()
        {
            Task1 task = new Task1();
            task.TaskId = SelectedTask;
            task.Title = textBox1.Text;
            task.Description = textBox2.Text;
            task.DueDate = dateTimePicker1.Value;

            // Assuming EditTask1 method correctly updates the task data
            task.EditTask1(task);

            MessageBox.Show("Task updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ValidateTextBox(textBox1, errorProvider1, "Title is required.");
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            ValidateTextBox(textBox2, errorProvider2, "Description is required.");
        }

        private void ValidateTextBox(TextBox textBox, ErrorProvider errorProvider, string errorMessage)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Focus();
                errorProvider.SetError(textBox, errorMessage);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private bool ValidateForm()
        {
            // Add additional validation logic if needed
            ValidateTextBox(textBox1, errorProvider1, "Title is required.");
            ValidateTextBox(textBox2, errorProvider2, "Description is required.");

            // Return true if all validations pass, otherwise return false
            return string.IsNullOrEmpty(errorProvider1.GetError(textBox1)) &&
                   string.IsNullOrEmpty(errorProvider2.GetError(textBox2));
        }

       
    }
}

