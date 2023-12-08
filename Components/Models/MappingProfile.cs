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
        // IList<Project> projects = new Projects();
        // IList<Project> projectList = new Projects();
        // projectList.As
        // List<Project> projects1 = new Projects();

        CreateMap<Project, ProjectView>().ReverseMap();
        CreateMap<IList<Project>, IQueryable<ProjectView>>()
            .ConvertUsing<CollectionToQueryableConverter<Project, ProjectView>>();

        CreateMap<ProjectGroup, ProjectGroupView>().ReverseMap();
        CreateMap<ProjectGroups, IQueryable<ProjectGroupView>>()
            .ConvertUsing<CollectionToQueryableConverter<ProjectGroup, ProjectGroupView>>();

        CreateMap<LibraryProduct, LibraryProductView>().ReverseMap();
        CreateMap<LibraryProducts, IQueryable<LibraryProductView>>()
            .ConvertUsing<CollectionToQueryableConverter<LibraryProduct, LibraryProductView>>();
    }
}

public class CollectionToQueryableConverter<C, Q>: ITypeConverter<IList<C>, IQueryable<Q>>
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