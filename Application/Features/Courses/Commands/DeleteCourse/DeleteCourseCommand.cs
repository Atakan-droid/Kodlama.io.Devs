using Application.Features.Courses.Dtos;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommand:IRequest
{
    public Guid Id { get; set; }
    public class DeleteCourseCommandHandler:IRequestHandler<DeleteCourseCommand>
    {
        private ICourseRepository _courseRepository;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetAsync(src => src.Id == request.Id);
            
            await _courseRepository.DeleteAsync(course);
            
            return Unit.Value;
        }
    }
}