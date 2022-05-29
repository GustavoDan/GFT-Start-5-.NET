var knight = new Knight("Arus", 42);
var ninja = new Ninja("Wedge", 42);
var whiteWizard = new WhiteWizard("Jenica", 42);
var blackWizard = new BlackWizard("Topapa", 42);

System.Console.WriteLine(knight);
System.Console.WriteLine(knight.Attack(1));
System.Console.WriteLine(knight.Attack(7));

System.Console.WriteLine(whiteWizard);
System.Console.WriteLine(whiteWizard.Attack(1));
System.Console.WriteLine(whiteWizard.Attack(7));

System.Console.WriteLine(ninja);
System.Console.WriteLine(ninja.Attack(1));
System.Console.WriteLine(ninja.Attack(7));

System.Console.WriteLine(blackWizard);
System.Console.WriteLine(blackWizard.Attack(1));
System.Console.WriteLine(blackWizard.Attack(7));
