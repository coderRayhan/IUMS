using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using IUMS.Application.Interfaces.Repositories.Academic;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Features
{
    public record  CreateFacultyCommand : IRequest<Result<int>>
    {
        public string FacultyName { get; set; }
        public string FacultyNameBN { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool HasAffiliatedInstitute { get; set; }
        public int AffiliatedInstituteId { get; set; } = 0;
    }

    public record CreateFacultyCommandHandler (IFacultyRepository FacultyRepository, IMapper Mapper, IUnitOfWork UnitOfWork) : IRequestHandler<CreateFacultyCommand, Result<int>>
    {

        public async Task<Result<int>> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var facultys = await FacultyRepository.GetListAsync();
                if (facultys.Any(e => e.Code == request.Code))
                {
                    return Result<int>.Fail("Code Already Exists.");
                }
                if (facultys.Any(e => e.FacultyName == request.FacultyName))
                {
                    return Result<int>.Fail("Name(English) Already Exists.");
                }
                if (facultys.Any(e => e.FacultyNameBN == request.FacultyNameBN))
                {
                    return Result<int>.Fail("Name(Bangla) Already Exists.");
                }

                var entity = Mapper.Map<Faculty>(request);
                await FacultyRepository.InsertAsync(entity);
                await UnitOfWork.Commit(cancellationToken);
                return Result<int>.Success();
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}