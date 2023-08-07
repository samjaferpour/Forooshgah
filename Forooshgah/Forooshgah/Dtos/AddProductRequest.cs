namespace Forooshgah.Dtos
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        //public IFormFile thumbnailImage { get; set; }
        public IFormFile Image { get; set; }
    }
}
