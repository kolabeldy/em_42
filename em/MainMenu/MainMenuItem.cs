namespace em.MainMenu;
public class MainMenuItem
{
    public MainMenuItem(string header, List<MainMenuSubItem> subItems, PackIconKind icon)
    {
        Header = header;
        SubItems = subItems;
        Icon = icon;
    }

    public string Header { get; private set; }
    public PackIconKind Icon { get; private set; }
    public List<MainMenuSubItem> SubItems { get; private set; }
}
