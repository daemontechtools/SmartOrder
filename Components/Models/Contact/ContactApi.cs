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

    public Task<IList<Contact>> Get() {
        return Task.FromResult(_orderApi.GetContacts());
    }

    public Task<Contact> Create(Contact contact) {
        return Task.FromResult(new Contact(""));
        //return await _orderApi.AddContact(contact);
    }

    public async Task Delete(Contact contact) {
        await _orderApi.DeleteContact(contact.LinkID);
    }

    public async Task<Contact> Update(Contact contact) {
        return await _orderApi.UpdateContact(contact.LinkID);
    }
}