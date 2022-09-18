using Application.Features.CourseTech.Dtos;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.CourseTech.Commands.DeleteCourseTech;

public class DeleteCourseTechCommand:IRequest<CourseTechDto>
{
    public Guid CourseTechId { get; set; }
    
    public class DeleteCourseTechCommandHandler:IRequestHandler<DeleteCourseTechCommand, CourseTechDto>
    {
        private readonly ICourseTechRepository _courseTechRepository;

        public DeleteCourseTechCommandHandler(ICourseTechRepository courseTechRepository)
        {
            _courseTechRepository = courseTechRepository;
        }

        public async Task<CourseTechDto> Handle(DeleteCourseTechCommand request, CancellationToken cancellationToken)
        {
            var courseTech = await _courseTechRepository.GetAsync(src => src.Id == request.CourseTechId);

            await _courseTechRepository.DeleteAsync(courseTech);

            return new CourseTechDto();
        }
    }
}