using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Todo_Class;

namespace Todo_WebService
{

    [ServiceContract]
    public interface IService1
    {
        // Implementerar krav 1. Hämt todo
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetToDo/{name}", ResponseFormat = WebMessageFormat.Json)]
        List<ToDo> GetToDoListByName(string name);

        // Implementerar krav 2. Skapa todo-list
        // Implementerar krav 3. Lägga till punkter
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddToDO", RequestFormat = WebMessageFormat.Json)]
        void AddTodo(ToDo todo);

        // Implementerar krav 4. Ta bort punkter
        [OperationContract]
        [WebInvoke(UriTemplate = "/DeleteToDo/{id}", Method = "DELETE")]
        void DelTodo(string id);

        // Implementerar krav 4. Ta bort punkter (Markera en punkt som klar)
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/MarkAsDone/{id}", RequestFormat = WebMessageFormat.Json)]
        void MarkAsDone(string id);

        // Implementerar krav 5. Se antal punkter i listan
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetToDoStatus/{name}", RequestFormat = WebMessageFormat.Json)]
        string GetToDoStatus(string name);

        // Implementerar krav 6. Lista med avklarade
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetFinishedTodos/{name}", RequestFormat = WebMessageFormat.Json)]
        List<ToDo> GetFinishedTodos(string name);

        // Implementerar krav 7. Skriva in flera punkter samtidigt
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddToDoList", RequestFormat = WebMessageFormat.Json)]
        void AddTodoList(List<ToDo> todo);

        // Implementerar krav 8. Redigera punkter
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/UpDateToDo", RequestFormat = WebMessageFormat.Json)]
        void UpdateTodo(ToDo todo);

        /* Vi hittade ingen anledning att exponera dessa endpoints

        [OperationContract]
        [WebGet(UriTemplate = "GetTodo/", ResponseFormat = WebMessageFormat.Json)]
        List<ToDo> GetToDoList();

        [OperationContract]
        [WebGet(UriTemplate = "/GetToDoById/{id}",ResponseFormat = WebMessageFormat.Json)]
        ToDo GetToDoById(string id);      

        [OperationContract]
        [WebGet]
        String GetErrorMessage();

        */

        

        


        

        





    }


  

}
