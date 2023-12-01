using AutoMapper;
using SMART.Common.ProjectManagement;
using Daemon.DataAccess.DataStore;
 

namespace SmartEstimate.Models;

public class ProjectWriteableModelStore : BaseWriteableModelStore<Project, ProjectView> {

    public ProjectWriteableModelStore(
        IMapper mapper,
        IModelStorage<ProjectView> storage,
        IModelApi<Project> api
    ) : base(mapper, storage, api) { }

    public override async Task<ProjectView> Create(ProjectView view) {
        return await base.Create(view);
    }
}