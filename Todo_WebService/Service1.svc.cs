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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    //PS C:\WINDOWS\system32> Invoke-RestMethod -Uri http://localhost:8000/index/GEtTodo/3 -UseDefaultCredentials -Method DELETE
    
    public class Service1 : IService1
    {
        private DAL d = new DAL (@"Data Source=localhost\sqlexpress;Initial Catalog=DB_ToDoList;User ID=RestFullUser1;Password=RestFull123");

        public void AddTodo(ToDo todo)
        {

            d.AddToDo(todo);
        }

        public void UpdateTodo(ToDo todo)
        {

            d.UpdateToDo(todo);
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

        public List<ToDo> GetToDoListByName(string name)
        {
            return d.GetToDoListByName(name);
        }

        public void DelTodo(string id)
        {
            int ID;

            int.TryParse(id, out ID);
            if (ID >= 0)
            { d.DeleteToDo(ID); }
            else ID = -1;


         
            
        }

    }
    // till kolla om ! på slutet  if("köpaöl!".substring(("köpaöl!".length -1))== !) fixa whitespaces samt trim... 
}
