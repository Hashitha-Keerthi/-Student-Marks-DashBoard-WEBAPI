using System.ComponentModel.DataAnnotations;

namespace StudentMarksDashBoardAPI.Models
{
    public class SubjectModule
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string ModuleName { get; set; } = string.Empty; 
    
    
    }
}
