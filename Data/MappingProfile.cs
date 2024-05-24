using System.Data;
using AutoMapper;
using SMART.Common.CompanyManagement;
using SMART.Common.LibraryManagement;
using SMART.Common.ProjectManagement;
namespace SO.Data;

public class SmartOrderMappingProfile : Profile {
    public SmartOrderMappingProfile() {
        CreateMap<Project, ProjectFormView>()
            .ForMember(
                dest => dest.IsShipped,
                opt => opt.MapFrom(src => src.LinkIDShipLocation != null)
            )
            .ReverseMap();
        CreateMap<ProjectGroup, ProjectGroupFormView>().ReverseMap();
        CreateMap<Product, ProductFormView>().ReverseMap();
        CreateMap<LibraryProduct, ProductFormView>().ReverseMap();
        CreateMap<ShipLocation, ShipLocationFormView>()
            .ForMember(
                dest => dest.ContactLinkID,
                opt => opt.MapFrom(src => (src.Contacts != null && src.Contacts.Count > 0) ? (src.Contacts as IList<Contact>).FirstOrDefault()!.LinkID ?? "" : "")
            )
            .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.Addresses != null ? (src.Addresses as IList<Address>).FirstOrDefault() ?? new Address() : new Address())
            )
            .ReverseMap();
        CreateMap<Address, AddressFormView>().ReverseMap();
        CreateMap<Contact, ContactFormView>()
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.DefaultEmail.DisplayAs)
            )
            .ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.DefaultPhone.DisplayAs)
            )
            .ReverseMap();
    }
}

public class StringToCommunicationLink : IMemberValueResolver
    <
        ContactFormView,
        Contact, 
        string,
        CommunicationLink
    > {
    public CommunicationLink Resolve(
        ContactFormView source, 
        Contact destination, 
        string sourceMember,
        CommunicationLink destMember, 
        ResolutionContext context
    ) {
        destMember ??= new CommunicationLink();
        destMember.DisplayAs = sourceMember;
        return destMember;
    }
}