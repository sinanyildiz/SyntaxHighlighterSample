using ICSharpCode.TextEditor.Document;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace SyntaxHighlighterSample
{
    public class AppSyntaxModeProvider : ISyntaxModeFileProvider
    {
        private ICollection<SyntaxMode> _syntaxModes;
        public ICollection<SyntaxMode> SyntaxModes { get { return _syntaxModes; } }

        public AppSyntaxModeProvider()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Load the mode list.
            Stream syntaxModeStream = assembly.GetManifestResourceStream("SyntaxHighlighterSample.Resources.SyntaxModes.xml");

            if (syntaxModeStream != null)
                _syntaxModes = SyntaxMode.GetSyntaxModes(syntaxModeStream);
            else
                _syntaxModes = new List<SyntaxMode>();
        }

        public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Load the syntax schema.
            Stream stream = assembly.GetManifestResourceStream("SyntaxHighlighterSample.Resources." + syntaxMode.FileName);

            return new XmlTextReader(stream);
        }

        public void UpdateSyntaxModeList() { }
    }
}