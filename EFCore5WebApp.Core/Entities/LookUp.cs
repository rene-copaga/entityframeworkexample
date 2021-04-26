using System.ComponentModel.DataAnnotations;

namespace EFCore5WebApp.Core.Entities
{
    public class LookUp
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public int LookUpType { get; set; }
    }
}
