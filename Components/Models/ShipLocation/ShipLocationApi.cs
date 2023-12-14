using Daemon.DataAccess.DataStore;
using SMART.Common.CompanyManagement;
using SMART.Web.OrderApi;


public class ShipLocationApi : IModelApi<ShipLocation> {

    private readonly OrderApi _orderApi;
    private readonly ILogger<ShipLocationApi> _logger;

    public ShipLocationApi(
        OrderApi orderApi,
        ILogger<ShipLocationApi> logger
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
                //FactoryLinkId = "078DP04B0284",
                // DealerName = "Tamarack",
                // UserName = "Tamarack Agent"
            });
            await _orderApi.LoadLibrary();
        } catch(Exception e) {
            _logger.LogError(e, "Failed to connect to SMART");
            Console.WriteLine(e);
        }
    }

    public async Task<IList<ShipLocation>> Get() {
        await Connect();
        return _orderApi.GetShipLocations();
    }

    public async Task<ShipLocation> Create(ShipLocation shipLocation) {
        await Connect();
        await _orderApi.AddShipLocation(shipLocation);
        IList<ShipLocation> locations = _orderApi.GetShipLocations();
        IQueryable<ShipLocation> queryable = locations.AsQueryable();
        ShipLocation? newModel = queryable.Where(l => l.LinkID == shipLocation.LinkID).FirstOrDefault();
        if(newModel is null) {
            throw new Exception("Failed to create Ship Location");
        }
        return newModel;
    }

    public Task Delete(ShipLocation location) {
        _logger.LogWarning("Delete not implemented");
        return Task.CompletedTask;
    }

    public Task<ShipLocation> Update(ShipLocation location) {
        _logger.LogWarning("Update not implemented");
        return Task.FromResult(location);
    }
}