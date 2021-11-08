namespace em.MainMenu;
public partial class MainMenuControl : UserControl
{

    public MainMenuControl(MainMenuControlViewModel model)
    {
        InitializeComponent();
        DataContext = model;
    }
}
