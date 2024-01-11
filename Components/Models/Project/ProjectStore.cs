using AutoMapper;
using SMART.Common.ProjectManagement;
using Daemon.DataAccess.DataStore;
using SMART.Web.OrderApi;


namespace SmartEstimate.Models;

public class ProjectStore { 

    private readonly OrderApi _orderApi;
    private readonly IMapper _mapper;
    
    public IModelApi<Project> Api { get; set; }
    public IModelStorage<ProjectView> Storage { get; set; }
    public IReadableModelStore<ProjectView> ReadableStore { get; set; }
    public IWriteableModelStore<Project, ProjectView> WritableStore { get; set; }
   


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

