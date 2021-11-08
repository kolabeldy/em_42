using em.Filter;
using MyServicesLibrary.Helpers;
using MyServicesLibrary.ViewModelsBase;

namespace em.ViewModels.Base
{
    public class AnalysisViewModelBase: BaseViewModel
    {
        public FilterPanel FilterPanel { get; set; }

        protected FilterPanelViewModel filterPanelViewModel;

        protected bool _IsFilterPopupOpen = false;
        public bool IsFilterPopupOpen
        {
            get => _IsFilterPopupOpen;
            set
            {
                if (isClosePress)
                    Set(ref _IsFilterPopupOpen, value);
                else Set(ref _IsFilterPopupOpen, true);
            }
        }

        protected bool isClosePress = false;
        protected void FilterClose()
        {
            isClosePress = true;
            IsFilterPopupOpen = false;
            isClosePress = false;
        }
        protected int countRefresh = 0;
        protected virtual void Refresh(FilterSet filterSet)
        {
            countRefresh++;
            FilterText = "Фильтр обновлён " + countRefresh + " раз.";
        }
        protected string _FilterText;
        public string FilterText
        {
            get => _FilterText;
            set
            {
                Set(ref _FilterText, value);
            }
        }
        protected FilterSet filterSet;

        public AnalysisViewModelBase(bool periodVisible = true, bool ccVisible = true, bool erVisible = false, bool ntVisible = true)
        {
            filterSet = new();
            filterPanelViewModel = new FilterPanelViewModel(ref filterSet, periodVisible, ccVisible, erVisible, ntVisible);
            filterPanelViewModel.OnFilterPanelClosed += FilterClose;
            filterPanelViewModel.OnFilterChanged += Refresh;
            FilterPanel = new FilterPanel(filterPanelViewModel);
            Refresh(filterSet);
        }

    }
}
