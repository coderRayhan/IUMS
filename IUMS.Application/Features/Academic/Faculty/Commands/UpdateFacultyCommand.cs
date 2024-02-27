using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using IUMS.Application.Interfaces.Repositories.Academic;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;

namespace UEMS.Application.Features
{
    public record UpdateFacultyCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public string FacultyNameBN { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool HasAffiliatedInstitute { get; set; }
        public int AffiliatedInstituteId { get; set; } = 0;


        public record UpdateFacultyCommandHandler(
            IFacultyRepository FacultyRepository, 
            IUnitOfWork UnitOfWork) : IRequestHandler<UpdateFacultyCommand, Result<int>>
        {
            public async Task<Result<int>> Handle(UpdateFacultyCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var faculty = await FacultyRepository.GetByIdAsync(command.Id);

                    if (faculty == null)
                    {
                        return Result<int>.Fail($"Faculty Not Found.");
                    }
                    else
                    {
                        var facultys = await FacultyRepository.GetListAsync();
                        if (facultys.Any(e => e.Id != command.Id && e.Code == command.Code))
                        {
                            return Result<int>.Fail("Code Already Exists.");
                        }
                        if (facultys.Any(e => e.Id != command.Id && e.FacultyName == command.FacultyName))
                        {
                            return Result<int>.Fail("Name(English) Already Exists.");
                        }
                        if (facultys.Any(e => e.Id != command.Id && e.FacultyNameBN == command.FacultyNameBN))
                        {
                            return Result<int>.Fail("Name(Bangla) Already Exists.");
                        }

                        faculty.FacultyName = command.FacultyName ?? faculty.FacultyName;
                        faculty.FacultyNameBN = command.FacultyNameBN ?? faculty.FacultyNameBN;
                        faculty.Code = command.Code ?? faculty.Code;
                        faculty.Description = command.Description ?? faculty.Description;
                        faculty.HasAffiliatedInstitute = command.HasAffiliatedInstitute;
                        faculty.AffiliatedInstituteId = command.AffiliatedInstituteId;
                        await FacultyRepository.UpdateAsync(faculty);
                        await UnitOfWork.Commit(cancellationToken);
                        return Result<int>.Success(faculty.Id);
                    }
                }
                catch (Exception ex)
                {
                    return Result<int>.Fail(ex.Message);
                }           
            }
        }
    }
}