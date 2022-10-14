﻿namespace AcademicTimePlanner.DataMapping.Plan
{
    public class TimeSpan
    {
        /// <summary>
        /// This class implements a time span.
        /// A time span has a start and an end date.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public TimeSpan(DateTime startDate, DateTime endDate) {
            Id = Guid.NewGuid();
            StartDate = startDate;
            EndDate = endDate;
        }

        public Guid Id { get; }
        
        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
