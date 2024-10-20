using System.ComponentModel.DataAnnotations;

namespace WebAppTeste.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string gender {  get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string cell { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }
}
