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

    public IQueryable<ProductView> GetAllProducts() {
        var products = _orderApi.GetProducts();
        return _mapper
            .Map<IList<ProductView>>(products)
            .AsQueryable();
    } 

    public async Task<Dictionary<ProductCategoryTypes, List<ProductView>>> SortProductsByCategory() {
        return await Task.Run((Func<Dictionary<ProductCategoryTypes, List<ProductView>>>)(() => {
            Dictionary<ProductCategoryTypes, List<ProductView>> productsByCategory 
                = new Dictionary<ProductCategoryTypes, List<ProductView>>();
            IList<ProductView> allProducts = _mapper.Map<IList<ProductView>>(
                _orderApi.GetProducts()
            );
            IList<Category> categories = _orderApi.GetAllCategories();
            Category? GetCategory(string categoryLinkId) {
                return categories.FirstOrDefault<Category>(
                    c => c.LinkID == categoryLinkId
                );
            }

            foreach(ProductView product in allProducts) {
                // Ignore irrelevant products
                Category? category = GetCategory(product.LinkIDCategory);
                if(category == null 
                    || category.Type != CategoryTypes.Products
                    || category.CategoryName[0] == '-') {
                    continue;
                }

                // Find Uppers
                if(category.CategoryName == "12 High"
                    || category.CategoryName == "14 High"
                    || category.CategoryName == "15 High"
                    || category.CategoryName == "18 High"
                    || category.CategoryName == "20 High"
                    || category.CategoryName == "21 High"
                    || category.CategoryName == "24 High"
                    || category.CategoryName == "27 High"
                    || category.CategoryName == "28 High"
                    || category.CategoryName == "30 High"
                    || category.CategoryName == "36 High"
                    || category.CategoryName == "40 High"
                    || category.CategoryName == "48 High"
                    || category.CategoryName == "54 High"
                    || category.CategoryName == "58 High"
                    || category.CategoryName == "BayView"
                    || category.CategoryName == "Boat Cabinet"
                    || category.CategoryName == "Carleton"
                    || category.CategoryName == "Collingwood"
                    || category.CategoryName == "Aberdeen"
                    || category.CategoryName == "Delamere"
                    || category.CategoryName == "Door 41 High"
                    || category.CategoryName == "Door/Drawer 41 High"
                    || category.CategoryName == "Floating"
                    || category.CategoryName == "Full Door 41 High"
                    || category.CategoryName == "Hood Fan Cabinets"
                    || category.CategoryName == "Lattice Wine 30 High"
                    || category.CategoryName == "McKellar"
                    || category.CategoryName == "Microwave"
                    || category.CategoryName == "Open Cabinets"
                    || category.CategoryName == "Preston"
                    || category.CategoryName == "Rockcliffe"
                    || category.CategoryName == "T0D"
                    || category.CategoryName == "W0D"

                ) {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Upper)) {
                        productsByCategory[ProductCategoryTypes.Upper] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Upper].Add(product);

                // Find Base
                } else if(category.CategoryName == "2 Drawer"
                    || category.CategoryName == "3 Drawer"
                    || category.CategoryName == "4 Drawer"
                    || category.CategoryName == "5 Drawer"
                    || category.CategoryName == "Backed Up Corner Sink"
                    || category.CategoryName == "Base"
                    || category.CategoryName == "Base Bell Style"
                    || category.CategoryName == "Base Cabinets"
                    || category.CategoryName == "Base End"
                    || category.CategoryName == "Base Finished 1 Side"
                    || category.CategoryName == "Base Finished 2 Sides"
                    || category.CategoryName == "Base Flutted Style"
                    || category.CategoryName == "Base Islands"
                    || category.CategoryName == "Base Shaker Style"
                    || category.CategoryName == "Bench Seat"
                    || category.CategoryName == "Blind Corner"
                    || category.CategoryName == "Cell Wine"
                    || category.CategoryName == "Corner"
                    || category.CategoryName == "Corner Sink"
                    || category.CategoryName == "Corner"
                    || category.CategoryName == "Diagonal Corner"
                    || category.CategoryName == "Door/Base Drawer"
                    || category.CategoryName == "Door/False Drawer"
                    || category.CategoryName == "Double Entry"
                    || category.CategoryName == "Drawer Bank"
                    || category.CategoryName == "Full Door"
                    || category.CategoryName == "Knee Drawer"
                    || category.CategoryName == "Lattice Wine"
                    || category.CategoryName == "Open/Drawer"
                    || category.CategoryName == "Pull Out Waste"
                    || category.CategoryName == "Sink/Cooktop"
                    || category.CategoryName == "Wine Cubby"
                    || category.CategoryName == "Wine Rack (Lattice)"
                    || category.CategoryName == "Wine Rack (Scallop)"

                    || category.CategoryName == "Door" && category!.CategoryFullPath.Contains("Base")
                    || category.CategoryName == "Door/Drawer" && category!.CategoryFullPath.Contains("Base")
                    || category.CategoryName == "End" && category!.CategoryFullPath.Contains("Base")
                    || category.CategoryName == "Scalloped Wine" && category!.CategoryFullPath.Contains("Base")
                ) {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Base)) {
                        productsByCategory[ProductCategoryTypes.Base] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Base].Add(product);

                // Find Tall 
                } else if(category.CategoryName == "Broom"
                    || category.CategoryName == "Closets"
                    || category.CategoryName == "Columns and Walls"
                    || category.CategoryName == "Corner 30 High"
                    || category.CategoryName == "Corner 36 High"
                    || category.CategoryName == "Corner 40 High"
                    || category.CategoryName == "Corner Pie Cut" 
                    || category.CategoryName == "Corner/End"
                    || category.CategoryName == "Fanbox"
                    || category.CategoryName == "Oven"
                    || category.CategoryName == "Pantry"
                    || category.CategoryName == "Pantry/Broom"
                    || category.CategoryName == "Peninsula"
                    || category.CategoryName == "Peninsula 24 High"
                    || category.CategoryName == "Peninsula 30 High"
                    || category.CategoryName == "Peninsula 40 High"
                    || category.CategoryName == "Plate"
                    || category.CategoryName == "Plate Rack"
                    || category.CategoryName == "Murphy Bed Cabinets"
                    || category.CategoryName == "Side Tilt Beds"
                    || category.CategoryName == "Tall Bell Style"
                    || category.CategoryName == "Tall Finished 1 Side"
                    || category.CategoryName == "Tall Finished 2 Sides"
                    || category.CategoryName == "Tall Flutted Style"
                    || category.CategoryName == "Tall Shaker Style"
                    || category.CategoryName == "Tall Veneer Style"
                    || category.CategoryName == "Talls for MBQUEEN"
                    || category.CategoryName == "Talls for MBTWIN-MBDOUBLE"
                    || category.CategoryName == "Vertical Beds"
                    || category.CategoryName == "W1DPC"
                    || category.CategoryName == "Wall Bell Style"
                    || category.CategoryName == "Wall Corner"
                    || category.CategoryName == "Wall Corner Microwave"
                    || category.CategoryName == "Wall Door/Drawer"
                    || category.CategoryName == "Wall Double Bottom"
                    || category.CategoryName == "Wall End"
                    || category.CategoryName == "Wall Fluted Style"
                    || category.CategoryName == "Wall Recessed Bottom"
                    || category.CategoryName == "Wall Shaker Style"
                    || category.CategoryName == "Wall Special"
                    || category.CategoryName == "Wall Veneer Style"
                    || category.CategoryName == "Walls for MBDOUBLEST"
                    || category.CategoryName == "Walls for MBQUEENST"
                    || category.CategoryName == "WC1D 30 High"
                    || category.CategoryName == "WC1D 36 High"
                    || category.CategoryName == "WC1D 40 High"
                    || category.CategoryName == "WC2DWM"

                    || category.CategoryName == "Door/Drawer" && category!.CategoryFullPath.Contains("Tall")
                    || category.CategoryName == "End" && category!.CategoryFullPath.Contains("Wall")
                    || category.CategoryName == "Oven/Microwave" && category!.CategoryFullPath.Contains("Tall")
                    || category.CategoryName == "Scalloped Wine" && category!.CategoryFullPath.Contains("Wall")
                    || category.CategoryName == "Tall 84 High" && category!.CategoryFullPath.Contains("Tall")
                    || category.CategoryName == "Tall 90 High" && category!.CategoryFullPath.Contains("Tall")
                    || category.CategoryName == "Tall 94 High" && category!.CategoryFullPath.Contains("Tall")
                    || category.CategoryName == "Wall" && category!.CategoryFullPath.Contains("Wall")
                ) {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Tall)) {
                        productsByCategory[ProductCategoryTypes.Tall] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Tall].Add(product);            


                // Find Vanities
                } else if(category.CategoryName == "Bridgewater"
                    || category.CategoryName == "Flush Back Vanity"
                    || category.CategoryName == "Hung Vanity"
                    || category.CategoryName == "Light Box"
                    || category.CategoryName == "Lunenberg"
                    || category.CategoryName == "Mahone"
                    || category.CategoryName == "Vanity Finished 1 Sides"
                    || category.CategoryName == "Vanity Finished 2 Sides"

                    || category.CategoryName == "Door"  && category!.CategoryFullPath.Contains("Vanity")
                    || category.CategoryName == "Door/Drawer"  && category!.CategoryFullPath.Contains("Vanity")
                    || category.CategoryName == "Drawer"  && category!.CategoryFullPath.Contains("Vanity")
                    || category.CategoryName == "Linen"  && category!.CategoryFullPath.Contains("Vanity")
                    || category.CategoryName == "Medicine"  && category!.CategoryFullPath.Contains("Vanity")
                    || category.CategoryName == "Vanity"  && category!.CategoryFullPath.Contains("Vanity")
                ) {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Vanity)) {
                        productsByCategory[ProductCategoryTypes.Vanity] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Vanity].Add(product);

                // Find Panels
                } else if(category.CategoryName == "Custom Size"
                    || category.CategoryName == "Custom Size Finished 1 Side"
                    || category.CategoryName == "Custom Size Finished 2 Sides"
                    || category.CategoryName == "Finished Ends"
                    || category.CategoryName == "Panels"
                    || category.CategoryName == "Panels - 2MM Edge"
                    || category.CategoryName == "Panels - Applied"
                    || category.CategoryName == "Shelves"
                    || category.CategoryName == "TAP" 
                    || category.CategoryName == "VAP"
                    || category.CategoryName == "Wall 12 Deep"
                    || category.CategoryName == "Wall 24 Deep"
                    || category.CategoryName == "WAP"
                
                    || category.CategoryName == "Linen" && category!.CategoryFullPath.Contains("Finished Ends")
                    || category.CategoryName == "Medicine" && category!.CategoryFullPath.Contains("Finished Ends")
                    || category.CategoryName == "Tall 84 High" && category!.CategoryFullPath.Contains("Finished Ends")
                    || category.CategoryName == "Tall 90 High" && category!.CategoryFullPath.Contains("Finished Ends")
                    || category.CategoryName == "Tall 94 High" && category!.CategoryFullPath.Contains("Finished Ends")
                    || category.CategoryName == "Vanity"  && category!.CategoryFullPath.Contains("Finished Ends")
                ) {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Panel)) {
                        productsByCategory[ProductCategoryTypes.Panel] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Panel].Add(product);

                // Find Filler
                } else if(category.CategoryName == "Bulkhead Filler"
                    || category.CategoryName == "Cabinet Frames"
                    || category.CategoryName == "DW FIller"
                    || category.CategoryName == "Kickplates"
                    || category.CategoryName == "Kickplates Fillers"
                    || category.CategoryName == "Tall Fillers"
                    || category.CategoryName == "Wall Fillers"

                    || category.CategoryName == "Tall" && category!.CategoryFullPath.Contains("Fillers") // Good exception
                    || category.CategoryName == "Wall" && category!.CategoryFullPath.Contains("Fillers")
                
                    || category.CategoryName.Contains("Filler")
                ) {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Filler)) {
                        productsByCategory[ProductCategoryTypes.Filler] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Filler].Add(product);

                // Find Moulding
                } else if(category.CategoryName == "Mouldings"
                
                ) {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Moulding)) {
                        productsByCategory[ProductCategoryTypes.Moulding] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Moulding].Add(product);

                // Find Accessories
                } else if(category.CategoryName == "Lunch Counter Supports"
                    || category.CategoryName == "Top Hinge"
                    || category.CategoryName == "Wall  Top Hinge"
                ) {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Accessory)) {
                        productsByCategory[ProductCategoryTypes.Accessory] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Accessory].Add(product);

                // Unknown Category
                } else {
                    if(!productsByCategory.ContainsKey(ProductCategoryTypes.Unknown)) {
                        productsByCategory[ProductCategoryTypes.Unknown] = new List<ProductView>();
                    }
                    productsByCategory[ProductCategoryTypes.Unknown].Add(product);
                }
            }

            return productsByCategory;
        }));
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

