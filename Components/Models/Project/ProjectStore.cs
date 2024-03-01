using AutoMapper;
using SMART.Common.ProductionManagement;
using SMART.Common.ProjectManagement;
using SMART.Common.LibraryManagement;
using Daemon.DataAccess.DataStore;
using SMART.Web.OrderApi;
using SMART.Common.Utility;
using System.Runtime.CompilerServices;


namespace SmartEstimate.Models;

public class ProjectStore { 

    private readonly OrderApi _orderApi;
    private readonly IMapper _mapper;
    
    public IModelApi<Project> Api { get; set; }
    public IModelStorage<ProjectView> Storage { get; set; }
    public IReadableModelStore<ProjectView> ReadableStore { get; set; }
    public IWriteableModelStore<Project, ProjectView> WritableStore { get; set; }
   
    public Dictionary<ProductCategoryTypes, List<ProductView>> ProductsByCategory { get; set; } 
        = new Dictionary<ProductCategoryTypes, List<ProductView>>();


    public ProjectStore(
        IMapper mapper,
        OrderApi orderApi,
        ProjectApi projectApi
    ) {
        _orderApi = orderApi;
        _mapper = mapper;
        
        Api = projectApi;
        Storage = new BaseModelStorage<ProjectView>();
        ReadableStore = new BaseReadableModelStore<Project, ProjectView>(
            mapper,
            Storage,
            Api
        );
        WritableStore = new BaseWriteableModelStore<Project, ProjectView>(
            mapper,
            Storage,
            Api
        );
    }

    public IQueryable<ProductView> GetAllCabinets() {
        var allCabinets = _orderApi.GetAllCabinets();
        return _mapper
            .Map<IList<ProductView>>(allCabinets)
            .AsQueryable();
    } 

    public Dictionary<ProductCategoryTypes, List<ProductView>> GetSortedCabinets() {
        var sortedCabinets = _orderApi.GetSortedCabinets();
        return _mapper
            .Map<Dictionary<ProductCategoryTypes, List<ProductView>>>(sortedCabinets);
    }

    public float GetProductPrice(
        ProductView productView,
        string doorStyleName
    ) {
        //var libraryProduct = _mapper.Map<LibraryProduct>(productView);
        var libraryProduct = _orderApi
            .GetProducts()
            .FirstOrDefault(p => p.LinkID == productView.LinkID)
        ?? throw new Exception("Unable to find Library Product with LinkID: "+productView.LinkID);
        
        libraryProduct.Width = productView.Width;
        libraryProduct.Height = productView.Height;
        libraryProduct.Depth = productView.Depth;
        libraryProduct.ProductFinishInterior = productView.ProductFinishInterior;
        libraryProduct.ProductLeftSide = productView.ProductLeftSide;
        libraryProduct.ProductRightSide = productView.ProductRightSide;
        libraryProduct.ProductSlide = productView.ProductSlide;
        libraryProduct.ProductDoorSwing = productView.ProductDoorSwing;

        return _orderApi.GetProductPrice(
            libraryProduct,
            productView.Width,
            productView.Height,
            productView.Depth,
            doorStyleName,
            productView.Comments
        );
    }


    public async Task<ProjectGroupView> GetRoomById(
        string linkId,
        string projectLinkId
    ) {
        IList<Project> projects = await _orderApi.GetProjects();
        Project? project = projects.FirstOrDefault(
            p => p.LinkID == projectLinkId
        );
        if (project == null) {
            throw new Exception("Project not found");
        }
        IList<ProjectGroup> projectGroups = project.ProjectGroups;
        ProjectGroup? room = projectGroups.FirstOrDefault(
            r => r.LinkID == linkId
        );
        if (room == null) {
            throw new Exception("Room not found");
        }
        return _mapper.Map<ProjectGroupView>(room);
    }

    public async Task<ProjectGroupView> AddRoom(
        string projectLinkId,
        ProjectGroupView room
    ) {
        ProjectGroup newRoomModel = await _orderApi.AddRoom(
            projectLinkId,
            room.Name
        );
        await _orderApi.UpdateRoomWithId(
            projectLinkId,
            newRoomModel.LinkID,
            newRoomModel.Name
        );
        await ReadableStore.FetchModels();
        return _mapper.Map<ProjectGroupView>(newRoomModel);
    }

    public async Task<ProjectGroupView> UpdateRoom(
        string projectLinkId,
        ProjectGroupView room
    ) {
        await _orderApi.UpdateRoomWithId(
            projectLinkId,
            room.LinkID,
            room.Name
        );
        Storage.StateChanged();
        return room;
    }
}

