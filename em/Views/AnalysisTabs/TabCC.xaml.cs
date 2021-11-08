namespace em.Views.AnalysisTabs;
public partial class TabCC : UserControl
{
    public TabCC(TabCCViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
    private void UngroupButton_Click(object sender, RoutedEventArgs e)
    {
        ICollectionView cvTasks = CollectionViewSource.GetDefaultView(dataGridCC.ItemsSource);
        if (cvTasks != null)
        {
            cvTasks.GroupDescriptions.Clear();
        }
    }

    private void GroupButton_Click(object sender, RoutedEventArgs e)
    {
        ICollectionView cvData = CollectionViewSource.GetDefaultView(dataGridCC.ItemsSource);
        if (cvData != null && cvData.CanGroup == true)
        {
            cvData.GroupDescriptions.Clear();
            cvData.GroupDescriptions.Add(new PropertyGroupDescription("IsNorm"));
            cvData.GroupDescriptions.Add(new PropertyGroupDescription("ProductName"));
        }
    }
    private void GroupButton1_Click(object sender, RoutedEventArgs e)
    {
        ICollectionView cvData = CollectionViewSource.GetDefaultView(dataGridCC.ItemsSource);
        if (cvData != null && cvData.CanGroup == true)
        {
            cvData.GroupDescriptions.Clear();
            cvData.GroupDescriptions.Add(new PropertyGroupDescription("IsNorm"));
            cvData.GroupDescriptions.Add(new PropertyGroupDescription("ERName"));
        }
    }


}
