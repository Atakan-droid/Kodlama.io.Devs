using Application.Features.Courses.Dtos;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Courses.Queries.GetCourseByIdQuery.cs;

public class GetCourseByIdQuery:IRequest<CourseDto>
{
    public Guid Id { get; set; }
    public class GetCourseByIdQueryHandler:IRequestHandler<GetCourseByIdQuery,CourseDto>
    {
        public GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAsync(src => src.Id == request.Id && !src.IsDeleted);

            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }
    }
}