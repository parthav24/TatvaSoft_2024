using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMSController : ControllerBase
    {
        ResponseResult result = new ResponseResult();
        private readonly BALCMS _balCMS;

        public CMSController(BALCMS balCMS)
        {
            _balCMS = balCMS;
        }

        [HttpGet]
        [Route("CMSList")]
        [Authorize]
        public ResponseResult CMSList()
        {
            try
            {
                result.Data = _balCMS.CMSList();
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
        [Route("CMSDetailById/{id}")]
        [Authorize]
        public ResponseResult CMSDetailById(int id)
        {
            try
            {
                result.Data = _balCMS.CMSDetailById(id);
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
        [Route("AddCMS")]
        [Authorize]
        public ResponseResult AddCMS(CMS cms)
        {
            try
            {
                result.Data = _balCMS.AddCMS(cms);
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
        [Route("UpdateCMS")]
        [Authorize]
        public ResponseResult UpdateCMS(CMS cms)
        {
            try
            {
                result.Data = _balCMS.UpdateCMS(cms);
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
        [Route("DeleteCMS/{id}")]
        [Authorize]
        public ResponseResult DeleteCMS(int id)
        {
            try
            {
                result.Data = _balCMS.DeleteCMS(id);
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