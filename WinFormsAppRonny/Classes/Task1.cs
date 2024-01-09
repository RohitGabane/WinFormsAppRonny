using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;



namespace WinFormsAppRonny.Classes
{

    public class Task1
    {
       
       
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "DueDate is required")]
        public DateTime DueDate { get; set; }

        string connectionString = "Data Source=DESKTOP-OOM2M0F\\MSSQLSERVER01;Initial Catalog=FirstApplication;Integrated Security=True;Trust Server Certificate=True";




      
            public List<Task1> GetTasks()
        {
            List<Task1> tasks = new List<Task1>();
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select TaskId,Title,Description,DueDate From task";
            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Task1 t = new Task1();
                    t.TaskId = Convert.ToInt32(reader["TaskId"]);
                    t.Title = reader["Title"].ToString();
                    t.Description = reader["Description"].ToString();
                    //Check if DueDate is not DBNull
                    if (reader["DueDate"] != DBNull.Value)
                    {
                        t.DueDate = Convert.ToDateTime(reader["DueDate"]);
                    }
                    tasks.Add(t);
                }
            }
            return tasks;
        }

           //ADD the New Task In the Database
        public void CreateTask()
        {
            SqlConnection con = new SqlConnection(connectionString);   //Create the SqlConnection and pass the connection 
            SqlCommand cmd = new SqlCommand("sp_InsertTask", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Title", this.Title));
            cmd.Parameters.Add(new SqlParameter("@Description", this.Description));
            cmd.Parameters.Add(new SqlParameter("@Duedate", this.DueDate));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        //Get Data From Database through the UI
        public Task1 GetTaskData(int TaskId)
        {
            Task1 t = null;
         


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectdata = "SELECT * FROM Task WHERE TaskId = @TaskId";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(selectdata, con))
                {
                    cmd.Parameters.AddWithValue("@TaskId", TaskId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        t = new Task1();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                t.TaskId = Convert.ToInt32(reader["TaskId"]);
                                t.Title = reader["Title"].ToString();
                                t.Description = reader["Description"].ToString();

                                // Check if DueDate is not DBNull
                                if (reader["DueDate"] != DBNull.Value)
                                {
                                    //   t.DueDate = Convert.ToDateTime(reader["DueDate"]);
                                    t.DueDate = ((DateTime)reader["DueDate"]).Date;

                                }
                            }
                        }
                    }
                }
            }

            return t;
        }


        //Editing the data which is existing in the database through the UI
        public void EditTask1(Task1 task)
        
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateTask", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TaskId", task.TaskId));
                    cmd.Parameters.Add(new SqlParameter("@Title", task.Title));
                    cmd.Parameters.Add(new SqlParameter("@Description", task.Description));
                    cmd.Parameters.Add(new SqlParameter("@Duedate", task.DueDate));

                    con.Open();
                    cmd.ExecuteNonQuery();
                
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Delete Data in the Database through the UI
        public void DeleteTask(int TaskId)
          {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteTask", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TaskId",TaskId));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}

