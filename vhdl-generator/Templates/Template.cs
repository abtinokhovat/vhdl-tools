using System.Text;

namespace vhdl_generator.Templates;

public abstract class Template
{
    protected Template(string entity, string name)
    {
        Entity = entity;
        Name = name;
    }

    protected static string ToPascalCase(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        var words = str.Split(new[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);
        var result = new StringBuilder();
        foreach (var word in words)
        {
            var firstChar = word[0];
            var restChars = word.Substring(1);
            result.Append(char.ToUpper(firstChar));
            result.Append(restChars.ToLower());
        }
        return result.ToString();
    }

    public abstract void WriteStringToFile();

    protected string Entity { get; set; }
    protected string Name { get; set; }
}