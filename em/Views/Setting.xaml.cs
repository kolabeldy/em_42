namespace em.Views;

/// <summary>
/// Логика взаимодействия для Setting.xaml
/// </summary>
public partial class Setting : Window
{
    private readonly PaletteHelper _paletteHelper = new PaletteHelper();

    public Setting()
    {
        InitializeComponent();
    }
    public void SetLightDark(bool isDark)
    {
        ITheme theme = _paletteHelper.GetTheme();
        IBaseTheme baseTheme = isDark ? new MaterialDesignDarkTheme() : (IBaseTheme)new MaterialDesignLightTheme();
        theme.SetBaseTheme(baseTheme);
        _paletteHelper.SetTheme(theme);
    }

    private void ThemeToggle_Click(object sender, RoutedEventArgs e)
    {
        SetLightDark((bool)ThemeToggle.IsChecked);
    }

}
