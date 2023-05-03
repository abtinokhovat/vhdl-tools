using vhdl_generator.Templates;

Console.WriteLine("Enter File Name");
var name = Console.ReadLine();
Console.WriteLine("Enter Entity Name");
var entity = Console.ReadLine();

var all = new List<Template>();

var main = new MainFile(entity!, name!);
all.Add(main);

var test = new TestBenchFile(entity!, name!);
all.Add(test);

var batch = new BatchFile(entity!, name!);
all.Add(batch);

foreach (var file in all)
{
    file.WriteStringToFile();
}


