using MetWorkingMatch.Domain.Interfaces;
using System;

namespace MetWorkingMatch.Domain.Entities
{
    public class Match : IEntity
    {
        public Match()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdAmigo { get; set; }
        public DateTime dataConexao { get; set; }
    }
}
