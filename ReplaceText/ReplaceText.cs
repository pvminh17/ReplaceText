using Microsoft.VisualBasic.Devices;
using System.Text;
using System.Text.RegularExpressions;

namespace ReplaceText
{
    public partial class ReplaceText : Form
    {
        private const string COMMON_VN_REGEX = @"[ầấẫẩẦẤẪẨĂăÂâẬậĐđÊêƠơƯưÀÁÃẠẰắẴẶỀếỄệÈÉẺẼÌÍỈĨÒÓÕỌỒốỖỘỜỚỠỢÙÚŨỤỪỨỮỰỲÝỶỸàáãạằẵặềếễệèéẻẽìíỉĩòóõọỏồốỗộôờớỡợùúũụừứữựỳýỷỹ]";
        private const string PATTERN_HTML = @"[\p{L}\p{N}\s\!\?\.\,\(\)\/\\\-\[\]\{\}]*" + COMMON_VN_REGEX + @"+[\p{L}\p{N}\s\!\?\.\,\(\)\/\\\-\[\]\{\}]*";
        private const string PATTERN_JS = @"[\""\']+[\p{L}\p{N}\s\!\?\.\,\(\)\:\/\\\-\[\]\{\}]*" + COMMON_VN_REGEX + @"+[\p{L}\p{N}\s\!\?\.\,\(\)\:\/\\-\[\]\{\}]*[\""\']+";
        private const string PATTERN_CS = @"[\""\']+[\p{L}\p{N}\s\!\?\.\,\(\)\:\/\\\-\[\]\{\}]*" + COMMON_VN_REGEX + @"+[\p{L}\p{N}\s\!\?\.\,\(\)\:\/\\\-\[\]\{\}]*[\""\']+";
        public ReplaceText()
        {
            InitializeComponent();
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            comboBoxSourceType.Items.Add("CSHTML");
            comboBoxSourceType.Items.Add("JS");
            comboBoxSourceType.Items.Add("C#");
            comboBoxSourceType.SelectedIndex = 0;

        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxSourceType.Text)) return;

