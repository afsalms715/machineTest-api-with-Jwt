using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace machineTest_svc.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
