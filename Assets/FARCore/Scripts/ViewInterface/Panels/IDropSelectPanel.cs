namespace FamilyAccountRecorder.ViewInterface.Panels {
    public interface IDropSelectPanel : IViewPanel { 
        string Name { get;set; }
        event System.Action<string> OnCommit;
    }
}