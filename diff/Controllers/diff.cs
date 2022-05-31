using diff.Business;
using diff.Model;
using Microsoft.AspNetCore.Mvc;

 
#pragma warning disable CS8604 // Possible null reference argument.


namespace diff.Controllers
{

    [Route("v1/[controller]")]
    [ApiController]
    public class diff : ControllerBase
    {
        private IRepository repository;
        public diff(IRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                DataContainer dataContainer = new DataContainer();
                dataContainer = repository.ReadDataAsync(id).Result;
                if (dataContainer is not null)
                {
                    if (dataContainer.dataLeft.SequenceEqual(dataContainer.dataRight))
                    {
                        ResultObject resultObject = new ResultObject();
                        resultObject.diffResultType = "Equals";
                        return Ok(resultObject);
                    }
                    else
                    {
                        if (dataContainer.dataLeft.Length != dataContainer.dataRight.Length)
                        {
                            ResultObject resultObject = new ResultObject();
                            resultObject.diffResultType = "SizeDoNotMatch";
                            return Ok(resultObject);
                        }
                        else
                        {
                            ResultObjectDiff resultObjectDiff = new ResultObjectDiff(dataContainer);
                            return Ok(resultObjectDiff);
                        }
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/left")]
        public async Task<CreatedResult> PutLeft(int id, [FromBody] DataObject receivedData)
        {
            return Created("~/v1/diff/1/left", await repository.AddDataAsync(id, receivedData.data, "l"));
        }

        [HttpPut("{id}/right")]
        public async Task<CreatedResult> PutRight(int id, [FromBody] DataObject receivedData)
        {
            return Created("~/v1/diff/1/left", await repository.AddDataAsync(id, receivedData.data, "r"));
        }
    }
}
