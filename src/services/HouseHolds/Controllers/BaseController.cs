using Microsoft.AspNetCore.Mvc;
using System;
using HouseHolds.Models;
using HouseHolds.Repositories;

namespace HouseHolds.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/record/base")]
    public class BaseController : ControllerBase
    {
        private readonly IBaseRepository _BaseRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseRepository"></param>
        public BaseController(IBaseRepository BaseRepository)
        {
            _BaseRepository = BaseRepository ?? throw new ArgumentNullException(nameof(BaseRepository));
        }

        #region district

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_district_list")]
        public IActionResult GetDistrictList()
        {
            return Ok(_BaseRepository.GetDistrictList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get_district")]
        public IActionResult GetDistrict(int id)
        {
            return Ok(_BaseRepository.GetDistrict(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("set_district")]
        public IActionResult SetDistrict([FromBody] district request)
        {
            return Ok(_BaseRepository.SetDistrict(request));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete_district")]
        public IActionResult DeleteDistrict(int id)
        {
            return Ok(_BaseRepository.DeleteDistrict(id));
        }

        #endregion

        #region relationship

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_relationship_list")]
        public IActionResult GetRelationshipList()
        {
            return Ok(_BaseRepository.GetRelationshipList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get_relationship")]
        public IActionResult GetRelationship(int id)
        {
            return Ok(_BaseRepository.GetRelationship(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("set_relationship")]
        public IActionResult SetRelationship([FromBody] relationship request)
        {
            return Ok(_BaseRepository.SetRelationship(request));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete_relationship")]
        public IActionResult DeleteRelationship(int id)
        {
            return Ok(_BaseRepository.DeleteRelationship(id));
        }

        #endregion

        #region dropdownitem

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet("get_dropdown_item_list")]
        public IActionResult GetDropDownItemList(string type)
        {
            return Ok(_BaseRepository.GetDropDownItemList(type));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet("get_dropdown_item")]
        public IActionResult GetDropDownItem(int id, string type)
        {
            return Ok(_BaseRepository.GetDropDownItem(id, type));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("set_dropdown_item")]
        public IActionResult SetDropDownItem([FromBody] dropdownitem request)
        {
            return Ok(_BaseRepository.SetDropDownItem(request));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpDelete("delete_dropdown_item")]
        public IActionResult DeleteDropDownItem(int id, string type)
        {
            return Ok(_BaseRepository.DeleteDropDownItem(id, type));
        }

        #endregion

    }
}
