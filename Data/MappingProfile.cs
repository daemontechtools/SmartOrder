using System.Drawing.Printing;
using AutoMapper;
using SMART.Common.CompanyManagement;
using SMART.Common.LibraryManagement;
using SMART.Common.ProjectManagement;
using SMART.Common.Utility;

namespace SO.Data;

public class SmartOrderMappingProfile : Profile
{
    public SmartOrderMappingProfile() {
        // ProjectGroup a = new ProjectGroup("a");
        // LibraryProduct p = new LibraryProduct("p");
        //ProjectGroup g = new ProjectGroup("g");
        //g.ProductSlide = "s";
        // Product product = new();
        //product.LinkID = "p";
        //CategoryTypes.
        //LibraryStyleConfiguration style = new("");
        //style

        CreateMap<Project, ProjectView>().ReverseMap();
        // CreateMap<Projects, IQueryable<ProjectView>>()
        //     .ConvertUsing<ListToQueryableConverter<Project, ProjectView>>();

        CreateMap<ProjectGroup, ProjectGroupView>().ReverseMap();
        // CreateMap<ProjectGroups, IQueryable<ProjectGroupView>>()
        //     .ConvertUsing<ListToQueryableConverter<ProjectGroup, ProjectGroupView>>();

        CreateMap<Product, ProductView>().ReverseMap();
        // CreateMap<Products, IQueryable<ProductView>>()
        //     .ConvertUsing<ListToQueryableConverter<Product, ProductView>>();
            
        CreateMap<LibraryProduct, ProductView>().ReverseMap();
        // CreateMap<LibraryProducts, IQueryable<ProductView>>()
        //     .ConvertUsing<ListToQueryableConverter<LibraryProduct, ProductView>>();

        CreateMap<ShipLocation, ShipLocationView>().ReverseMap();
        // CreateMap<ShipLocations, IQueryable<ShipLocationView>>()
        //      .ConvertUsing<ListToQueryableConverter<ShipLocation, ShipLocationView>>();
        CreateMap<Address, AddressView>().ReverseMap();
        // CreateMap<Addresses, IQueryable<AddressView>>()
        //     .ConvertUsing<ListToQueryableConverter<Address, AddressView>>();

        CreateMap<Contact, ContactView>().ReverseMap();
        // CreateMap<Contacts, IQueryable<ContactView>>()
        //     .ConvertUsing<ListToQueryableConverter<Contact, ContactView>>();

        CreateMap<CommunicationLink, CommunicationLinkView>().ReverseMap();
    }
}

// public class ListToQueryableConverter<C, Q>: ITypeConverter<IList<C>, IQueryable<Q>>
// {
//     public IQueryable<Q> Convert(
//         IList<C> source, 
//         IQueryable<Q> destination,
//         ResolutionContext context)
//     {
//         IList<Q> views = context.Mapper.Map<IList<Q>>(source);
//         return views.AsQueryable();
//     }
// }