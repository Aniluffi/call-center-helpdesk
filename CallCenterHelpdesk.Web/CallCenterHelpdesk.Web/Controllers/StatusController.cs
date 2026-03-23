using CallCenterHelpdesk.IService.Models.StatusService.Request;
using CallCenterHelpdesk.IService.Models.StatusService.Response;
using CallCenterHelpdesk.IService;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterHelpdesk.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        /// <summary>
        /// Получение полного списка доступных статусов для заявок
        /// </summary>
        /// <remarks>
        /// Используется для заполнения выпадающих списков (Dropdown) на фронтенде.
        /// </remarks>
        /// <returns>Список объектов с Id, Name и DisplayName</returns>
        [HttpGet("list")]
        [ProducesResponseType(typeof(StatusGetListResponse), 200)]
        public async Task<IActionResult> GetList([FromQuery] StatusGetListRequest request)
        {
            // Даже если request пустой, сервис вернет все значения Enum
            var result = await _statusService.GetList(request);

            if (result == null || !result.Items.Any())
            {
                return NoContent(); // 204, если вдруг список пуст
            }

            return Ok(result);
        }
    }
}
