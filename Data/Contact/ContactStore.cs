using AutoMapper;
using SMART.Common.ProjectManagement;
using SMART.Common.CompanyManagement;
using Daemon.DataAccess.DataStore;


namespace SO.Data;

public class ContactStore { 

    public IModelApi<Contact> Api { get; set; }
    public IModelStorage<ContactView> Storage { get; set; }
    public IReadableModelStore<ContactView> ReadableStore { get; set; }
    public IWriteableModelStore<Contact, ContactView> WritableStore { get; set; }
   


    public ContactStore(
        IMapper mapper,
        ContactApi contactApi
    ) {
        Api = contactApi;
        Storage = new BaseModelStorage<ContactView>();
        ReadableStore = new BaseReadableModelStore<Contact, ContactView>(
            mapper,
            Storage,
            Api
        );
        WritableStore = new BaseWriteableModelStore<Contact, ContactView>(
            mapper,
            Storage,
            Api
        );
    }
}

