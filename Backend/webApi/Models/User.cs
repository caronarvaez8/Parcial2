using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public class User{
        
        [Key]
        public string usuario { get; set; }
        public string pass { get; set; }
        public string email { get; set; }
    }

}