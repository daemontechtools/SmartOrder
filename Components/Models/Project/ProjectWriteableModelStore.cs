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
        Project newProject = await _api.Create(view.Name);
        ProjectView newView = _mapper.Map<ProjectView>(newProject);
        await base.Create(newView);
        return newView;
    }

    public override async Task Delete(ProjectView view) {
        Project removedProject = _mapper.Map<Project>(view);
        await _api.Delete(removedProject);
        await base.Delete(view);
    }
}