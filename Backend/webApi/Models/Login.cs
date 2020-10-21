using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public class Login{
        
        [Key]
        public string est { get; set; }
        public string msg { get; set; }
    }

}