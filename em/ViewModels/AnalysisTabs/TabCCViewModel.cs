namespace em.ViewModels.AnalysisTabs;

public class TabCCViewModel : INotifyPropertyChanged
{
    private ObservableCollection<DataUse> _DataTableCC = new();
    public ObservableCollection<DataUse> DataTableCC
    {
        get => _DataTableCC;
        set
        {
            Set(ref _DataTableCC, value);
        }
    }

    private bool _IsGroupEnabled = false;
    public bool IsGroupEnabled
    {
        get => _IsGroupEnabled;
        set
        {
            Set(ref _IsGroupEnabled, value);
        }
    }

    #region INotifyProperty

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
    protected bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(PropertyName);
        return true;
    }
    #endregion


}
