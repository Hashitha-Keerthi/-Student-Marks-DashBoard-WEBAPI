using System.ComponentModel.DataAnnotations;

namespace StudentMarksDashBoardAPI.Models
{
    public class Status
    {

        public int Id { get; set; }

        [StringLength(25)]
        public string StatusOption { get; set; } = string.Empty;

    }
}
