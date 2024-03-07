using System.Drawing.Printing;
using AutoMapper;
using SMART.Common.CompanyManagement;
using SMART.Common.LibraryManagement;
using SMART.Common.ProjectManagement;
using SMART.Common.Utility;

namespace SO.Data;

public class SmartOrderMappingProfile : Profile {
    public SmartOrderMappingProfile() {
        CreateMap<Project, ProjectFormView>().ReverseMap();
        CreateMap<ProjectGroup, ProjectGroupFormView>().ReverseMap();
        CreateMap<Product, ProductFormView>().ReverseMap();
        CreateMap<LibraryProduct, ProductFormView>().ReverseMap();
        CreateMap<ShipLocation, ShipLocationFormView>().ReverseMap();
        CreateMap<Address, AddressFormView>().ReverseMap();
        CreateMap<Contact, ContactFormView>().ReverseMap();
    }
}