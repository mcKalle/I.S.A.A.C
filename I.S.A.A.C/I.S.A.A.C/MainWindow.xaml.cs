using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

using ISAAC.Brain.Speaking;

namespace ISAAC
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private IntelligentSpeakingAndAssistingComputer _isaac;

        public MainWindow()
        {
            InitializeComponent();

            _isaac = new IntelligentSpeakingAndAssistingComputer();
            _isaac.Name = "Eisäck";
            _isaac.Interaction = IntelligentSpeakingAndAssistingComputer.InteractionMode.WriteSpeak;

            Question q = new Question();
            q.QuestionText = "Wie geht es dir heute?";
            q.Answers = new List<string>() { "Mir geht es hervorragend.", "Ich fühle mich heute sehr gut.", 
                "Danke, sehr gut", "Wunderbar!" };

            XmlSerializer xml = new XmlSerializer(typeof(Question));
            xml.Serialize(new StreamWriter(@"C:\Temp\Question1.xml"), q);
        }

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            _isaac.Introduce();
        }

		  private void BtnTalkToIsaacClick(object sender, RoutedEventArgs e)
		  {
			 txtTalkToIsaac.Text = _isaac.InterpreteUserInput(txtTalkToIsaac.Text);
		  }
    }
}