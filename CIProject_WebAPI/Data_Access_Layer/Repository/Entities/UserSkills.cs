using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer.Repository.Entities
{
    public class UserSkills : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Skill { get; set; }
        public int UserId { get; set; }
    }
}
