using Application.Features.CourseTech.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.CourseTech.Queries.GetCourseTechById;

public class GetCourseTechByIdQueries:IRequest<CourseTechDto>
{
    public Guid Id { get; set; }

    public class GetCourseTechByIdQueryHandler : IRequestHandler<GetCourseTechByIdQueries, CourseTechDto>
    {
        public GetCourseTechByIdQueryHandler(ICourseTechRepository courseTechRepository, IMapper mapper)
        {
            _courseTechRepository = courseTechRepository;
            _mapper = mapper;
        }

        private readonly ICourseTechRepository _courseTechRepository;
        private readonly IMapper _mapper;
        public async Task<CourseTechDto> Handle(GetCourseTechByIdQueries request, CancellationToken cancellationToken)
        {
            var courseTech = await _courseTechRepository.GetAsync(src=>src.Id==request.Id);

            var mappedCourseTech = _mapper.Map<CourseTechs, CourseTechDto>(courseTech);

            return mappedCourseTech;
        }
    }
}