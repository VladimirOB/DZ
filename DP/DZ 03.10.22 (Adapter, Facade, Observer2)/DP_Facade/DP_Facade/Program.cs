using System;

namespace Facade
{
    class MainApp
    {
        public static void Main()
        {
            VisualStudio studio = new VisualStudio();

            studio.RunFromMemory("void main(){}");

            studio.BuildToFile(@"d:\result.exe");

            // Wait for user 
            Console.Read();
        }
    }

    // "Subsystem ClassA" 
    class Parser
    {
        public void ParseText(string text)
        {
            Console.WriteLine("Parser.ParseText Method");
        }

        public void ParseFile(string filename)
        {
            Console.WriteLine("Parser.ParseFile Method");
        }
    }

    // Subsystem ClassB" 
    class Compiler
    {
        public void Compile()
        {
            Console.WriteLine("Compiler.Compile Method");
        }
    }

    // Subsystem ClassC" 
    class SemanticAnalizer
    {
        public void Analize()
        {
            Console.WriteLine("SemanticAnalizer.Analize Method");
        }
    }

    // Subsystem ClassD"
    class Linker
    {
        public void LinkToMemory()
        {
            Console.WriteLine("Linker.LinkToMemory Method");
        }

        public void LinkToFile()
        {
            Console.WriteLine("Linker.LinkToFile Method");
        }
    }

    // "Facade" 
    class VisualStudio
    {
        Parser parser;
        Compiler compiler;
        SemanticAnalizer analizer;
        Linker linker;

        public VisualStudio()
        {
            parser = new Parser();
            compiler = new Compiler();
            analizer = new SemanticAnalizer();
            linker = new Linker();
        }

        public void RunFromMemory(string code)
        {
            parser.ParseText(code);
            compiler.Compile();
            linker.LinkToMemory();
        }

        public void BuildToFile(string filename)
        {
            parser.ParseText("text");
            compiler.Compile();
            linker.LinkToFile();
        }
    }
}

