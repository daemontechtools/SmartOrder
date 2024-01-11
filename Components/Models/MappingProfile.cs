using AutoMapper;
using SMART.Common.CompanyManagement;
using SMART.Common.LibraryManagement;
using SMART.Common.ProjectManagement;
using SMART.Common.Utility;


namespace SmartEstimate.Models;

public class SmartEstimateMappingProfile : Profile
{
    public SmartEstimateMappingProfile()
    {
        LibraryProduct libraryProduct = new("1");
        libraryProduct.

        CreateMap<Project, ProjectView>().ReverseMap();
        CreateMap<IList<Project>, IQueryable<ProjectView>>()
            .ConvertUsing<ListToQueryableConverter<Project, ProjectView>>();

        CreateMap<ProjectGroup, ProjectGroupView>().ReverseMap();
        CreateMap<ProjectGroups, IQueryable<ProjectGroupView>>()
            .ConvertUsing<ListToQueryableConverter<ProjectGroup, ProjectGroupView>>();

        CreateMap<LibraryProduct, LibraryProductView>().ReverseMap();
        CreateMap<LibraryProducts, IQueryable<LibraryProductView>>()
            .ConvertUsing<ListToQueryableConverter<LibraryProduct, LibraryProductView>>();

        CreateMap<ShipLocation, ShipLocationView>().ReverseMap();
        CreateMap<ShipLocations, IQueryable<ShipLocationView>>()
            .ConvertUsing<ListToQueryableConverter<ShipLocation, ShipLocationView>>();
        CreateMap<Address, AddressView>().ReverseMap();
        CreateMap<Addresses, IQueryable<AddressView>>()
            .ConvertUsing<ListToQueryableConverter<Address, AddressView>>();

        CreateMap<Contact, ContactView>().ReverseMap();
        CreateMap<Contacts, IQueryable<ContactView>>()
            .ConvertUsing<ListToQueryableConverter<Contact, ContactView>>();

        CreateMap<CommunicationLink, CommunicationLinkView>().ReverseMap();
    }
}

public class ListToQueryableConverter<C, Q>: ITypeConverter<IList<C>, IQueryable<Q>>
{
    public IQueryable<Q> Convert(
        IList<C> source, 
        IQueryable<Q> destination,
        ResolutionContext context)
    {
        IList<Q> views = context.Mapper.Map<IList<Q>>(source);
        return views.AsQueryable();
    }
}