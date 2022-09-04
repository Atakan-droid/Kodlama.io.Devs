using Application.Features.Courses.Dtos;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Courses.Queries.GetListCourse.cs;

public class GetListCourseQuery:IRequest<CourseListDto>
{
    public class GetListCourseQueryHandler:IRequestHandler<GetListCourseQuery,CourseListDto>
    {
        public GetListCourseQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public async Task<CourseListDto> Handle(GetListCourseQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetListAsync();
            var coursesDto = _mapper.Map<List<CourseDto>>(courses);
            var courseDto = new CourseListDto();
            courseDto.courses = coursesDto;
            return courseDto;
        }
    }
}