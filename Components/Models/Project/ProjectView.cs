namespace SmartEstimate.Models;


public class ProjectView {
    public string LinkID { get; set; }
    public string Name { get; set; }

    public List<ProjectGroupView> ProjectGroups { get; set; }
}