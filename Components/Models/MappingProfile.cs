using AutoMapper;
using SMART.Common.ProjectManagement;


namespace SmartEstimate.Models;

public class SmartEstimateMappingProfile : Profile
{
    public SmartEstimateMappingProfile()
    {
        
        CreateMap<Project, ProjectView>().ReverseMap();
        CreateMap<Projects, IQueryable<ProjectView>>()
            .ConvertUsing<CollectionToQueryableConverter<Project, ProjectView>>();

        CreateMap<ProjectGroup, ProjectGroupView>().ReverseMap();
        CreateMap<ProjectGroups, IQueryable<ProjectGroupView>>()
            .ConvertUsing<CollectionToQueryableConverter<ProjectGroup, ProjectGroupView>>();
        
        // OLD Models
        CreateMap<Quote, QuoteView>().ReverseMap();
        CreateMap<Room, RoomView>().ReverseMap();
        CreateMap<Product, ProductView>().ReverseMap();
    }
}

// public class ProjectGroupConverter: ITypeConverter<ProjectGroups, IQueryable<ProjectGroupView>>
// {
//     public IQueryable<ProjectGroupView> Convert(
//         ProjectGroups source, 
//         ResolutionContext context)
//     {
//         List<ProjectGroupView> views = context.Mapper.Map<List<ProjectGroupView>>(source);
//         return views.AsQueryable();
//     }
// }

public class CollectionToQueryableConverter<T, V>: ITypeConverter<ICollection<T>, IQueryable<V>>
{
    public IQueryable<V> Convert(
        ICollection<T> source, 
        IQueryable<V> destination,
        ResolutionContext context)
    {
        List<V> views = context.Mapper.Map<List<V>>(source);
        return views.AsQueryable();
    }
}
