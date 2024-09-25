using ICSharpCode.TextEditor.Document;
using System;
using System.Windows.Forms;

namespace SyntaxHighlighterSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Attach the provider to the text editor.
            HighlightingManager.Manager.AddSyntaxModeFileProvider(new AppSyntaxModeProvider());

            textEditorControl1.SetHighlighting("SQL");
            textEditorControl1.Text = "SELECT * FROM Customers";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Set the cursor at the end of line.
            SendKeys.Send("{End}");
        }
    }
}
