using AutoMapper;
using SMART.Common.LibraryManagement;
using SMART.Common.ProjectManagement;


namespace SmartEstimate.Models;

public class SmartEstimateMappingProfile : Profile
{
    public SmartEstimateMappingProfile()
    {
        
        CreateMap<Project, ProjectView>();
        CreateMap<ICollection<Project>, IQueryable<ProjectView>>()
            .ConvertUsing<CollectionToQueryableConverter<Project, ProjectView>>();

        CreateMap<ProjectGroup, ProjectGroupView>();
        CreateMap<ProjectGroups, IQueryable<ProjectGroupView>>()
            .ConvertUsing<CollectionToQueryableConverter<ProjectGroup, ProjectGroupView>>();

        CreateMap<LibraryProduct, LibraryProductView>();
        CreateMap<LibraryProducts, IQueryable<LibraryProductView>>()
            .ConvertUsing<CollectionToQueryableConverter<LibraryProduct, LibraryProductView>>();
    }
}

public class CollectionToQueryableConverter<C, Q>: ITypeConverter<ICollection<C>, IQueryable<Q>>
{
    public IQueryable<Q> Convert(
        ICollection<C> source, 
        IQueryable<Q> destination,
        ResolutionContext context)
    {
        List<Q> views = context.Mapper.Map<List<Q>>(source);
        return views.AsQueryable();
    }
}