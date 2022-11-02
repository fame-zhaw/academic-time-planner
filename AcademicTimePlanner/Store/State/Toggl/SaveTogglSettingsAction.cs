﻿using AcademicTimePlanner.Data;

namespace AcademicTimePlanner.Store.State.Toggl
{
    public class SaveTogglSettingsAction
    {
		public TogglSettings TogglSettings { get; set; }

		public SaveTogglSettingsAction(TogglSettings togglSettings)
		{
			TogglSettings = togglSettings;
		}
    }
}
