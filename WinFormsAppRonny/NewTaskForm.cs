
using System;
using System.Windows.Forms;
using WinFormsAppRonny.Classes;

namespace WinFormsAppRonny
{
    public partial class NewTaskForm : Form
    {
        public NewTaskForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveTask();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelTask();
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ValidateTitle();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidateDescription();
        }

        //private void dateTimePicker1_Leave(object sender, EventArgs e)
        //{
        //    ValidateDueDate();
        //}

        private void ValidateTitle()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                Tilte_errorProvider1.SetError(textBox1, "Enter the Title");
            }
            else
            {
                Tilte_errorProvider1.Clear();
            }
        }

        private void ValidateDescription()
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider1.SetError(textBox2, "Enter the Description");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        //private void ValidateDueDate()
        //{
        //    if (dateTimePicker1.Value < DateTime.Now)
        //    {
        //        dateTimePicker1.Focus();
        //        errorProviderDueDate.SetError(dateTimePicker1, "Due Date should be in the future");
        //    }
        //    else
        //    {
        //        errorProviderDueDate.Clear();
        //    }
        //}

        private bool ValidateForm()
        {
            ValidateTitle();
            ValidateDescription();
            // ValidateDueDate();

            return Tilte_errorProvider1.GetError(textBox1) == "" &&
                   errorProvider1.GetError(textBox2) == ""; //&&
                                                            //  errorProviderDueDate.GetError(dateTimePicker1) == "";
        }

        private void SaveTask()
        {
            Task1 t1 = new Task1();
            t1.Title = textBox1.Text;
            t1.Description = textBox2.Text;
            t1.DueDate = dateTimePicker1.Value;

            t1.CreateTask();
        }

        private void CancelTask()
        {
        }

       
    }
}

