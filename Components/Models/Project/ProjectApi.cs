using Daemon.DataAccess.DataStore;
using SMART.Common.ProjectManagement;
using SMART.Web.OrderApi;


public class ProjectApi : IModelApi<Project> {

    private readonly OrderApi _orderApi;
    private readonly ILogger<ProjectApi> _logger;

    public ProjectApi(
        OrderApi orderApi,
        ILogger<ProjectApi> logger
    ) {
        _orderApi = orderApi;
        _logger = logger;
    }

    public async Task<IList<Project>> Get() {
        return await _orderApi.GetProjects();
    }

    public async Task<Project> Create(Project project) {
        await _orderApi.AddQuote(project.Name);
        IList<Project> projects = await _orderApi.GetProjects();
        IQueryable<Project> queryable = projects.AsQueryable();
        Project? newModel = queryable.Where(p => p.Name == project.Name).FirstOrDefault();
        if(newModel is null) {
            throw new Exception("Failed to create project");
        }
        return newModel;
    }

    public async Task Delete(Project project) {
        await _orderApi.DeleteProject(project.LinkID);
    }

    public Task<Project> Update(Project project) {
        //await Connect();
        //await _orderApi.UpdateProject(project);
        return Task.FromResult(project);
    }
}