            String rs = String.Empty;
            switch (comboBoxSourceType.SelectedIndex)
            {
                case 0:
                    rs = ReplaceVietnameseInCsHtml();
                    break;
                case 1:
                    rs = ReplaceVietnameseInJS();
                    break;
                case 2:
                    rs = ReplaceVietnameseInCS();
                    break;
            }
            txtResultText.Text = rs;
        }

        private string ReplaceVietnameseInCS()
        {
            File.AppendText("D:\\Temp\\log_repalce.txt");
            try
            {
                List<String> rs = new List<String>();
                Dictionary<string, string> map = genarateMapBinding();
                string[] linesMap = txtSourceTxt.Text.Split(new[] { '\n', '\r' });
                foreach (string line in linesMap)
                {
                    string key = getContainKey(map, line);
                    if (!String.IsNullOrEmpty(key) 
                        //not contain string
                        && line.IndexOf("AddErrorLog") < 0
                        && line.IndexOf("SystemErrorWS") < 0
                        
                        )
                    {
                        rs.Add(line.Replace(key, map[key]) + " // " + key);
                        
                    }
                    else
                    {
                        rs.Add(line);
                    }
                }
                return String.Join("\n", rs.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return String.Empty;
            }
        }

        private string ReplaceVietnameseInJS()
        {
            try
            {
                List<String> rs = new List<String>();
                Dictionary<string, string> map = genarateMapBinding();
                string[] linesMap = txtSourceTxt.Text.Split(new[] { '\n', '\r' }) ;
                foreach (string line in linesMap)
                {
                    string key = getContainKey(map, line);
                    if (!String.IsNullOrEmpty(key))
                    {
                        rs.Add(line.Replace(key, map[key]) + " //" + key);
                    }
                    else
                    {
                        rs.Add(line);
                    }
                }
                return String.Join("\n", rs.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return String.Empty;
            }
        }

        private string ReplaceVietnameseInCsHtml()
        {
            try
            {
                List<String> rs = new List<String>();
                Dictionary<string, string> map = genarateMapBinding();

                string[] linesMap = txtSourceTxt.Text.Split(new[] { '\n', '\r' });
                foreach (string line in linesMap)
                {
                    string key = getContainKey(map, line);
                    if (!String.IsNullOrEmpty(key))
                    {
                        rs.Add(line.Replace(key, "@T(\"" + map[key] + "\")") + "\n @*" + key + "*@");
                    }
                    else
                    {
                        rs.Add(line);
                    }
                }
                return String.Join("\n", rs.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return String.Empty;
            }
        }

        private string getContainKey(Dictionary<string, string> map, string line)
        {
            string curKey = string.Empty;
            foreach (string key in map.Keys)
            {
                if (line.Contains(key) && key.Length > curKey.Length) { curKey = key; }
            }
            return curKey;
        }

        private Dictionary<string, string> genarateMapBinding()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            string[] linesMap = txtMapBinding.Text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in linesMap)
            {
                string[] arr = line.Split('=');
                if (!map.ContainsKey(arr[0].Trim()))
                {
                    map.Add(arr[0].Trim(), arr[1].Trim());
                }
            }
            return map;
        }

        private void btnFindAllVietnameseText_Click(object sender, EventArgs e)
        {
            try
            {
                String rs = String.Empty;
                switch (comboBoxSourceType.SelectedIndex)
                {
                    case 0:
                        rs = FindAllVietnameseInCsHtml(txtSourceTxt.Text);
                        break;
                    case 1:
                        rs = FindAllVietnameseInJS(txtSourceTxt.Text);
                        break;
                    case 2:
                        rs = FindAllVietnameseInCS(txtSourceTxt.Text);
                        break;
                }
                txtResultText.Text = rs;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private String FindAllVietnameseInCS(String strSource)
        {
            // Remove single-line comments starting with "//"
            strSource = Regex.Replace(strSource, @"//.*", "");

            // Remove multi-line comments starting with "/*" and ending with "*/"
            strSource = Regex.Replace(strSource, @"/\*.*?\*/", "", RegexOptions.Multiline);

            strSource = Regex.Replace(strSource, $".*{"SystemErrorWS"}+.*$", "", RegexOptions.Multiline);

            return findStringWithPattern(strSource, PATTERN_CS);
        }

        private String FindAllVietnameseInJS(String strSource)
        {
            // Remove single-line comments starting with "//"
            strSource = Regex.Replace(strSource, @"//.*", "");

            // Remove multi-line comments starting with "/*" and ending with "*/"
            strSource = Regex.Replace(strSource, @"/\*.*?\*/", "", RegexOptions.Singleline);
            return findStringWithPattern(strSource, PATTERN_JS);
        }

        private String FindAllVietnameseInCsHtml(String strSource)
        {
            // Remove single-line comments starting with "@*"
            strSource = Regex.Replace(strSource, @"@*\s*@.*?(?=\r?\n|$)", "", RegexOptions.Singleline);

            // Remove multi-line comments starting with "@* ... *@"
            strSource = Regex.Replace(strSource, @"@*\s*@.*?@\*", "", RegexOptions.Singleline);
            return findStringWithPattern(strSource, PATTERN_HTML);
        }

        private String findStringWithPattern(String input, String pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(input);
            StringBuilder sbResult = new StringBuilder();
            foreach (Match match in matches)
            {
                String str = match.Value.Replace("\t", "").Trim().Trim('\t').Trim().Trim(',').Trim();
                if (!String.IsNullOrEmpty(str))
                    sbResult.AppendLine(str);
            }
            return sbResult.ToString();
        }

        private void btnFindWithPattern_Click(object sender, EventArgs e)
        {
            txtResultText.Text = findStringWithPattern(txtSourceTxt.Text, txtPattern.Text.Trim());
        }
    }
}