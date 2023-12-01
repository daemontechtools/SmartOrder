using Daemon.DataAccess.DataStore;
using SMART.Common.ProjectManagement;
using SMART.Web.OrderApi;
using SMART.Common.Base;
using SMART.Common;


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

    private async Task Connect() {
         if(_orderApi.IsConnected()) {
            return;
         }

        try {
            _logger.LogInformation("Connecting to SMART");
            await _orderApi.Connect(new ApiCreds {
                FactoryLinkId = "0818M26D1TT4",
                DealerName = "Bathrooms First",
                UserName = "Bathrooms First Agent"
            });
            await _orderApi.LoadLibrary();
        } catch(Exception e) {
            _logger.LogError(e, "Failed to connect to SMART");
            Console.WriteLine(e);
        }
    }

    public async Task<ICollection<Project>> Get() {
        await Connect();
        return await _orderApi.GetProjects();
    }

    public async Task<Project> Create(string name) {
        await Connect();
        await _orderApi.AddQuote(name);
        ICollection<Project> projects = await _orderApi.GetProjects();
        IQueryable<Project> queryable = projects.AsQueryable();
        Project? newModel = queryable.Where(p => p.Name == name).FirstOrDefault();
        if(newModel is null) {
            throw new Exception("Failed to create project");
        }
        return newModel;
    }
}