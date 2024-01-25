namespace FamilyAccountRecorder.ViewInterface.Panels {
    public interface IFamilySelectPanel : IViewPanel { 
        string Name { get; set; }
        event System.Action<string> OnCommit;
    }
}