using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories;

namespace IUMS.Application.Features
{
    public record UpdateProgramCommand
        : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ProgramName { get; set; }
        public string ProgramNameBN { get; set; }
        public int DepartmentId { get; set; }
        public decimal CreditPoints { get; set; }
        public int YearDuration { get; set; }


    }
    internal record UpdateProgramCommandHandler(
        IProgramRepository _programRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<UpdateProgramCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(UpdateProgramCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var program = await _programRepository.GetByIdAsync(command.Id);

                if (program == null)
                {
                    return Result<int>.Fail($"Program Not Found.");
                }
                else
                {
                    program.ProgramName = command.ProgramName ?? program.ProgramName;
                    program.ProgramNameBN = command.ProgramNameBN ?? program.ProgramNameBN;
                    program.DepartmentId = command.DepartmentId;
                    program.Code = command.Code;
                    program.CreditPoints = command.CreditPoints; //?? program.CreditPoints;
                    program.YearDuration = command.YearDuration;

                    await _programRepository.UpdateAsync(program);
                    await _unitOfWork.Commit(cancellationToken);
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