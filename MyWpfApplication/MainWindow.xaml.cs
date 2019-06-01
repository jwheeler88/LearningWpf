using System.Collections.ObjectModel;
using System.Linq;
using LinqToExcel;
using Projects2;

namespace MyWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ObservableCollection<Project> _projects;
        public MainWindow()
        {
            InitializeComponent();
            
            var path = @"C:\tmp\test.xlsx";
            var factory = new ExcelQueryFactory(path);
            MapColumns(factory);

            _projects = new ObservableCollection<Project>(
                from p in factory.Worksheet<Project>("Projects")
                where p.LeadEngineer.Equals("James")
                select p);
            
            ProjectsDataGrid.DataContext = _projects;
        }
        
        private void MapColumns(IExcelQueryFactory factory)
        {
            factory.AddMapping<Project>(p => p.Customer, "Customer");
            factory.AddMapping<Project>(p => p.Priority, "Priority");
            factory.AddMapping<Project>(p => p.Description, "Project");
            factory.AddMapping<Project>(p => p.LeadEngineer, "Lead Engineer");
            factory.AddMapping<Project>(p => p.SupportingEngineer, "Supporting Engineer");
            factory.AddMapping<Project>(p => p.LeadSales, "Lead\r\nSales");
            factory.AddMapping<Project>(p => p.SalesChannel, "Channel");
            factory.AddMapping<Project>(p => p.ProcessStage, "Process Stage");
            factory.AddMapping<Project>(p => p.Comment, "Comment / Next Action");
            factory.AddMapping<Project>(p => p.CriticalIssues, "Critical Issues");
            factory.AddMapping<Project>(p => p.SupportLevel, "Support Level (hr/week)");
        }
    }
}