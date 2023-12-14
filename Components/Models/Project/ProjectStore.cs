using AutoMapper;
using SMART.Common.ProjectManagement;
using Daemon.DataAccess.DataStore;


namespace SmartEstimate.Models;

public class ProjectStore { 

    public IModelApi<Project> Api { get; set; }
    public IModelStorage<ProjectView> Storage { get; set; }
    public IReadableModelStore<ProjectView> ReadableStore { get; set; }
    public IWriteableModelStore<Project, ProjectView> WritableStore { get; set; }
   


    public ProjectStore(
        IMapper mapper,
        ProjectApi projectApi
    ) {
        Api = projectApi;
        Storage = new BaseModelStorage<ProjectView>();
        ReadableStore = new BaseReadableModelStore<Project, ProjectView>(
            mapper,
            Storage,
            Api
        );
        WritableStore = new BaseWriteableModelStore<Project, ProjectView>(
            mapper,
            Storage,
            Api
        );
    }
}

