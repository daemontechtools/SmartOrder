using AutoMapper;
using SMART.Common.CompanyManagement;
using Daemon.DataAccess.DataStore;


namespace SmartEstimate.Models;

public class ShipLocationStore { 

    public IModelApi<ShipLocation> Api { get; set; }
    public IModelStorage<ShipLocationView> Storage { get; set; }
    public IReadableModelStore<ShipLocationView> ReadableStore { get; set; }
    public IWriteableModelStore<ShipLocation, ShipLocationView> WritableStore { get; set; }
   


    public ShipLocationStore(
        IMapper mapper,
        ShipLocationApi shipLocationApi
    ) {
        Api = shipLocationApi;
        Storage = new BaseModelStorage<ShipLocationView>();
        ReadableStore = new BaseReadableModelStore<ShipLocation, ShipLocationView>(
            mapper,
            Storage,
            Api
        );
        WritableStore = new BaseWriteableModelStore<ShipLocation, ShipLocationView>(
            mapper,
            Storage,
            Api
        );
    }
}