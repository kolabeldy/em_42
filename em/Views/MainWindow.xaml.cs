namespace em.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainMenuControlViewModel menumodel = new();
        StackPanelMenu.Content = new MainMenuControl(menumodel);

    }
}
