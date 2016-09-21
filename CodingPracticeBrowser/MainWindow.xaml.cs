using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CodingPracticeBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            typeof(CodingPractice.ProblemBase)
            .Assembly.GetTypes()
            .Where(t => t.BaseType.BaseType == typeof(CodingPractice.ProblemBase))
            .Select(t => (CodingPractice.ProblemBase)(Activator.CreateInstance(t)))
            .ToList<CodingPractice.ProblemBase>()
            .ForEach(pb => listBox.Items.Add(pb));

            listBox.SelectedIndex = 0;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                CodingPractice.ProblemBase pb = e.AddedItems[0] as CodingPractice.ProblemBase;
                lblTitle.Content = pb.Title;
                txtDescription.Text = pb.Description;
                var rgArgs = pb.GetType().BaseType.GenericTypeArguments;
                textBox1.Text =
                    "" + GetString(rgArgs[1]) + " solve(" + GetString(rgArgs[0]) + ")" + nw
                    + "{" + nw
                    + "    //TODO: Your code here" + nw
                    + "}";
            }
        }

        static private string GetString(Type type)
        {
            string st = type.ToString();
            st = st.Replace("System.Boolean", "bool");
            st = st.Replace("System.Int32", "int");
            st = st.Replace("System.String", "string");
            st = st.Replace("CodingPractice.Problems.", "");
            return st;
        }

        private string nw { get { return Environment.NewLine; } }
    }
}