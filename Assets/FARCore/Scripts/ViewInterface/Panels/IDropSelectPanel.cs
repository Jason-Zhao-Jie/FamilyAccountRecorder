namespace FamilyAccountRecorder.ViewInterface.Panels {
    public interface IDropSelectPanel : IViewPanel { 
        string Name { get;set; }
        event System.Func<string> OnCommit;
    }
}