using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories;
namespace IUMS.Application.Features
{
    public record UpdateDepartmentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameBN { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int FacultyId { get; set; }

    }
    public record UpdateDepartmentCommandHandler(
        IDepartmentRepository Repository,
        IUnitOfWork UnitOfWork)
        : IRequestHandler<UpdateDepartmentCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var department = await Repository.GetByIdAsync(command.Id);
                if (department == null)
                {
                    return Result<int>.Fail($"Department Not Found.");
                }
                else
                {
                    department.DepartmentName = command.DepartmentName ?? department.DepartmentName;
                    department.DepartmentNameBN = command.DepartmentNameBN ?? department.DepartmentNameBN;
                    department.Code = command.Code ?? department.Code;
                    department.Description = command.Description ?? department.Description;
                    department.FacultyId = (command.FacultyId == 0) ? department.FacultyId : command.FacultyId;
                    await Repository.UpdateAsync(department);
                    await UnitOfWork.Commit(cancellationToken);
                    return Result<int>.Success();
                }
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}