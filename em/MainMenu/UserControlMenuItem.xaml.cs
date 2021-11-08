namespace em.MainMenu;
public partial class UserControlMenuItem : UserControl
{
    MainMenuControlViewModel MenuContext;
    public UserControlMenuItem(MainMenuItem itemMenu, MainMenuControlViewModel context)
    {
        InitializeComponent();

        MenuContext = context;

        ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
        ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

        this.DataContext = itemMenu;
    }

    private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListViewMenu.SelectedIndex >= 0)
        {
            string MethodName = ((MainMenuSubItem)((ListView)sender).SelectedItem).IdFunc;
            if (MethodName != null)
            {
                MethodInfo method = typeof(MainMenuControlViewModel).GetMethod(MethodName);
                if (method != null) method.Invoke(MenuContext, null);
            }
            ListViewMenu.SelectedIndex = -1;
        }
    }
}
