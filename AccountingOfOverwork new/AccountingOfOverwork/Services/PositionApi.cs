using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services.Dto;

namespace AccountingOfOverwork.Services
{
    public class PositionApi
    {
        private readonly IRepository<Position> positionRepository;

        public PositionApi(IRepository<Position> positionRepository)
        {
            this.positionRepository = positionRepository;
        }

        public List<PositionDto> GetPositions()
        {
            return positionRepository.AsQueryable()
                .Select(p => new PositionDto
                                 {
                                     Title = p.Title,
                                     HourlyRate = p.HourlyRate,
                                 })
                .ToList();
        }

        public void AddPosition(PositionDto positionDto)
        {
            positionRepository.Add(new Position(positionDto.Title, positionDto.HourlyRate));
        }

        public void RemovePosition(PositionDto positionDto)
        {
            var position = positionRepository.AsQueryable()
                .Single(p => p.Title == positionDto.Title);
            positionRepository.Remove(position);
        }
    }
}
