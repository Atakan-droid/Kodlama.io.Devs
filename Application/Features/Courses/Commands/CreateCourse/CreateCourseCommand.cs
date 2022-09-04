using Application.Features.Courses.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommand:IRequest<CreatedCourseDto>
{
    public string CourseName { get; set; }
    public double Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreatedCourseDto>
    {
        public CreateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        
        public async Task<CreatedCourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            var createdCourse = await _courseRepository.AddAsync(course);

            CreatedCourseDto createdCourseDto = _mapper.Map<CreatedCourseDto>(createdCourse);

            return createdCourseDto;
        }
    }
}