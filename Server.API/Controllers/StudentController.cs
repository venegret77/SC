using Common.Helpers;
using Common.Models;
using Common.Models.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.API.Controllers
{
    /// <summary>
    /// Authorization controller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        /// <summary>
        /// Конструктор DI
        /// </summary>
        /// <param name="studentService"></param>
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Получение постраничного списка студентов
        /// </summary>
        /// <param name="skip">Пропустить</param>
        /// <param name="take">Взять</param>
        /// <returns>Результирующий контейнер</returns>
        [HttpGet("GetPagedStudents")]
        public async Task<ResultContainer<PagedContainer<IEnumerable<StudentViewModel>>>> GetPagedStudentsAsync(int? skip, int? take)
        {
            #region Validate model
            if (!ModelState.IsValid)
            {
                return new ResultContainer<PagedContainer<IEnumerable<StudentViewModel>>> { Message = EnumHelper.GetDescription(Errors.ModelValidationError), Success = false };
            }
            #endregion

            return await studentService.GetPagedStudentsAsync(skip, take);
        }

        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="model">Модель данных</param>
        /// <returns>Результирующий контейнер</returns>
        [HttpPost("AddStudent")]
        public async Task<ResultContainer<long>> AddStudentAsync(AddOrUpdateStudentModel model)
        {
            #region Validate model
            if (!ModelState.IsValid)
            {
                return new ResultContainer<long> { Message = EnumHelper.GetDescription(Errors.ModelValidationError), Success = false };
            }
            #endregion

            return await studentService.AddStudentAsync(model);
        }

        /// <summary>
        /// Изменение данных о студенте
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <param name="model">Модель данных</param>
        /// <returns>Результирующий контейнер</returns>
        [HttpPut("UpdateStudent/{id}")]
        public async Task<ResultContainer> UpdateStudentAsync(long id, AddOrUpdateStudentModel model)
        {
            #region Build UpdateStudentModel
            var _model = new UpdateStudentModel
            {
                StudentId = id,
                GenderId = model.GenderId,
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                Identifer = model.Identifer
            };
            #endregion

            return await studentService.UpdateStudentAsync(_model);
        }

        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <returns>Результирующий контейнер</returns>
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ResultContainer> DeleteStudentAsync(long id)
        {
            return await studentService.DeleteStudentAsync(id);
        }
    }
}
