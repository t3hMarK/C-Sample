using C.Sharp.Reflection.Search;
using C.Sharp.Reflection.Search.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace C.Sharp.Reflection.Ui
{
    public partial class MainWindow : Window
    {
        #region Properties

        public string AssemblyPath { get; set; } = @"plugins/";
        
        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            FindSearchProvider();
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

        private void FindSearchProvider()
        {
            //Get paths
            string appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string pluginDirectoryPath = Path.Combine(appPath, AssemblyPath);

            //Find .dll in plugins directory
            IEnumerable<string> searchProviderList = Directory.GetFiles(pluginDirectoryPath, "*.dll").Select(p => Path.GetFileName(p));
            
            //Populate combobox
            search_query_provider_combobox.ItemsSource = searchProviderList.Select(spl => new ListBoxItem() { Content = Assembly.LoadFrom(Path.Combine(AssemblyPath, spl)).GetCustomAttribute<SearchProviderNameAttribute>().Name, Tag = spl });
            search_query_provider_combobox.SelectedIndex = 0;
        }

        private ISearch GetSearchImplementor() => GetSearchImplementor(Assembly.LoadFrom(Path.Combine(AssemblyPath, search_query_provider_combobox.SelectedValue.ToString())));

        private ISearch GetSearchImplementor(Assembly assembly)
        {
            ISearch instance = null;

            //Find instance implementing from ISearch
            foreach(Type type in assembly.GetTypes().Where(t => typeof(ISearch).IsAssignableFrom(t)))
            {
                instance = Activator.CreateInstance(type) as ISearch;
                break;
            }

            return instance;
        }

        #endregion
    }
}
