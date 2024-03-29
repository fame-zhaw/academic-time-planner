﻿using AcademicTimePlanner.DataManagement;
using AcademicTimePlanner.Data.ApplicationData.Plan;
using AcademicTimePlanner.Data.ApplicationData.Toggl;
using AcademicTimePlanner.Data.DisplayData;

namespace AcademicTimePlanner.Services.DataManagerService
{
    /// <summary>
    /// Handles access to the <see cref="DataManager"/> of the current session.
    /// The <see cref="DataManager"/> can only be accessed via this service.
    /// </summary>
    public interface IDataManagerService
    {
        /// <summary>
        /// Updates the Toggl data hold by <see cref="DataManager"/>.
        /// </summary>
        /// <param name="togglProjects"></param>
        /// <returns></returns>
        public Task UpdateTogglProjects(List<TogglProject> togglProjects);

        /// <summary>
        /// Updates the planning data hold by <see cref="DataManager"/>
        /// </summary>
        /// <param name="planProjects"></param>
        /// <returns></returns>
        public Task UpdatePlanProjects(List<PlanProject> planProjects);

        /// <summary>
        /// Updates a <see cref="PlanProject"/> in the <see cref="DataManager"/>
        /// If the project does already exist, it will be overwritten by the new project.
        /// Otherwise, the new project will be added.
        /// </summary>
        /// <param name="planProject"></param>
        /// <returns></returns>
        public Task UpdatePlanProject(PlanProject planProject);

        /// <summary>
        /// Gets the Toggl load overview from the <see cref="DataManager"/>.
        /// </summary>
        /// <returns></returns>
        public Task<List<TogglLoadOverviewData>> GetTogglLoadOverview();

        /// <summary>
        /// Gets the current projects data from the <see cref="DataManager"/>
        /// </summary>
        /// <returns></returns>
        public Task<ProjectsData> GetProjectsData();

        /// <summary>
        /// Gets all plan projects loaded in the <see cref="DataManager"/>
        /// </summary>
        /// <returns></returns>
        public Task<List<PlanProject>> GetPlanProjects();

        /// <summary>
        /// Gets the plan project with the given id from the <see cref="DataManager"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<PlanProject> GetPlanProjectById(Guid id);

        /// <summary>
        /// Deletes the plan project with the given Id from the <see cref="DataManager"/>
        /// </summary>
        /// <param name="planProjectId"></param>
        /// <returns></returns>
        public Task DeletePlanProject(Guid planProjectId);
    }
}
