using System.Text;

namespace diff.Model
{
     
    public class ResultObjectDiff:ResultObject
    {
        private List<Diff> diffList=new();
        public ResultObjectDiff(DataContainer dataContainer)
        {
            diffResultType= "ContentDoNotMatch";
            int count = 1;
            
                for (int offset = 0; offset < dataContainer.dataLeft.Length - 1; offset++)
                {
                    ArraySegment<byte> segmentLeft = new ArraySegment<byte>(dataContainer.dataLeft, offset, count);
                    ArraySegment<byte> segmentRight = new ArraySegment<byte>(dataContainer.dataRight, offset,  count);
                    if (!segmentLeft.SequenceEqual(segmentRight))
                    {
                        Diff diff = new();
                        diff.offset = offset;
                        diff.length = count;
                        diffList.Add(diff);
                    }
                    else
                    {
                        count++;
                    }
                }
             
        }
        
        public List<Diff> Diffs 
        { 
            get { return diffList; }
        }
    }
}
