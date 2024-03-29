﻿using AcademicTimePlanner.Data.ApplicationData.Plan;

namespace AcademicTimePlanner.Store.State.ProjectFiles
{
    public class SwitchCreationStepAction
    {
        public ProjectFilesState.CreationStep NextStep { get; }

        public PlanProject? PlanProject { get; }

        public SwitchCreationStepAction(ProjectFilesState.CreationStep nextStep, PlanProject? planProject)
        {
            NextStep = nextStep;
            PlanProject = planProject;
        }   
    }
}
