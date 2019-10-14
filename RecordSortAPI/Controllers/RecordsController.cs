using CraftJackRecordSortShared.Data;
using CraftJackRecordSortShared.Dto;
using System;
using System.Web.Http;

namespace CraftJackRecordSortAPI.Controllers
{
    public class RecordsController : ApiController
    {
        private IRecordsRepository _recordsRepository;

        public RecordsController(IRecordsRepository recordsRepository)
        {
            _recordsRepository = recordsRepository;
        }

        public IHttpActionResult Post(RecordDto record)
        {
            if (record == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recordModel = record.ToModel();

            _recordsRepository.Add(recordModel);
            record.Id = recordModel.Id;

            return Created(Url.Link("DefaultApi",
                new { controller = "Records", id = record.Id }), record);
        }

        public IHttpActionResult Get(string sortType)
        {
            switch (sortType)
            {
                case "gender":
                    return Ok(_recordsRepository.GetSortedRecords(RecordsRepository.SortMethod.Gender));
                case "birthdate":
                    return Ok(_recordsRepository.GetSortedRecords(RecordsRepository.SortMethod.DateOfBirth));
                case "name":
                    return Ok(_recordsRepository.GetSortedRecords(RecordsRepository.SortMethod.LastName));
                default:
                    return NotFound();
            }
        }
    }
}
