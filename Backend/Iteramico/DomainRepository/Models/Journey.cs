﻿using System.Text.Json.Serialization;

namespace DomainRepository.Models
#nullable disable
{
    public class Journey
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual City To { get; set; }

        [JsonIgnore]
        public virtual List<JourneyParticipation> Participations { get; set; } = [];

        public virtual List<Reminder> Reminders { get; set; }
        public virtual List<Event> Events { get; set; }
        public virtual List<Expense> Expenses { get; set; }
        public virtual List<Memory> Memories { get; set; }
    }
}