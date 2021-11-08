namespace em.MainMenu;
public class MainMenuControlViewModel
{
    private MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    public StackPanel MyMainMenu { get; set; }
    public MainMenuControlViewModel()
    {
        MyMainMenu = new StackPanel();
        var menuMonitoring = new List<MainMenuSubItem>();
        menuMonitoring.Add(new MainMenuSubItem("Инфопанель", idFunc: "DashboardShow"));
        menuMonitoring.Add(new MainMenuSubItem("Суточные данные", idFunc: "MonitorDayShow"));
        menuMonitoring.Add(new MainMenuSubItem("Потери энергоресурсов", idFunc: "MonitorLossesShow"));
        var item1 = new MainMenuItem("Мониторинг", menuMonitoring, PackIconKind.MonitorDashboard);

        var menuAnalysis = new List<MainMenuSubItem>();
        menuAnalysis.Add(new MainMenuSubItem("По центрам затрат", idFunc: "AnalysisForCCShow"));
        menuAnalysis.Add(new MainMenuSubItem("По энергоресурсам", idFunc: "AnalysisForERShow"));
        var item2 = new MainMenuItem("Анализ", menuAnalysis, PackIconKind.MonitorDashboard);

        var menuImportToDB = new List<MainMenuSubItem>();
        menuImportToDB.Add(new MainMenuSubItem("Месячные отчёты", idFunc: "AddNewMonth"));
        menuImportToDB.Add(new MainMenuSubItem("Суточные данные", idFunc: "AddNewDay"));
        menuImportToDB.Add(new MainMenuSubItem("Фактические потери", idFunc: "AddNewLosses"));
        menuImportToDB.Add(new MainMenuSubItem("Расходные нормы", idFunc: "AddNewNormatives"));
        var item3 = new MainMenuItem("Импорт данных", menuImportToDB, PackIconKind.Import);

        var menuReports = new List<MainMenuSubItem>();
        menuReports.Add(new MainMenuSubItem("Месячный отчёт", idFunc: "ReportMonthShow"));
        menuReports.Add(new MainMenuSubItem("Пофакторный анализ", idFunc: "ReportFactorAnalysisShow"));
        var item4 = new MainMenuItem("Отчёты", menuReports, PackIconKind.FileReport);

        var menuAdmin = new List<MainMenuSubItem>();
        menuAdmin.Add(new MainMenuSubItem("Синхронизация", idFunc: "SynchronizeDB"));
        menuAdmin.Add(new MainMenuSubItem("Резервирование", idFunc: "SaveDB"));
        menuAdmin.Add(new MainMenuSubItem("Восстановление", idFunc: "RestoreDB"));
        menuAdmin.Add(new MainMenuSubItem("Удалить последние", idFunc: "DeleteLastMonthUse"));
        var item5 = new MainMenuItem("Сервис БД", menuAdmin, PackIconKind.DatabaseSettings);

        var menuReferences = new List<MainMenuSubItem>();
        menuReferences.Add(new MainMenuSubItem("Энергоресурсы", idFunc: "ERShow"));
        menuReferences.Add(new MainMenuSubItem("Центры затрат", idFunc: "CCShow"));
        menuReferences.Add(new MainMenuSubItem("Тарифы", idFunc: "TariffsShow"));
        menuReferences.Add(new MainMenuSubItem("Нормативные потери", idFunc: "NormLossShow"));
        var item6 = new MainMenuItem("Справочники", menuReferences, PackIconKind.Book);

        var menuSettings = new List<MainMenuSubItem>();
        menuSettings.Add(new MainMenuSubItem("Авторизация"));
        menuSettings.Add(new MainMenuSubItem("Настройки", idFunc: "SettingsShow"));
        menuSettings.Add(new MainMenuSubItem("О программе", idFunc: "AboutShow"));

        var item7 = new MainMenuItem("Настройки", menuSettings, PackIconKind.Settings);


        MyMainMenu.Children.Add(new UserControlMenuItem(item1, this));
        MyMainMenu.Children.Add(new UserControlMenuItem(item2, this));
        MyMainMenu.Children.Add(new UserControlMenuItem(item3, this));
        MyMainMenu.Children.Add(new UserControlMenuItem(item4, this));
        MyMainMenu.Children.Add(new UserControlMenuItem(item5, this));
        MyMainMenu.Children.Add(new UserControlMenuItem(item6, this));
        MyMainMenu.Children.Add(new UserControlMenuItem(item7, this));
    }

    public void AnalysisForCCShow() => mw.MainFrame.Content = AnalysisForCC.GetInstance();
    public void AboutShow() => new About().ShowDialog();
    public void SettingsShow() => new Setting().ShowDialog();

}
