using CallCenterHelpdesk.IService;
using CallCenterHelpdesk.IService.Models.RequestService.Request;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterHelpdesk.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// Создание новой заявки
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RequestCreateRequest request)
        {
            if (request == null) return BadRequest();

            var result = await _requestService.Create(request);
            return Ok(result);
        }

        /// <summary>
        /// Получение списка заявок с фильтрацией
        /// </summary>
        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] RequestGetListRequest request)
        {
            // Используем FromQuery, так как GET запросы обычно передают параметры в URL
            var result = await _requestService.GetList(request);
            return Ok(result);
        }

        /// <summary>
        /// Получение деталей конкретной заявки
        /// </summary>
        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var request = new RequestGetDateilRequest { Id = id };
            var result = await _requestService.GetDateil(request);

            if (result == null) return NotFound("Заявка не найдена");

            return Ok(result);
        }

        /// <summary>
        /// Обновление заявки (статус, описание и т.д.)
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] RequestUpdateRequest request)
        {
            var result = await _requestService.Update(request);

            if (!result) return NotFound("Не удалось обновить заявку: Id не найден");

            return Ok(result);
        }

        /// <summary>
        /// Удаление заявки
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new RequestDeleteRequest { Id = id };
            var result = await _requestService.Delete(request);

            if (!result) return NotFound("Заявка для удаления не найдена");

            return Ok(result);
        }
    }
}
