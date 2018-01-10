/// Chromosome Interface
/// contains a number of genes that is equal to the number of tested features
/// each gene is represented as a number not string
/// a chromosome is a test suit
using System;
	
public interface IChromosome 
{
	
	/// Chromosome's fintess value
    double cFitness { get; } 
   
    /// Generate random chromosome according to features
	void cGenerate(string[] f);
    /// Compare two chromosomes
    int CompareTo(Chromosome c);
    /// Clone the chromosome
    Chromosome Clone();
    /// Mutation operator
    void Mutate();
    /// Crossover operator
    void Crossover(Chromosome pair);
    /// Evaluate chromosome with specified fitness function
   // void Evaluate(IFitnessFunction function);
    Chromosome CreateOffspring();
}

