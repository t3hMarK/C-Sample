using System.IO;
using System.Reflection;
using System.Windows;
using Interop = Microsoft.Office.Interop.Word;

namespace C.Sharp.Com.Wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void create_button_Click(object sender, RoutedEventArgs e)
        {
            object missing = Missing.Value;
            object file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "doc.docx");
            string text = input_textblock.Text;
            
            //Start word
            Interop.Application word = new Interop.Application();
            word.Visible = true;

            //Save doc
            Interop.Document doc = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            doc.Content.Text = text;
            doc.SaveAs2(ref file);
            doc.Close();

            //Close word
            word.Quit();
        }
    }
}
