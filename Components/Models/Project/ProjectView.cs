using SMART.Common.Base;

namespace SmartEstimate.Models;


public class ProjectView : SMARTBaseClass {

    public ProjectView(string LinkID) : base(LinkID) { }

    public string Name { get; set; }

    public List<ProjectGroupView> ProjectGroups { get; set; }
}