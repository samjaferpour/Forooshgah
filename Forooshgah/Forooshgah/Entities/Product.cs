using System.ComponentModel.DataAnnotations;

namespace Forooshgah.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        //public byte[] thumbnailImage { get; set; }
        public string ImageName { get; set; }
    }
}
