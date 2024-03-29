﻿using AcademicTimePlanner.Data.ApplicationData.Plan;

namespace AcademicTimePlanner.Store.State.ProjectFiles
{
    public class FinishPlanProjectCreationAction
    {
        public PlanProject PlanProject { get; }

        public FinishPlanProjectCreationAction(PlanProject planProject)
        {
            PlanProject = planProject;
        }
    }
}
