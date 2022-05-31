using diff.Model;

namespace diff.Business
{
    public class Repository : IRepository
    {
        private readonly DataModel _db; 
        public Repository(DataModel db)
        {
            _db = db;
        }
        /// <summary>
        /// Procedure tries to retrieve object. 
        /// If it cannot be retrieved it is created otherwise it is updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="position"></param>
        /// <returns> Object </returns>
        public async Task<DataContainer> AddDataAsync(int id, byte[] value, string position)
        {
            DataContainer container = new DataContainer();           
            if (await _db.AllData.FindAsync(id) == null)
            {
                container.Id = id;
                if (position.ToLower() == "l")
                {                   
                    container.dataLeft = value;                 
                    _db.Add(container);
                    await _db.SaveChangesAsync();
                }
                else if (position.ToLower() == "r")
                {
                    container.dataRight = value;                    
                    _db.Add(container);
                    await _db.SaveChangesAsync();
                }
            }
            else
            {
                container = _db.AllData.Find(id);
                if (position.ToLower() == "l")
                {
                    container.dataLeft=value;
                      _db.Update(container);
                    await _db.SaveChangesAsync();
                }
                else if (position.ToLower() == "r")
                {
                    container.dataRight = value;
                    _db.Update(container);
                    await _db.SaveChangesAsync();
                }
            }
            return container;
        }

        /// <summary>
        /// Retrieves object with its id from database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Object </returns>
        public async Task<DataContainer> ReadDataAsync(int id)
        {
            return await _db.AllData.FindAsync(id);
        }
    }
}
