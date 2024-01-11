using Daemon.DataAccess.DataStore;
using SMART.Common.CompanyManagement;
using SMART.Web.OrderApi;


public class ContactApi : IModelApi<Contact> {

    private readonly OrderApi _orderApi;
    private readonly ILogger<ContactApi> _logger;

    public ContactApi(
        OrderApi orderApi,
        ILogger<ContactApi> logger
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

    public Task<IList<Contact>> Get() {
        return Task.FromResult(_orderApi.GetContacts());
    }

    public async Task<Contact> Create(Contact contact) {
        await Connect(); 
        return new Contact("");
        //return await _orderApi.AddContact(contact);
    }

    public async Task Delete(Contact contact) {
        await Connect();
        //await _orderApi.DeleteContact(contact);
    }

    public async Task<Contact> Update(Contact contact) {
        await Connect();
        return new Contact("");
        //await _orderApi.UpdateContact(contact);
    }
}