Console.Title = "Composite";

var root = new Composite.Directory("root", 0);
var topLevelFile = new Composite.File("toplevel.txt", 100);
var topLevelDirectory1 = new Composite.Directory("topleveldir1", 4);
var topLevelDirectory2 = new Composite.Directory("topleveldir2", 4);

root.Add(topLevelFile);
root.Add(topLevelDirectory1);
root.Add(topLevelDirectory2);

var subLevelFile1 = new Composite.File("sublevel1.txt", 300);
var subLevelFile2 = new Composite.File("sublevel2.txt", 900);

topLevelDirectory1.Add(subLevelFile1);
topLevelDirectory2.Add(subLevelFile2);

Console.WriteLine(root.GetSize());