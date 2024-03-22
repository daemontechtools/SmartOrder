using SMART.Common.Base;

namespace SO.Data;


public class SmartBaseClass : SMARTBaseClass {

    public SmartBaseClass() : base("") { }
    public SmartBaseClass(string LinkID) : base(LinkID) { }

    public bool IsPersisted { 
        get { 
            return !string.IsNullOrEmpty(LinkIDFactory); 
        }
    }

    public override bool Equals(object? obj) {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }

        var other = (SmartBaseClass) obj;
        return LinkID == other.LinkID;
    }
    
    public override int GetHashCode() {
        return LinkID.GetHashCode();
    }
}