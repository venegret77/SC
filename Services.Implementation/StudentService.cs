using Common.Models;
using Common.Models.Dictionaries;
using Common.Models.Students;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<ResultContainer<PagedContainer<IEnumerable<StudentViewModel>>>> GetPagedStudentsAsync(int? skip, int? take)
        {
            var result = new ResultContainer<PagedContainer<IEnumerable<StudentViewModel>>>();

            try
            {
                var count = await studentRepository.GetStudentsCountAsync();

                var students = await studentRepository.GetPagedStudentsAsync(skip ?? 0, take ?? count);

                var content = students.Select(s => new StudentViewModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    Identifer = s.Identifer,
                    Gender = new DictionaryViewModel
                    {
                        Id = s.Gender?.Id,
                        Value = s.Gender?.Value,
                        MUIIconName = s.Gender?.MUIIconName
                    }
                }).ToList();

                result.Success = true;
                result.Content = new PagedContainer<IEnumerable<StudentViewModel>>
                {
                    Count = count,
                    Content = content
                };
            }
            catch(Exception exception)
            {
                result.Message = exception.Message;
            }

            return result;
        }

        public async Task<ResultContainer<long>> AddStudentAsync(AddOrUpdateStudentModel model)
        {
            var result = new ResultContainer<long>();

            try
            {
                var studentId = await studentRepository.AddStudentAsync(model);

                result.SetResult(InfoMessages.StudentAddSuccess, studentId);
            }
            catch (Exception exception)
            {
                result.SetError(exception);
            }

            return result;
        }

        public async Task<ResultContainer> UpdateStudentAsync(UpdateStudentModel model)
        {
            var result = new ResultContainer();

            try
            {
                await studentRepository.UpdateStudentAsync(model);

                result.SetResult(InfoMessages.StudentUpdateSuccess);
            }
            catch (Exception exception)
            {
                result.SetError(exception);
            }

            return result;
        }

        public async Task<ResultContainer> DeleteStudentAsync(long id)
        {
            var result = new ResultContainer();

            try
            {
                await studentRepository.DeleteStudentAsync(id);

                result.SetResult(InfoMessages.StudentDeleteSuccess);
            }
            catch (Exception exception)
            {
                result.SetError(exception);
            }

            return result;
        }
    }
}
