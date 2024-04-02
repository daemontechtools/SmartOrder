using SMART.Web.OrderApi;
namespace SO.Components;

public class SmartService {
    
    private SmartOrderApi _orderApi;
    private SmartOrderClient? _client;
    
    public SmartService(
        SmartOrderApi orderApi
    ) {
        _orderApi = orderApi;
    }

    public async Task<SmartOrderClient> Login(
        string factoryId,
        string dealerId,
        string userName
    ) {
        if(_client == null) {
            _client = await _orderApi.Login(
                factoryId,
                dealerId,
                userName,
                true
            ); 
        }
        return _client;
    }

    public SmartOrderClient GetClient() {
        if(_client == null) {
            throw new Exception("Client not logged in");
        }
        return _client;
    }
}