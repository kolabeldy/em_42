namespace em.ViewModels;

public class AnalysisForCCViewModel : AnalysisViewModelBase
{
    private ObservableCollection<DataUse> _DataUseGroupER = new();
    public ObservableCollection<DataUse> DataUseGroupER
    {
        get => _DataUseGroupER;
        set
        {
            Set(ref _DataUseGroupER, value);
        }
    }
    private CaptionCardControl _TitleCardPeriod = new(title: "Период:");
    public CaptionCardControl TitleCardPeriod
    {
        get => _TitleCardPeriod;
        set
        {
            Set(ref _TitleCardPeriod, value);
        }
    }
    private CaptionCardControl _TitleCardCC = new(title: "Центры затрат:");
    public CaptionCardControl TitleCardCC
    {
        get => _TitleCardCC;
        set
        {
            Set(ref _TitleCardCC, value);
        }
    }
    //private CaptionCardControl _TitleCardER = new(title: "Энергоресурсы:");
    //public CaptionCardControl TitleCardER
    //{
    //    get => _TitleCardER;
    //    set
    //    {
    //        Set(ref _TitleCardER, value);
    //    }
    //}

    private void TitleCardsRefresh(FilterSet filter)
    {
        if (filter.StartPeriod != filter.EndPeriod)
            TitleCardPeriod.Model.NameContent = filter.StartDate.ToString("Y") + " - " + filter.EndDate.ToString("Y");
        else
            TitleCardPeriod.Model.NameContent = filter.StartDate.ToString("Y");
        TitleCardCC.Model.NameContent = filter.TitleSelectedCCGroup;
        //TitleCardER.Model.NameContent = filter.TitleSelectedERGroup;

    }
    private List<FilterTable> GetFilters(FilterSet filter)
    {
        TitleCardsRefresh(filter);
        List<FilterTable> result = new();
        result.Add(new FilterTable { Category = "Analysis", Item = "Use", Indicator = "PeriodMin", Value = filterSet.StartPeriod });
        result.Add(new FilterTable { Category = "Analysis", Item = "Use", Indicator = "PeriodMax", Value = filterSet.EndPeriod });
        result.Add(new FilterTable { Category = "Analysis", Item = "Use", Indicator = "PeriodDynamicMin", Value = filterSet.StartDynamicPeriod });
        result.Add(new FilterTable { Category = "Analysis", Item = "Use", Indicator = "PeriodDynamicMax", Value = filterSet.EndDynamicPeriod });
        foreach (var r in filterSet.SelectedCC)
        {
            result.Add(new FilterTable { Category = "Analysis", Item = "Use", Indicator = "CC", Value = r.Id });
        }
        //foreach (var r in filterSet.SelectedER)
        //{
        //    result.Add(new FilterTable { Category = "Analysis", Item = "Use", Indicator = "ER", Value = r.Id });
        //}

        return result;
    }
    protected override void Refresh(FilterSet filterSet)
    {
        this.filterSet = filterSet;
        FilterTable filterTable = new();
        filterTable.Delete("Analysis", "Use");
        filterTable.AddRange(GetFilters(filterSet));
        _TabCCViewModel.DataTableCC = new ObservableCollection<DataUse>(DataUse.GetCC());
        _TabCCViewModel.IsGroupEnabled = filterSet.SelectedCC.Count == 1 ? true : false;
    }

    private TabCCViewModel _TabCCViewModel { get; set; } = new();
    public TabCC _TabCC { get; set; }

    public AnalysisForCCViewModel(bool periodVisible, bool ccVisible, bool erVisible, bool ntVisible) : base(periodVisible, ccVisible, erVisible, ntVisible)
    {
        _TabCC = new(_TabCCViewModel);
    }

}
