﻿using AcademicTimePlanner.DataMapping.Plan;
using AcademicTimePlanner.DataMapping.Toggl;

namespace AcademicTimePlanner.Data
{
    public class ChartData
    {
        public List<TogglProject> TogglProjects { get; }

        public List<PlanProject> PlanProjects { get; }

        public double TotalTrackedTime { get; }

        public double TotalPlannedTime { get; }

        public double RemainingDuration { get; }

        /// <summary>
        /// This class holds all data needed for the graphical overview of planning and tracked time data.
        /// </summary>
        /// <param name="togglProjects"></param>
        /// <param name="planProjects"></param>
        public ChartData(List<TogglProject> togglProjects, List<PlanProject> planProjects)
        {
            TogglProjects = togglProjects;
            PlanProjects = planProjects;
            TotalTrackedTime = (from togglProject in togglProjects select togglProject.GetTotalDuration()).Sum();
            TotalPlannedTime = (from planProject in planProjects select planProject.GetTotalDuration()).Sum();
            RemainingDuration = (from planProject in planProjects select planProject.GetRemainingDuration()).Sum();
        }

        public TogglProject? GetTogglProjectWithTogglId(long id)
        {
            return TogglProjects.FindLast(togglProject => togglProject.TogglId == id);
        }
    }
}
