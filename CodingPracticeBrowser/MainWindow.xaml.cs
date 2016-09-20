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
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                CodingPractice.ProblemBase pb = e.AddedItems[0] as CodingPractice.ProblemBase;
                string st = pb.Title + Environment.NewLine + pb.Description + Environment.NewLine;
                textBox.Text = st;
            }
        }
    }
}