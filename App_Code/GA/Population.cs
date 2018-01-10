using System;
using System.Collections;
using System.Text;
//Population of chromosomes
  
public class Population
{
    /// local variables
    private ArrayList population = new ArrayList( );
	private int max = 100;
    private const int MIN = 15; 
	
    // population parameters
    private double  randomSelectionPortion  = 0.0;
	private double	crossOverRate	        = 0.75;
	private double	mutationRate	        = 0.10;
    
	// random number generator needed for crossover
    private static Random rnd = new Random( (int) DateTime.Now.Ticks );

    
    // get and set the size of the population
    public int Size { get { return population.Count; } } // readonly
    public int Max { get { return max; } set { max = value; } } // readonly
    
    // Constructor set the population arraylist
    public Population(string[] features, string[] usecases, string[] users)
    {
        /// Initialize the population 
        Chromosome ch, ch1 = null;
        //create first Chromosome and add it
        ch = new Chromosome(features, usecases, users);
        population.Add(ch);

        for (int i = 0; i <= MIN; i++)
        {
            // create new chromosome
            ch1 = new Chromosome(features, usecases, users);
            // calculate it's fitness
            if (ch1.Fitness(population))
            {
                // add chromosomes to the population
                population.Add(ch1);
                
            } 
        }
        do
        {    
        // generate new generation
        RunEpoch();
        } while (Regenerate()== true);// stop function
    }

    public Population(int m, string[] features, string[] usecases, string[]users)
    {
        Max = m;
        Chromosome ch, ch1 = null;
        //create first Chromosome and add it
        ch = new Chromosome(features, usecases, users);
        population.Add(ch);

        for (int i = 0; i <= MIN; i++)
        {
            // create new chromosome
            ch1 = new Chromosome(features, usecases, users);
            // calculate it's fitness
            if (ch1.Fitness(population))
            {
                // add chromosomes to the population
                population.Add(ch1);

            }
        }
        do
        {
            // generate new generation
            RunEpoch();
        } while (Regenerate() == true);// stop function
    }

    private bool Regenerate() // stop function
    {
        if (population.Count > max)
        {
            //trim the over cases
            int r = population.Count - max;
            for (int i = 0; i < r; i++)
            {
                population.RemoveAt(0);
            }
            return false;
        }
        else
            return true;
    }

    // get of population
    // get string represntation of the chromosome in the population
    public override string ToString()
    {
        String sb = "";
        int num = 0;
        for (int i = 0; i < population.Count; i++)
        {
            num = i + 1;
            sb += num.ToString() + ") " + ((Chromosome)population[i]).ToString() + "\n";
        }
        return sb;
    }

    // Do crossover in the population
    public virtual void Crossover()
    {
        // crossover
        for (int i = 1; i < population.Count; i += 2)
        {
            // generate next random number and check if we need to do crossover
            if (rnd.NextDouble() <= crossOverRate)
            {
                // clone both ancestors
                Chromosome c1 = ((Chromosome)population[i - 1]).Clone();
                Chromosome c2 = ((Chromosome)population[i]).Clone();

                // do crossover
                c1.Crossover(c2);

                // calculate fitness of the offspring 
                Evaluate(c1);
                Evaluate(c2);
            }
        }
    }

    //Calculate the fitness of the offsprings and add them if fit
    public void Evaluate(Chromosome c)
    {
        if (c.Fitness(population))
        {
            // add offspring to the population
            population.Add(c);
          
        }
    }

    /// Do mutation in the population
    public virtual void Mutate()
    {
        // mutate
        for (int i = 0; i < population.Count; i++)
        {
            // generate next random number and check if we need to do mutation
            if (rnd.NextDouble() <= mutationRate)
            {
                // clone the chromosome
                Chromosome c = ((Chromosome)population[i]).Clone();
                // mutate it
                c.Mutate();
                // calculate fitness of the mutant and add mutant to the population if fit
                Evaluate(c);
            }
        }
    }

    /// Do selection
    public virtual void Selection()
    {
        // amount of random chromosomes in the new population
        double randomAmount = randomSelectionPortion * (double)population.Count;

        // do selection
        RouletteWheelSelection r = new RouletteWheelSelection();
        r.ApplySelection(population);
        // population is reduced
        // add random chromosomes
        if (randomAmount > 0)
        {
            Chromosome ancestor = (Chromosome)population[0];
            for (int i = 0; i < randomAmount; i++)
            {
                // create new chromosome
                Chromosome c = ancestor.CreateOffspring();
                // calculate it's fitness add it to population if fit
                Evaluate(c);
            }
        }

        
    }
   
    /// Run one epoch of the population - crossover, mutation and selection
    public void RunEpoch()
    {
        Crossover();
        Mutate();
        Selection();
    }

    
}

