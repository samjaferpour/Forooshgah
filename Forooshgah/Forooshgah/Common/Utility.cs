namespace Forooshgah.Common
{
    public static class Utility
    {
        public static string ImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
