namespace em.MainMenu;
public class MainMenuSubItem
{
    public MainMenuSubItem(string name, string idFunc = null)
    {
        Name = name;
        IdFunc = idFunc;
    }
    public string Name { get; private set; }
    public string IdFunc { get; set; }
}
