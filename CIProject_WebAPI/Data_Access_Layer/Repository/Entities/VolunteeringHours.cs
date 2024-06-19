using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer.Repository.Entities
{
    public class VolunteeringHours : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MissionId { get; set; }
        [NotMapped]
        public string MissionName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateVolunteered { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
        public string Message { get; set; }
    }

    public class VolunteeringGoals : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MissionId { get; set; }
        [NotMapped]
        public string MissionName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public int Action { get; set; }
        public string Message { get; set; }
    }
}