using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hubabuba444.SourceEditor
{
    public class SourceEditor : RichTextBox
    {
        public ProgrammingLanguage Highlighting { get; set; }

        public SourceEditor()
        {
            this.AcceptsTab = true;
            this.SelectionColor = Color.Black;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (Highlighting == ProgrammingLanguage.Batch)
            {
                BatchHighlighting();
            }
            if (Highlighting == ProgrammingLanguage.VisualBasic)
            {
                VBHighlighting();
            }
            if (Highlighting == ProgrammingLanguage.CSharp)
            {
                CSharpHighlighting();
            }
            if (Highlighting == ProgrammingLanguage.CppC)
            {
                HighlightCppC();
            }
            if (Highlighting == ProgrammingLanguage.JavaScript)
            {
                HighlightJavaScript();
            }
            if (Highlighting == ProgrammingLanguage.Assembler)
            {
                HighlightAssembler();
            }
            base.OnTextChanged(e);
        }
        void BatchHighlighting()
        {
            string keywords = @"\b(echo|set|choice|rem|start|call|mkdir|del|rmdir|exists|not)\b";
            MatchCollection keywordsM = Regex.Matches(this.Text, keywords);
            string violetKeywords = @"\b(if|goto|exit)\b";
            MatchCollection violetKeywordsM = Regex.Matches(this.Text, violetKeywords);
            int index = this.SelectionStart;
            int length = this.SelectionLength;
            Color color = this.SelectionColor;
            foreach (Match match in keywordsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Blue;

            }
            foreach (Match match in violetKeywordsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Violet;

            }
            this.SelectionStart = index;
            this.SelectionLength = length;
            this.SelectionColor = color;
        }
        void CSharpHighlighting()
        {
            string comments = @"//.*|/\*(.|\n)*?\*/";
            string methods = @"\b\s+(static\s+)?(\w+\s+)?(?!)(\w+)\s*\([^)]*\)\s*";
            string keywords = @"\b(bool|int|uint|float|double|using|namespace|class|long|ulong|string|private|void|public|protected|override|internal|enum|byte|event|static|return|case|switch|for|foreach|in|new|throw)\b";
            MatchCollection keywordsM = Regex.Matches(this.Text, keywords);
            MatchCollection methodM = Regex.Matches(this.Text, methods);
            string SystemTypes = @"\b(Console|Convert|String|Int16|Int32|Enum|Int64|Byte|EventHandler|Exception|ArgumentException|StackOverflowException|ArgumentNullException|AppDomainException|IndexOutOfRangeException|AppDomain)\b";
            MatchCollection SystemTypesM = Regex.Matches(this.Text, SystemTypes);
            string SystemTypes1 = @"\b(Timer|RichTextBox|Button|TextBox|Form|Label|BackgroundWorker|MouseEventHandler)\b";
            MatchCollection SystemTypes1M = Regex.Matches(this.Text, SystemTypes1);
            string SystemTypes2 = @"\b(Thread|ThreadStart|ThreadState|ThreadPool|AutoResetEvent|ManualRestartEvent|Mutex|Monitor)\b";
            MatchCollection SystemTypes2M = Regex.Matches(this.Text, SystemTypes2);
            string SystemTypes3 = @"\b(Process|EventLog|EventLogEntry|PerformanceCounter|ProcessStartInfo|EventLogEntryCollection|PerformanceCounterCategory)\b";
            MatchCollection SystemTypes3M = Regex.Matches(this.Text, SystemTypes3);
            MatchCollection commentMatches = Regex.Matches(this.Text, comments);
            string SystemTypes4 = @"\b(File|Directory|FileStream|Stream|StreamWriter|StreamReader|IOException|FileNotFoundException|PathTooLongException|DirectoryNotFoundException)\b";
            string SystemTypes5 = @"\b(WebClient|FtpWebRequest|WebRequest|FtpWebResponse|HttpWebRequest|WebRespone|HttpWebRespone|IPAddress|IPEndPoint|NetworkCrediental|Cookie)\b";
            string SystemTypes6 = @"\b(Socket|TcpClient|TcpListener|UdpClient|NetworkStream|SocketAsyncEventArgs|SocketException|ProtoculType|SocketOptionLevel|SocketOptionName|AddressFamily)\b";
            MatchCollection SystemTypes4M = Regex.Matches(this.Text, SystemTypes4);
            MatchCollection SystemTypes5M = Regex.Matches(this.Text, SystemTypes5);
            MatchCollection SystemTypes6M = Regex.Matches(this.Text, SystemTypes6);
            string strings = @"""([^""]|"""")*""";
            MatchCollection stringsM = Regex.Matches(this.Text, strings);
            int index = this.SelectionStart;
            int length = this.SelectionLength;
            Color color = this.SelectionColor;
            foreach (Match match in keywordsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Blue;

            }
            foreach (Match match in stringsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Red;

            }
            if (this.Text.Contains("using System.IO;"))
            {
                foreach (Match match in SystemTypes4M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }
            if (this.Text.Contains("using System.Net;"))
            {
                foreach (Match match in SystemTypes5M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }
            if (this.Text.Contains("using System.Net.Sockets;"))
            {
                foreach (Match match in SystemTypes6M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }
            foreach (Match match in methodM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.DarkOrange;

            }
            foreach (Match match in commentMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Green;

            }
            if (this.Text.Contains("using System;"))
            {
                foreach (Match match in SystemTypesM)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }

            else if (this.Text.Contains("using System.Windows.Forms;"))
            {
                foreach (Match match in SystemTypes1M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }
            else if (this.Text.Contains("using System.Threading;"))
            {
                foreach (Match match in SystemTypes2M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }
            else if (this.Text.Contains("using System.Diagnostics;"))
            {
                foreach (Match match in SystemTypes3M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }

            this.SelectionStart = index;
            this.SelectionLength = length;
            this.SelectionColor = color;

        }
        void VBHighlighting()
        {
            string keywords = @"\b(AddHandler|AddressOf|Alias|And|AndAlso|As|Async|Boolean|ByRef|Byte|ByVal|Call|Case|Catch|CBool|CByte|CChar|CDate|CDbl|CDec|Char|Class|Continue|CSByte|CShort|CSng|CStr|CType|CUInt|CULng|CUShort|Date|Decimal|Declare|Default|Delegate|Dim|DirectCast|Do|Double|Each|Else|ElseIf|End|EndIf|Enum|Erase|Error|Event|Exit|False|Finally|For|Friend|Function|Get|GetType|GoSub|GoTo|Handles|If|Implements|Imports|In|Inherits|Integer|Interface|Is|IsNot|Let|Lib|Like|Long|Loop|Me|Mod|Module|MustInherit|MustOverride|MyBase|MyClass|Namespace|Narrowing|New|Next|Not|Nothing|NotInheritable|NotOverridable|Object|Of|On|Operator|Option|Optional|Or|OrElse|Overloads|Overridable|Overrides|Sub)\b";
            MatchCollection keywordsM = Regex.Matches(this.Text, keywords);
            string SystemTypes = @"\b(Console|Convert|String|Int16|Int32|Enum|Int64|Byte)\b";
            MatchCollection SystemTypesM = Regex.Matches(this.Text, SystemTypes);
            string SystemTypes1 = @"\b(Timer|RichTextBox|Button|TextBox|Form|Label|BackgroundWorker)\b";
            MatchCollection SystemTypes1M = Regex.Matches(this.Text, SystemTypes1);
            string SystemTypes2 = @"\b(Thread|ThreadStart|ThreadState|ThreadPool|AutoResetEvent|ManualRestartEvent|Mutex|Monitor)\b";
            MatchCollection SystemTypes2M = Regex.Matches(this.Text, SystemTypes2);
            string SystemTypes3 = @"\b(Process|EventLog|EventLogEntry|PerformanceCounter|ProcessStartInfo|EventLogEntryCollection|PerformanceCounterCategory)\b";
            MatchCollection SystemTypes3M = Regex.Matches(this.Text, SystemTypes3);
            string strings = @"""([^""]|"""")*""";
            MatchCollection stringsM = Regex.Matches(this.Text, strings);
            string SystemTypes4 = @"\b(File|Directory|FileStream|Stream|StreamWriter|StreamReader|IOException|FileNotFoundException|PathTooLongException|DirectoryNotFoundException)\b";
            string SystemTypes5 = @"\b(WebClient|FtpWebRequest|WebRequest|FtpWebResponse|HttpWebRequest|WebRespone|HttpWebRespone|IPAddress|IPEndPoint|NetworkCrediental|Cookie)\b";
            string SystemTypes6 = @"\b(Socket|TcpClient|TcpListener|UdpClient|NetworkStream|SocketAsyncEventArgs|SocketException|ProtoculType|SocketOptionLevel|SocketOptionName|AddressFamily)\b";
            MatchCollection SystemTypes4M = Regex.Matches(this.Text, SystemTypes4);
            MatchCollection SystemTypes5M = Regex.Matches(this.Text, SystemTypes5);
            MatchCollection SystemTypes6M = Regex.Matches(this.Text, SystemTypes6);
            int index = this.SelectionStart;
            int length = this.SelectionLength;
            Color color = this.SelectionColor;
            foreach (Match match in keywordsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Blue;

            }
            foreach (Match match in stringsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.DarkRed;

            }
            if (this.Text.Contains("Imports System.IO"))
            {
                foreach (Match match in SystemTypes4M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }
            if (this.Text.Contains("Imports System.Net"))
            {
                foreach (Match match in SystemTypes5M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }
            if (this.Text.Contains("Imports System.Net.Sockets"))
            {
                foreach (Match match in SystemTypes6M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.DarkOliveGreen;

                }
            }
            if (this.Text.Contains("Imports System"))
            {

                foreach (Match match in SystemTypesM)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.Green;

                }
            }
            else if (this.Text.Contains("Imports System.Windows.Forms"))
            {
                foreach (Match match in SystemTypes1M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.Green;

                }
            }
            else if (this.Text.Contains("Imports System.Threading"))
            {
                foreach (Match match in SystemTypes2M)
                {

                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.Green;

                }
            }
            else if (this.Text.Contains("Imports System.Diagnostics"))
            {
                foreach (Match match in SystemTypes3M)
                {
                    this.Select(match.Index, match.Length);
                    this.SelectionColor = Color.Green;

                }
            }

            this.SelectionStart = index;
            this.SelectionLength = length;
            this.SelectionColor = color;
        }
        private void HighlightCppC()
        {
            string keywords = @"\b(auto|break|case|char|const|continue|default|do|double|else|enum|extern|float|for|goto|if|int|long|register|return|short|signed|sizeof|static|struct|switch|typedef|union|unsigned|void|volatile|while|asm|inline|restrict|_Bool|_Complex|_Imaginary)\b";
            string preprocessor = @"#.*";
            string comments = @"//.*|/\*(.|\n)*?\*/";
            string strings = @"""([^""]|"""")*""";
            MatchCollection stringsM = Regex.Matches(this.Text, strings);

            MatchCollection keywordMatches = Regex.Matches(this.Text, keywords);
            MatchCollection preprocessorMatches = Regex.Matches(this.Text, preprocessor);
            MatchCollection commentMatches = Regex.Matches(this.Text, comments);

            Color keywordColor = Color.Blue;
            Color preprocessorColor = Color.Violet;
            Color commentColor = Color.Green;

            int selectionStart = this.SelectionStart;
            int selectionLength = this.SelectionLength;
            Color originalColor = this.SelectionColor;
            foreach (Match match in stringsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Red;

            }
            foreach (Match match in keywordMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = keywordColor;

            }

            foreach (Match match in preprocessorMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = preprocessorColor;

            }

            foreach (Match match in commentMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = commentColor;

            }

            this.Select(selectionStart, selectionLength);
            this.SelectionColor = originalColor;
            this.Focus();
        }
        private void HighlightJavaScript()
        {
            string keywords = @"\b(var|let|const|if|else|for|while|do|break|continue|return|function)\b";
            string objects = @"\b(document|window|console)\b";
            string comments = @"//.*";
            string strings = @"""([^""]|"""")*""";
            MatchCollection stringsM = Regex.Matches(this.Text, strings);
            MatchCollection keywordMatches = Regex.Matches(this.Text, keywords);
            MatchCollection objectMatches = Regex.Matches(this.Text, objects);
            MatchCollection commentMatches = Regex.Matches(this.Text, comments);

            Color keywordColor = Color.Blue;
            Color objectColor = Color.DarkOrange;
            Color commentColor = Color.Green;

            int selectionStart = this.SelectionStart;
            int selectionLength = this.SelectionLength;
            Color originalColor = this.SelectionColor;
            foreach (Match match in stringsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Red;

            }
            foreach (Match match in keywordMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = keywordColor;

            }

            foreach (Match match in objectMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = objectColor;

            }

            foreach (Match match in commentMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = commentColor;

            }

            this.Select(selectionStart, selectionLength);
            this.SelectionColor = originalColor;
            this.Focus();
        }
        private void HighlightAssembler()
        {
            string keywords = @"\b(mov|add|sub|mul|div|jmp|cmp|inc|dec)\b";
            string registers = @"\b(ax|bx|cx|dx|si|di|sp|bp)\b";
            string comments = @";.*";
            string strings = @"""([^""]|"""")*""";
            MatchCollection stringsM = Regex.Matches(this.Text, strings);
            MatchCollection keywordMatches = Regex.Matches(this.Text, keywords);
            MatchCollection registerMatches = Regex.Matches(this.Text, registers);
            MatchCollection commentMatches = Regex.Matches(this.Text, comments);

            Color keywordColor = Color.Blue;
            Color registerColor = Color.DarkOrange;
            Color commentColor = Color.Green;

            int selectionStart = this.SelectionStart;
            int selectionLength = this.SelectionLength;
            Color originalColor = this.SelectionColor;

            foreach (Match match in stringsM)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = Color.Red;

            }
            foreach (Match match in keywordMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = keywordColor;

            }

            foreach (Match match in registerMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = registerColor;

            }

            foreach (Match match in commentMatches)
            {

                this.Select(match.Index, match.Length);
                this.SelectionColor = commentColor;

            }

            this.Select(selectionStart, selectionLength);
            this.SelectionColor = originalColor;
            this.Focus();
        }

    }
}
