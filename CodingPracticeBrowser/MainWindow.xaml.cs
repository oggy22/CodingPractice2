using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using Microsoft.CodeAnalysis;

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

        private CodingPractice.ProblemBase pb;

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                pb = e.AddedItems[0] as CodingPractice.ProblemBase;
                lblTitle.Content = pb.Title;
                txtDescription.Text = pb.Description;
                var rgArgs = pb.GetType().BaseType.GenericTypeArguments;
                txtProgram.Text =
                    "public " + GetString(rgArgs[1]) + " solve(" + GetString(rgArgs[0]) + " input)" + nw
                    + "{" + nw
                    + "    //TODO: Your code here" + nw
                    + "    return " + GetValue(rgArgs[1]) + ";" + nw
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

        static private string GetValue(Type type)
        {
            if (type == typeof(int)) return "0";
            if (type == typeof(bool)) return "false";
            if (type == typeof(string)) return "string.Empty";
            return "new " + GetString(type) + "()";
        }

        private string nw { get { return Environment.NewLine; } }

        private void bttnCompile_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "";

            Type programClass;
            try
            {
                programClass = RoslynUtilities.CompileSolutionAndGetType(txtProgram.Text);
            }
            catch (DiagnosticException exc)
            {
                txtOutput.Text = string.Empty + exc.diagnostic;
                return;
            }

            object obj = Activator.CreateInstance(programClass);
            object res = programClass.InvokeMember("solve",
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                obj,
                new object[] { 0 });

            txtOutput.Text = "" + res;
        }
    }
}