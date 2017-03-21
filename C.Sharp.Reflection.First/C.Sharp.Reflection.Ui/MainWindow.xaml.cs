using C.Sharp.Reflection.Search;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace C.Sharp.Reflection.Ui
{
    public partial class MainWindow : Window
    {
        #region Properties

        public string AssemblyPath { get; set; } = @"plugins/";

        public string AssemblyName { get; set; } = "C.Sharp.Reflection.Search.Google.dll";

        public string SearchImplementorName { get; set; } = "C.Sharp.Reflection.Search.Google.GoogleSearch";

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void search_query_button_Click(object sender, RoutedEventArgs e)
        {
            string searchResult = string.Empty;

            try
            {
                searchResult = GetSearchImplementor()?.Search(search_query_textbox.Text);
            }
            catch (Exception)
            {
                searchResult = "something went wrong";
            }
            finally
            {
                search_result_label.Content = searchResult;
            }
        }
        
        #endregion

        #region Methods

        private ISearch GetSearchImplementor() => Activator.CreateInstance(Assembly.LoadFrom(Path.Combine(AssemblyPath, AssemblyName))?.GetType(SearchImplementorName)) as ISearch;

        #endregion
    }
}
