
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsAppRonny.Classes;

namespace WinFormsAppRonny
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FillGridData();
            InitializeDataGridView();

        }

        private void FillGridData()
        {
            List<Task1> task1s = new List<Task1>();

            Task1 t1 = new Task1();
            task1s = t1.GetTasks();
            dataGridViewTask.DataSource = task1s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewTaskForm newtask = new NewTaskForm();
            newtask.ShowDialog();
            FillGridData();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FillGridData();
        }
        private void InitializeDataGridView()
        {
         

            // Add Edit buttons to DataGridView
            DataGridViewButtonColumn btnEditColumn = new DataGridViewButtonColumn();
            btnEditColumn.Name = "Edit";
            btnEditColumn.Text = "Edit";
            btnEditColumn.UseColumnTextForButtonValue = true;
            dataGridViewTask.Columns.Add(btnEditColumn);

            // Add delete buttons to DataGridView

            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.Name = "Delete";
            btnDeleteColumn.Text = "Delete";
            btnDeleteColumn.UseColumnTextForButtonValue = true;
            dataGridViewTask.Columns.Add(btnDeleteColumn);

            // Handle cell click event for buttons
            dataGridViewTask.CellClick += dataGridViewTask_CellClick_1;


        }


        private void dataGridViewTask_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewTask.Columns["Edit"].Index)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Update this task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    EditTask1();
                }
                else
                {

                }

            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewTask.Columns["Delete"].Index)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteTask();
                }

            }
        }
        void EditTask1()
        {

            int TaskId;

            // Check if the current row is selected
            if (dataGridViewTask.CurrentRow != null)
            {
                object cellValue = dataGridViewTask.CurrentRow.Cells["TaskId"].Value;

                if (cellValue != null)
                {
                    if (cellValue is int)
                    {
                        TaskId = (int)cellValue;
                    }
                    else if (cellValue is string && int.TryParse((string)cellValue, out TaskId))
                    {
                        // Successfully parsed the string to an integer
                    }
                    else
                    {
                        MessageBox.Show("Invalid TaskId value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    EditTask e1 = new EditTask(TaskId);

                    e1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("TaskId value is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        void DeleteTask()
        {
            int rowIndex = dataGridViewTask.CurrentCell.RowIndex;

            if (rowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewTask.Rows[rowIndex];

                // Check if the cell value is convertible to an integer
                if (selectedRow.Cells["TaskId"].Value != null && int.TryParse(selectedRow.Cells["TaskId"].Value.ToString(), out int taskId))
                {
                    Task1 e1 = new Task1();
                    e1.DeleteTask(taskId);
                    FillGridData();
                }
                else
                {
                    MessageBox.Show("Invalid TaskId value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
