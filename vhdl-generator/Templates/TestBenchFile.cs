namespace vhdl_generator.Templates;

public class TestBenchFile : Template
{
    public string Template =>
        @$"
library ieee;
use ieee.std_logic_1164.all;

entity tb_{Entity.ToLower()} is
end entity;

architecture behavioral of tb_{Entity.ToLower()} is
    component {Entity.ToLower()} is
        generic();
        port();
    end component {Entity.ToLower()};

    -- signals here
    
    begin
        uut: {Entity.ToLower()} port map();
        process
        begin  
        wait;
        end process;
    end;
end behavioral;


        ";

    public TestBenchFile(string entity,string name) : base(entity,name)
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
        // // Write template to file
         var filePath = Path.Combine(pascalCaseName, $"tb_{ToPascalCase(Name)}.vhd");
         using var writer = new StreamWriter(filePath);
        writer.Write(Template);
    }
}