using Microsoft.ML.OnnxRuntimeGenAI;

Console.WriteLine("Hello From Phi-2");

var modelPath = "phi2-int4-cuda";

// Initialize model, tokenizers, and parameters
using Model model = new Model(modelPath);
using Tokenizer tokenizer = new Tokenizer(model);

using GeneratorParams generatorParams = new GeneratorParams(model);
generatorParams.SetSearchOption("max_length", 200);

while(true)
{
    // Capture user input
    Console.WriteLine("Prompt: ");
    string prompt = Console.ReadLine();

    // Encode input using the tokenizer 
    var sequences = tokenizer.Encode(prompt);

    // Set input
    generatorParams.SetInputSequences(sequences);

    // Generate output
    var outputSequences = model.Generate(generatorParams);
    
    // Decode model output
    var outputString = tokenizer.Decode(outputSequences[0]);

    Console.WriteLine("Output: {outputString}");
}
