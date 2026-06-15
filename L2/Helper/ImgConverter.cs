namespace L2.Helper;

public static class ImgConverter
{
    public static string ConvertImg(byte[] imgBytes)
    {
        string base64String = Convert.ToBase64String(imgBytes);
        string imgSrc = $"data:image/png;base64,{base64String}";
        return imgSrc;
    }
}