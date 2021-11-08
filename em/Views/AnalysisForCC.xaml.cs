namespace em.Views;

public partial class AnalysisForCC : UserControl
{
    private AnalysisForCCViewModel model;

    private static AnalysisForCC instance;
    public static AnalysisForCC GetInstance()
    {
        if (instance == null)
        {
            instance = new AnalysisForCC();
        }
        return instance;
    }
    private AnalysisForCC()
    {
        model = new(periodVisible: true, ccVisible: true, erVisible: false, ntVisible: true);
        DataContext = model;
        InitializeComponent();
    }

}
