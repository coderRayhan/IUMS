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
    public record  CreateDepartmentCommand : IRequest<Result<int>>
    {
        public string DepartmentName { get; set; }
        public string DepartmentNameBN { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int FacultyId { get; set; }
    }

    public record CreateDepartmentCommandHandler(
        IDepartmentRepository Repository, 
        IMapper Mapper, 
        IUnitOfWork UnitOfWork) : IRequestHandler<CreateDepartmentCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var list = await Repository.GetListAsync();
                if (list.Any(x => x.FacultyId == command.FacultyId && x.DepartmentName == command.DepartmentName))
                {
                    return Result<int>.Fail("Department name is already exist.");
                }
                else if (list.Any(x => x.FacultyId == command.FacultyId && x.DepartmentNameBN == command.DepartmentNameBN))
                {
                    return Result<int>.Fail("Department name bangla is already exist.");
                }
                var entity = Mapper.Map<Department>(command);
                await Repository.InsertAsync(entity);
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