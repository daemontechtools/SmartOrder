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

    public async Task<IList<ShipLocation>> Get() {
        return _orderApi.GetShipLocations();
    }

    public async Task<ShipLocation> Create(ShipLocation shipLocation) {
        await _orderApi.AddShipLocation(shipLocation);
        IList<ShipLocation> locations = _orderApi.GetShipLocations();
        IQueryable<ShipLocation> queryable = locations.AsQueryable();
        ShipLocation? newModel = queryable.Where(l => l.LinkID == shipLocation.LinkID).FirstOrDefault();
        if(newModel is null) {
            throw new Exception("Failed to create Ship Location");
        }
        return newModel;
    }

    public async Task<ShipLocation> Update(ShipLocation location) {
        await _orderApi.UpdateShipLocation(location.LinkID);
        return location;
    }

    public async Task Delete(ShipLocation location) {
        await _orderApi.DeleteShipLocation(location.LinkID);
    }
}