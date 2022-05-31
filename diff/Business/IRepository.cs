using diff.Model;

namespace diff.Business
{
    public interface IRepository
    {
        public Task<DataContainer> ReadDataAsync(int id);
        public Task<DataContainer> AddDataAsync(int id, byte[] value, string position);
    }
}
