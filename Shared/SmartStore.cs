using AutoMapper;
using Daemon.DataAccess.DataStore;
using SMART.Common.CompanyManagement;
using SMART.Common.ProjectManagement;
using SMART.Web.OrderApi;



public class SmartStore {

    private readonly ILogger<ProjectApi> _logger;
    private readonly IMapper _mapper;
    private readonly OrderApi _orderApi;

    public SmartStore(
        ILogger<ProjectApi> logger,
        IMapper mapper,
        OrderApi orderApi
        
    ) {
        _logger = logger;
        _mapper = mapper;
        _orderApi = orderApi;
        
    }

private async Task Connect() {
         if(_orderApi.IsConnected()) {
            return;
         }

        try {
            _logger.LogInformation("Connecting to SMART");
            await _orderApi.Connect(new ApiCreds {
                //FactoryLinkId = "0818M26D1TT4",
                //DealerName = "Bathrooms First",
                FactoryLinkId = "078DP04B0284",
                DealerName = "Tamarack",
                UserName = "Tamarack Agent"
            });
            await _orderApi.LoadLibrary();
        } catch(Exception e) {
            _logger.LogError(e, "Failed to connect to SMART");
            Console.WriteLine(e);
        }
    }

    public async Task<IList<ShipLocation>> GetShipLocations() {
        await Connect();
        return _orderApi.GetShipLocations();
    }
}