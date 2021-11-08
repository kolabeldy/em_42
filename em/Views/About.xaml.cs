namespace em.Views;

/// <summary>
/// Логика взаимодействия для About.xaml
/// </summary>
public partial class About : Window
{
    public About()
    {
        InitializeComponent();
    }

    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
