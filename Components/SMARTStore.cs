using SMART.Common.ProjectManagement;
using SMART.Common.LibraryManagement;
using SMART.Web.OrderApi;

using SmartEstimate.Models;
using AutoMapper;

public class SMARTStore {
    private IQueryable<ProjectView> _projects { get; set; } = new List<ProjectView>().AsQueryable();
    //public LibraryProducts Products { get; set; }

    private ILogger<SMARTStore> _logger;
    private IMapper _mapper;
    private OrderApi _orderApi;

    public SMARTStore(
        ILogger<SMARTStore> logger,
        IMapper mapper,
        OrderApi orderApi
    ) {
        _logger = logger;
        _mapper = mapper;
        _orderApi = orderApi;
    }

    public event EventHandler? OnStateChanged;
    public void StateChanged() => OnStateChanged?.Invoke(this, EventArgs.Empty);

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

    public async Task<IQueryable<ProjectView>> GetProjects(
        bool forceRefresh = false
    ) {
        if(_projects.Any() && !forceRefresh) {
            _logger.LogInformation("Using Projects from cache");
            return _projects;
        }

        _logger.LogInformation("Getting projects from SMART");
        await Connect();
        Projects projects = await _orderApi.GetProjects();
        IQueryable<ProjectView> projectViews = _mapper.Map<IQueryable<ProjectView>>(projects);
        _projects = projectViews;
        return _projects;
    }

    public async Task<ProjectView> GetProjectById(string id) {
        if(!_projects.Any()) {
            await GetProjects();
        }
        
        ProjectView? project = _projects.Where(p => p.LinkID == id).FirstOrDefault();
        if(project == null) {
            throw new Exception($"Project with id {id} not found");
        }
        return project;
    }

    // Get Projects
    // Get Project by Id

    // Get ProjectGroups
    // Get ProjectGroup by Id

    // Get Products
}