// See https://aka.ms/new-console-template for more information
using TargetReflection;

Spy spy = new Spy();
Console.WriteLine(spy.StealFieldInfo("Target", "PublicInfo", "PrivateInfo"));

Console.WriteLine(spy.AnalyzeAccessModifiers("Target"));

Console.WriteLine(spy.RevealPrivateMethods("Target"));

Console.WriteLine(spy.CollectGettersAndSetters("Target"));
