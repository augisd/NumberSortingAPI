using System.ComponentModel.DataAnnotations;

namespace NumberSortingAPI.Domain
{
    public class Numbers
    {
        [Required]
        public int[] Values { get; set; }
    }
}