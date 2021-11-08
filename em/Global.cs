global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.Globalization;
global using System.Windows;
global using System.Windows.Markup;
global using System.ComponentModel;
global using System.Runtime.CompilerServices;
global using System.Windows.Controls;
global using System.Linq;
global using System.Collections.ObjectModel;
global using System.Windows.Controls.Primitives;
global using System.Reflection;
global using System.Data;
global using System.Windows.Data;
global using Calendar = System.Windows.Controls.Calendar;

global using MaterialDesignThemes.Wpf;

global using em.Models;
global using em.Views;
global using em.Filter.Partials;
global using em.Models.Base;
global using em.Filter;
global using em.ViewModels;
global using em.ViewModels.AnalysisTabs;
global using em.ViewModels.Base;
global using em.MainMenu;
global using em.Views.AnalysisTabs;

global using MyServicesLibrary.ViewModelsBase;
global using MyServicesLibrary.Helpers;
global using MyUserControlsLibrary.CaptionCard;
global using MyServicesLibrary.Infrastructure.MessageBoxes;
global using MyDataAccessLibrary;


namespace em;
public enum SelectChoise { All, True, False }
public static class Global
{
    public static string dbpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db\\emdb.db");
    public static List<CostCenter> CostCenterSourceList= new List<CostCenter>();
    public static List<Unit> UnitSourceList = new List<Unit>();
    public static int DynamicPeriodMonthCount = 12;

}
