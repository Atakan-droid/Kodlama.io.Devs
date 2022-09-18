using Application.Features.Courses.Dtos;
using Application.Features.CourseTech.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.CourseTech.Commands.CreateCourseTech;

public class CreateCourseTechCommand:IRequest<CreateCourseTechDto>
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public class CreateCourseTechCommandHandler : IRequestHandler<CreateCourseTechCommand, CreateCourseTechDto>
    {
        public CreateCourseTechCommandHandler(ICourseTechRepository courseTechRepository, IMapper mapper)
        {
            _courseTechRepository = courseTechRepository;
            _mapper = mapper;
        }

        private readonly ICourseTechRepository _courseTechRepository;
        private readonly IMapper _mapper;
        
        public async Task<CreateCourseTechDto> Handle(CreateCourseTechCommand request, CancellationToken cancellationToken)
        {
            var courseTech = _mapper.Map<CourseTechs>(request);
            var createdCourse = await _courseTechRepository.AddAsync(courseTech);

            CreateCourseTechDto createdCourseDto = _mapper.Map<CreateCourseTechDto>(createdCourse);

            return createdCourseDto;
        }
    }
}