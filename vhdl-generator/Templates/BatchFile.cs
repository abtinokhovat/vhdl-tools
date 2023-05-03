using System.Text;

namespace vhdl_generator.Templates;

public class BatchFile : Template
{
    public string Template => $@"
@echo off 
set GHDL=ghdl 
set FLAGS=--std=08 
rem Analyze source files 
%GHDL% -a %FLAGS% {ToPascalCase(Name)}.vhd
%GHDL% -a %FLAGS% {ToPascalCase(Name)}_tb.vhd
rem Elaborate testbench entity 
%GHDL% -e %FLAGS% tb_{Entity.ToLower()}
rem Run simulation and save waveform 
%GHDL% -r %FLAGS% tb_{Entity.ToLower()} --wave=wave.ghw --stop-time=1000ns";

    public BatchFile(string entity, string name) : base(entity, name)
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
        var filePath = Path.Combine(pascalCaseName, "run.bat");
        using var writer = new StreamWriter(filePath);
        writer.Write(Template);
    }
}