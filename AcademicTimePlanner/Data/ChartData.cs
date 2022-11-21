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
        /// <param name="allTogglProjects"></param>
        /// <param name="planProjects"></param>
        public ChartData(List<TogglProject> allTogglProjects, List<PlanProject> planProjects)
        {
            TogglProjects = new List<TogglProject>();
            PlanProjects = new List<PlanProject>(planProjects);
            foreach (TogglProject togglProject in allTogglProjects)
            {
                if (planProjects.Exists(planProject => planProject.TogglProjectId == togglProject.TogglId))
                    TogglProjects.Add(togglProject);
            }
            TotalTrackedTime = (from togglProject in TogglProjects select togglProject.GetTotalDuration()).Sum();
            TotalPlannedTime = (from planProject in planProjects select planProject.GetTotalDuration()).Sum();
            RemainingDuration = (from planProject in planProjects select planProject.GetRemainingDuration()).Sum();
        }

        public TogglProject? GetTogglProjectWithTogglId(long id)
        {
            return TogglProjects.FindLast(togglProject => togglProject.TogglId == id);
        }
    }
}
