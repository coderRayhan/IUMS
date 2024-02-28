using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using IUMS.Application.Interfaces.Repositories;

namespace IUMS.Application.Features
{
    public record CreateProgramCommand : IRequest<Result<int>>
    {
        public string Code { get; set; }
        public string ProgramName { get; set; }
        public decimal CreditPoints { get; set; }
        public int YearDuration { get; set; }
        public string ProgramNameBN { get; set; }
        public int DepartmentId { get; set; }
    }

    internal sealed record CreateProgramCommandHandler(
        IProgramRepository _programRepository,
        IMapper _mapper,
        IUnitOfWork _unitOfWork) : IRequestHandler<CreateProgramCommand, Result<int>>
    {

        public async Task<Result<int>> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Program>(request);
                await _programRepository.InsertAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success();
            }
            catch (Exception ex)
            {

                return Result<int>.Fail(ex.Message);
            }
          
        }
    }
}