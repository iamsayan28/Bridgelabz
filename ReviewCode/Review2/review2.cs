using System.Text.RegularExpressions;

public class ExtractionRule<TResult>
{
    public string Pattern { get; set; }
    public Func<Match, TResult> Transform { get; set; } // ig transform Match result to TResult type

    public ExtractionRule(string pattern, Func<Match,TResult> transform)
    {
        Pattern = pattern;
        Transform = transform;
    }
}


public class TokenExt<TResult>
{
    private Dictionary<string, ExtractionRule<TResult>> rules = new Dictionary<string, ExtractionRule<TResult>>();

    public TokenExt(string ruleName, string pattern, Func<Match, TResult> actualRule)
    {
        ExtractionRule<TResult> rule = new ExtractionRule<TResult>(pattern, actualRule);
        rules.Add(ruleName, rule);
    }

    public TokenExt<TResult> AddRule(string ruleName, string pattern, Func<Match, TResult> actualRule)
    {
        ExtractionRule<TResult> rule = new ExtractionRule<TResult>(pattern, actualRule);
        rules.Add(ruleName, rule);
        return this;
    }

    public void RemoveRule(string ruleName)
    {
        rules.Remove(ruleName);
    }

    public Dictionary<string, ExtractionRule<TResult>> GetRules()
    {
        return rules;
    }

    public List<TResult> ApplyRules(string text)
    {
        Stack<TResult> stack = new Stack<TResult>();
        HashSet<TResult> set = new HashSet<TResult>();
        List<TResult> list = new List<TResult>();

        foreach (KeyValuePair<string, ExtractionRule<TResult>> rule in rules)
        {
            Regex regex = new Regex(rule.Value.Pattern);
            
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                TResult token = rule.Value.Transform(match);

                if (set.Add(token))
                {
                    stack.Push(token);
                }
            }
        }

        while (stack.Count > 0)
        {
            list.Add(stack.Pop());
        }

        return list;
    }
}

public class review2
{
    public static void Main(string[] args)
    {
        string dummyText = "asb cASA BDcf ghs asb";

        string pattern1 = @"\b[a-z]+\b";
        string pattern2 = @"[.a-zA-Z0-9]+@[.a-zA-Z0-9].[.a-z]{2,}$";

        TokenExt<string> extractor = new TokenExt<string>("Lower Case Match Rule", pattern1, match => match.Value);

        extractor.AddRule("Email Pattern Match Rule", pattern2, match => match.Value);

        List<string> res = extractor.ApplyRules(dummyText);

        foreach (string item in res)
        {
            Console.WriteLine(item);
        }
    }
}