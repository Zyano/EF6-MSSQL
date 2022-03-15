using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace Model.Model
{
    public class Institution
    {
        [Key]        
        public int Id { get; set; }

        public string Name { get; set; }

        public DbGeography Location { get; set; }
    }
}
