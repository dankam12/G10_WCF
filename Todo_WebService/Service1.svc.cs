using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Todo_Class;
using Todo_DB;



namespace Todo_WebService
{    
    public class Service1 : IService1
    {
        private DAL d = new DAL (@"Data Source=localhost\sqlexpress;Initial Catalog=DB_ToDoList;User ID=RestFullUser;Password=RestFull123");

        public List<ToDo> GetToDoListByName(string name)
        {
            return d.GetToDoListByName(name);
        }

        public string AddTodo(ToDo todo)
        {
            if (todo.Name.Length >= 6)
            {
                d.AddToDo(todo);
                return "ToDo added to DB";
            }
            else
                return "Name too short";
        }

        public string DelTodo(string id)
        {
            int ID;
            int.TryParse(id, out ID);
            ToDo todo = d.GetToDoById(ID);
            if (todo != null && ID >= 0)
            {
                d.DeleteToDo(ID);
                return "ToDo with id " + ID + " was deleted";
            }
            else
            {
                return "ToDo with id " + ID + " wasn't found in DB";
            }
        }

        public string MarkAsDone(string id)
        {
            int ID;
            int.TryParse(id, out ID);
            if (ID >= 1)
            {
                ToDo todo = d.GetToDoById(ID);
                if (todo != null && todo.Finnished == false)
                {
                    todo.Finnished = true;
                    d.UpdateToDo(todo);
                    return "ToDo with id " + id + " has been marked as Finished";
                }
                else
                {
                    return "ToDo with id " + id + " doesn't exsist in DB or is already marked as Finished";
                }
            }
            return "Id not valid!";
        }

        public string GetToDoStatus(string name)
        {
            int done = 0;
            int inProgress = 0;
            List<ToDo> todolist = d.GetToDoListByName(name);
            foreach (ToDo t in todolist)
            {
                if (t.Finnished == false)
                {
                    inProgress++;
                }
                else
                {
                    done++;
                }
            }
            return "Completed ToDo's: " + done + " ToDo's not completed: " + inProgress;
        }

        public List<ToDo> GetFinishedTodos(string name)
        {
            List<ToDo> todolist = d.GetToDoListByName(name);
            List<ToDo> completed = new List<ToDo>();
            foreach (ToDo t in todolist)
            {
                if (t.Finnished == true)
                {
                    completed.Add(t);
                }
            }
            return completed;
        }

        public string UpdateTodo(ToDo todo)
        {
            ToDo to = d.GetToDoById(todo.Id);
            if (to != null && to.Name.Length >= 6)
            {
                d.UpdateToDo(todo);
                return "ToDo with id " + todo.Id + " has been updated";
            }
            else
            {
                return "A ToDo with id " + todo.Id + " wasn't found in DB or formated incorrectly";
            }
        }

        public string AddTodoList(List<ToDo> todolist)
        {
            bool listok = true;

            foreach (ToDo todo in todolist)
            {
                if (todo.Name.Length < 6)
                {
                    listok = false;
                    return "List contains items with invalid names";
                }

            }

            if (listok)
            {
                foreach (ToDo todo in todolist)
                {
                    d.AddToDo(todo);
                }
            }
            return "List added to DB";
        }

        public String GetErrorMessage()
        {
            return d.GetErrorMessage();
        }

        public ToDo GetToDoById(string id)
        {
            int ID;

            int.TryParse(id,out ID);

            if (ID >= 1)
            {

                return d.GetToDoById(ID);
            }
            else { return null; }

        }

        public List<ToDo> GetToDoList()
        {
            return d.GetToDoList();

        }       

    }
}
