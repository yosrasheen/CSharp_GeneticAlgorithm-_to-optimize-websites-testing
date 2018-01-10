using System;
using System.Collections;

/// Roulette Wheel selection method
public class RouletteWheelSelection : ISelectionMethod
{
	// random number generator
	private static Random rnd = new Random( (int) DateTime.Now.Ticks );

	/// Default constructor
	public RouletteWheelSelection( ) { }

	/// Apply selection to the population
	public void ApplySelection( ArrayList population )
	{
        // new population, initially empty
		ArrayList newPopulation = new ArrayList( );

		// size of current population
		int currentSize = population.Count;
        
        //// step 1: calculate summary fitness of current population
        double fitnessSum = 0;
        foreach (Chromosome c in population)
        {
            fitnessSum += (double)c.CSum();
        }

        
		// step 2: create wheel ranges -- r[]
		double[]	rangeMax = new double[currentSize];
		double		s = 0;
		int			i = 0;
        foreach (Chromosome c in population)
        {
            // cumulative normalized fitness
            s = (c.CSum() / (fitnessSum / 4) )  ;
            rangeMax[i++] = s;
        }
               
		// step 3: loop 
        // select chromosomes from old population to the new population
		for ( i = 0; i < currentSize; i++ )
        {
            // get wheel value -- random number -- Roulette ball
            double wheelValue = rnd.NextDouble();
            // find the chromosome for the wheel value
            // When the sum s is greater than r
            if (wheelValue >= rangeMax[i])
            {
                // add the chromosome to the new population
                newPopulation.Add(((Chromosome)population[i]).Clone());

            }
        }

		// empty current population
		population.Clear( );
        int n = newPopulation.Count;
        // When the sum s is greater than r, stop and return the chromosome where you are
        // move elements from new population to current population
        for (i = 0; i < n; i++)
		{
			population.Add( newPopulation[0] );// old population has fit values only
			newPopulation.RemoveAt( 0 );// empty the new population
		}
	}
}

