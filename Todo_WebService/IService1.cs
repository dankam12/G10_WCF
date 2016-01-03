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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetTodo/", ResponseFormat = WebMessageFormat.Json)]
        List<ToDo> GetToDoList();

        [OperationContract]
        [WebGet(UriTemplate = "/GetToDo/{id}",ResponseFormat = WebMessageFormat.Json)]
        ToDo GetToDoById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetToDoByName/{name}")]
        List<ToDo> GetToDoListByName(string name);

        [OperationContract]
        [WebGet]
        String GetErrorMessage();

        [OperationContract]
        [WebInvoke(Method = "POST",UriTemplate ="/AddToDO",RequestFormat = WebMessageFormat.Json)]
        void AddTodo(ToDo todo);

        [OperationContract]
        [WebInvoke(UriTemplate = "/DelToDo/{id}", Method = "DELETE")]
        void DelTodo(string id);


        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/UpDateToDo", RequestFormat = WebMessageFormat.Json)]
        void UpdateTodo(ToDo todo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/AddToDoList", RequestFormat = WebMessageFormat.Json)]
        void AddTodoList(List<ToDo> todo);





    }


  

}
