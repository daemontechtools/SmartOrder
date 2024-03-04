using SMART.Common.Base;

namespace SO.Data;


public class SMARTBaseClassView : SMARTBaseClass {
    public SMARTBaseClassView(string LinkID) : base(LinkID) { }

    public override bool Equals(object? obj) {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }

        SMARTBaseClassView other = (SMARTBaseClassView) obj;
        return LinkID == other.LinkID;
    }
    
    public override int GetHashCode() {
        return LinkID.GetHashCode();
    }
}