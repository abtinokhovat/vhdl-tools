namespace vhdl_generator.Templates;

public class MainFile : Template
{
    public string Template =>
        $@"
library IEEE;
use IEEE.STD_LOGIC_1164.all;
use IEEE.NUMERIC_STD.all;

entity {Entity.ToLower()} is
port();
end {Entity.ToLower()};

architecture behavior of {Entity.ToLower()} is
begin
end behavior;
        ";

    public MainFile(string entity,string name) : base(entity,name)
    {
    }

    public override void WriteStringToFile()
    {
        // Convert name to PascalCase
        var pascalCaseName = ToPascalCase(Name);

        // Check if directory exists and create it if it doesn't
        if (!Directory.Exists(pascalCaseName))
        {
            Directory.CreateDirectory(pascalCaseName);
        }
        // Write template to file
        var filePath = Path.Combine(pascalCaseName, $"{pascalCaseName}.vhd");
        using var writer = new StreamWriter(filePath);
        writer.Write(Template);
    }
}