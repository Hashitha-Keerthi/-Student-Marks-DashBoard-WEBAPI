using System.ComponentModel.DataAnnotations;

namespace StudentMarksDashBoardAPI.Models
{
    public class Score
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Status { get; set; } = string.Empty;

        public float ModuleScore { get; set; }

        public int SubjectModuleId { get; set; }

        public SubjectModule? SubjectModule { get; set; }
    }
}
