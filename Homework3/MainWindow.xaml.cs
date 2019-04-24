using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GridViewColumnHeader lastHeaderClicked = null;
        ListSortDirection sortDirection;

        public MainWindow()
        {
            InitializeComponent();
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
        }

        private void UxList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //do nothing;
        }

        private void uxList_OnClickGridViewColumnHeader(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;

            var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
            var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

            Sort(sortBy);

            //Commented code reverses sort direction if same header is clicked twice.
            //This conflicts with the literal instructions of the assignment, so stripping out.

            //if (headerClicked != lastHeaderClicked
            //    || sortDirection == ListSortDirection.Descending
            //    )
            //{
            //    sortDirection = ListSortDirection.Ascending;
            //}
            //else { sortDirection = ListSortDirection.Descending; }

            //var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
            //var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

            //Sort(sortBy, sortDirection);

            //lastHeaderClicked = headerClicked;
        }

        private void Sort(string sortBy)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(uxList.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, ListSortDirection.Ascending);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        //private void Sort(string sortBy, ListSortDirection direction)
        //{
        //    ICollectionView dataView =
        //      CollectionViewSource.GetDefaultView(uxList.ItemsSource);

        //    dataView.SortDescriptions.Clear();
        //    SortDescription sd = new SortDescription(sortBy, direction);
        //    dataView.SortDescriptions.Add(sd);
        //    dataView.Refresh();
        //}
    }
}
