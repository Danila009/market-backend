namespace Market.Application.Repositories.ImageRepository
{
    public interface IImageRepository
    {
        string Save(byte[] imgBytes,string path);

        byte[] Get(string path);

        void Delete(string path);
    }
}
