using TypesClassesObjects;

TemplateClass testerObj = new TemplateClass();

if (testerObj._iAmPublic)
{
    Console.WriteLine("A public field has been accessed.");
}

// a public static field can only be accessed via the Class, not its objects.
var staticValue = TemplateClass._iAmPublicStatic;
Console.WriteLine(staticValue);