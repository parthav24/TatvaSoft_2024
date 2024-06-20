using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteeringTimesheetController : ControllerBase
    {
        ResponseResult result = new ResponseResult();
        private readonly BALVolunteeringTimesheet _balVolunteeringTimesheet;
        public VolunteeringTimesheetController(BALVolunteeringTimesheet balVolunteeringTimesheet)
        {
            _balVolunteeringTimesheet = balVolunteeringTimesheet;
        }

        [HttpGet]
        [Route("GetVolunteeringHoursList/{userId}")]
        [Authorize]
        public ResponseResult GetVolunteeringHoursList(int userId)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.GetVolunteeringHoursList(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("GetVolunteeringHoursListById/{id}")]
        [Authorize]
        public ResponseResult GetVolunteeringHoursListById(int id)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.GetVolunteeringHoursListById(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("VolunteeringMissionList/{id}")]
        [Authorize]
        public ResponseResult VolunteeringMissionList(int id)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.VolunteeringMissionList(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("AddVolunteeringHours")]
        [Authorize]
        public ResponseResult AddVolunteeringHours(VolunteeringHours volunteeringHours)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.AddVolunteeringHours(volunteeringHours);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("UpdateVolunteeringHours")]
        [Authorize]
        public ResponseResult UpdateVolunteeringHours(VolunteeringHours volunteeringHours)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.UpdateVolunteeringHours(volunteeringHours);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpDelete]
        [Route("DeleteVolunteeringHours/{id}")]
        [Authorize]
        public ResponseResult DeleteVolunteeringHours(int id)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.DeleteVolunteeringHours(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("GetVolunteeringGoalsList/{userId}")]
        [Authorize]
        public ResponseResult GetVolunteeringGoalsList(int userId)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.GetVolunteeringGoalsList(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("GetVolunteeringGoalsListById/{id}")]
        [Authorize]
        public ResponseResult GetVolunteeringGoalsListById(int id)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.GetVolunteeringGoalsListById(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("AddVolunteeringGoals")]
        [Authorize]
        public ResponseResult AddVolunteeringGoals(VolunteeringGoals volunteeringGoals)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.AddVolunteeringGoals(volunteeringGoals);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("UpdateVolunteeringGoals")]
        [Authorize]
        public ResponseResult UpdateVolunteeringGoals(VolunteeringGoals volunteeringGoals)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.UpdateVolunteeringGoals(volunteeringGoals);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpDelete]
        [Route("DeleteVolunteeringGoals/{id}")]
        [Authorize]
        public ResponseResult DeleteVolunteeringGoals(int id)
        {
            try
            {
                result.Data = _balVolunteeringTimesheet.DeleteVolunteeringGoals(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}