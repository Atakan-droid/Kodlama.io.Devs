using Application.Features.Courses.Commands.CreateCourse;
using Application.Features.Courses.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand:IRequest<UpdatedCourseDto>
{
    public string CourseName { get; set; }
    public double Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdatedCourseDto>
    {
        public UpdateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        
        public async Task<UpdatedCourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            var updateCourse= await _courseRepository.AddAsync(course);

            UpdatedCourseDto updateCourseDto = _mapper.Map<UpdatedCourseDto>(updateCourse);

            return updateCourseDto;
        }
    }
}