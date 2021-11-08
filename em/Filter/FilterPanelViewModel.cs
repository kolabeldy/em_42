﻿namespace em.Filter;
public delegate void IsFilterChanged(FilterSet filterSet);
public delegate void IsFilterPanelClosed();
public struct FilterSet
{
    public int StartPeriod { get; set; }
    public DateTime StartDate { get; set; }
    public int EndPeriod { get; set; }
    public DateTime EndDate { get; set; }
    public int StartDynamicPeriod { get; set; }
    public int EndDynamicPeriod { get; set; }
    public List<CostCenter> SelectedCC { get; set; }
    public List<EnergyResource> SelectedER { get; set; }
    public int SelectedNormTypes { get; set; }
    public string TitleSelectedCCGroup { get; set; }
    public string TitleSelectedERGroup { get; set; }
    public string TitleSelectedIsNormGroup { get; set; }
}

public class FilterPanelViewModel
{
    public event IsFilterPanelClosed OnFilterPanelClosed;
    public event IsFilterChanged OnFilterChanged;
    public FilterPeriod FilterPeriodPanelContent { get; set; }
    public FilterPeriodViewModel FilterPeriodViewModel { get; set; }
    public FilterCostCenters FilterCostCentersPanelContent { get; set; }
    public FilterCostCentersViewModel FilterCostCentersViewModel { get; set; }
    public FilterEnergyResources FilterEnergyResourcesPanelContent { get; set; }
    public FilterEnergyResourcesViewModel FilterEnergyResourcesViewModel { get; set; }
    public FilterNormTypes FilterNormTypesPanelContent { get; set; }
    public FilterNormTypesViewModel FilterNormTypesViewModel { get; set; }

    private string _NewFilterData;

    private bool _IsChanged;
    public bool IsChanged
    {
        get => _IsChanged;
        set
        {
            Set(ref _IsChanged, value);
        }
    }
    private bool isPeriodVisible;
    private bool isCCVisible;
    private bool isERVisible;
    private bool isNTVisible;
    public string NewFilterData { get => _NewFilterData; set => Set(ref _NewFilterData, value); }

    private FilterSet filterSet;
    private void Refresh()
    {
        //filterSet = new();
        if (isPeriodVisible)
        {
            Period period = FilterPeriodViewModel.PeriodData;
            period.SetDynamicPeriods();
            FilterPeriodViewModel.IsChanged = false;
            filterSet.StartPeriod = period.SelectedStartPeriod;
            filterSet.EndPeriod = period.SelectedEndPeriod;
            filterSet.StartDate = period.SelectedStartDate;
            filterSet.EndDate = period.SelectedEndDate;
            filterSet.StartDynamicPeriod = period.MinDynamicSelectedPeriod;
            filterSet.EndDynamicPeriod = period.MaxDynamicSelectedPeriod;
        }
        if (isCCVisible)
        {
            List<CostCenter> SelectedCC = FilterCostCentersViewModel.SelectedCCList;
            filterSet.TitleSelectedCCGroup = (FilterCostCentersViewModel.MainComboBoxSelectedIndex,
                FilterCostCentersViewModel.OtherComboBoxSelectedIndex,
                FilterCostCentersViewModel.SlaveComboBoxSelectedIndex) 
                switch
                {
                    (0, 0, 0) => "все",
                    ( > 0, -1, -1) => SelectedCC[0].Name,
                    (-1, > 0, -1) => SelectedCC[0].Name,
                    (-1, -1, > 0) => SelectedCC[0].Name,
                    (0, -1, -1) => "технологические основные",
                    (-1, 0, -1) => "технологические прочие",
                    (0, 0, -1) => "все технологические",
                    (-1, -1, 0) => "вспомогательные",
                    (_, _, _) => "выборочно"
                };
            FilterCostCentersViewModel.IsChanged = false;
            filterSet.SelectedCC = SelectedCC;
        }
        if (isERVisible)
        {
            List<EnergyResource> SelectedER = FilterEnergyResourcesViewModel.SelectedERList;
            filterSet.TitleSelectedERGroup = (FilterEnergyResourcesViewModel.PrimeComboBoxSelectedIndex,
                FilterEnergyResourcesViewModel.SecondaryComboBoxSelectedIndex)
                switch
                {
                    (0, 0) => "все",
                    ( > 0, -1) => SelectedER[0].Name,
                    (-1, > 0) => SelectedER[0].Name,
                    (0, -1) => "первичные",
                    (-1, 0) => "вторичные",
                    (_, _) => "выборочно"
                };
            FilterEnergyResourcesViewModel.IsChanged = false;
            filterSet.SelectedER = SelectedER;
        }
        if (isNTVisible)
        {
            int SelectedNormTypes = FilterNormTypesViewModel.MainComboBoxSelectedIndex;
            filterSet.TitleSelectedIsNormGroup = SelectedNormTypes == 0 ? "все" : SelectedNormTypes == 1 ? "нормируемые" : "лимитируемые";
            FilterNormTypesViewModel.IsChanged = false;
            filterSet.SelectedNormTypes = SelectedNormTypes;
        }

        if (OnFilterChanged != null) OnFilterChanged(filterSet);
    }
    public FilterPanelViewModel(ref FilterSet filter, bool periodVisible = true, bool ccVisible = true, bool erVisible = true, bool ntVisible = true)
    {
        filterSet = filter;
        isPeriodVisible = periodVisible;
        isCCVisible = ccVisible;
        isERVisible = erVisible;
        isNTVisible = ntVisible;

        if (isPeriodVisible)
        {
            FilterPeriodViewModel = new FilterPeriodViewModel();
            FilterPeriodPanelContent = new FilterPeriod(FilterPeriodViewModel);
        }
        if (isCCVisible)
        {
            FilterCostCentersViewModel = new();
            FilterCostCentersPanelContent = new FilterCostCenters(FilterCostCentersViewModel);
        }
        if (isERVisible)
        {
            FilterEnergyResourcesViewModel = new();
            FilterEnergyResourcesPanelContent = new FilterEnergyResources(FilterEnergyResourcesViewModel);
        }
        if (isNTVisible)
        {
            FilterNormTypesViewModel = new();
            FilterNormTypesPanelContent = new FilterNormTypes(FilterNormTypesViewModel);
        }
        Refresh();
        filter = filterSet;
    }

    private RelayCommand _FilterPanelClose_Command;
    public RelayCommand FilterPanelClose_Command
    {
        get
        {
            return _FilterPanelClose_Command ??
                (_FilterPanelClose_Command = new RelayCommand(obj =>
                {
                    Close();
                }));
        }
    }
    private void Close()
    {
        if (FilterPeriodViewModel != null && FilterPeriodViewModel.SelectedStartDate > FilterPeriodViewModel.SelectedEndDate)
        {
            bool? Result = new MessageBoxCustom("Начальная дата не может быть больше конечной!", MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            return;
        }
        bool isPeriodChange = FilterPeriodViewModel != null ? FilterPeriodViewModel.IsChanged : false;
        bool isCostCentersChanged = FilterCostCentersViewModel != null ? FilterCostCentersViewModel.IsChanged : false;
        bool isEnergyResourcesChanged = FilterEnergyResourcesViewModel != null ? FilterEnergyResourcesViewModel.IsChanged : false;
        bool isNormTypesChanged = FilterNormTypesViewModel != null ? FilterNormTypesViewModel.IsChanged : false;

        bool isChanged = (isPeriodChange | isCostCentersChanged | isEnergyResourcesChanged | isNormTypesChanged);

        if (isChanged) Refresh();
        OnFilterPanelClosed();
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
