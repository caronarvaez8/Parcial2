using System.Collections.Generic;
using webApi.Models;

namespace webApi.Services
{
    public class LoginService{


        List<User> _users= null;
        
        public LoginService(){

             _users = new List<User>();
        }

        public List<User> GetUsers(){
            return _users;
        }

        public void addUser( User usu){
            _users.Add(usu);
        }
    }

}