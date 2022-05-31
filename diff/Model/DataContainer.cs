

using System.ComponentModel.DataAnnotations;

namespace diff.Model
{
    public class DataContainer
    {
         
        public int Id { get; set; }
        public byte[]? dataLeft { get; set; }
        public byte[]? dataRight { get; set; }

    }
}
