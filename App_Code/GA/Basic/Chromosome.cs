/// represent a chromosome which is a testcase containing all of the features selected
using System;
using System.Collections;
using System.Text;

public class Chromosome 
{
    
    /// <Local variables>
    // object of class random to generate random values used in crossover
    private static Random rnd = new Random();

    // array of genes in each chromosome
    private ArrayList genes = new ArrayList();
    // holds the length of each Chromosome .. the number of genes in each one
    private int length = 0;
    // array to hold the number of features entered by the user
    private string[] features ;
    private string[] User;
    private string[] Use_Case;
      
    /// <properties>
    // get and set the maxlength of any chromosome, if exceed 64 GA will be too slow
    public const int MaxLength = 64;
    // get and set the values of all the genes in a chromosome
    public int[] CValues 
    { 
        get 
        {
            int[] x = new int[genes.Count];
            for (int i = 0; i < genes.Count; i++ )
            {
                x[i] = ((Gene)genes[i]).gValue;
            }
            return x;
        }
        set
        {
            for (int i = 0; i < genes.Count; i++)
            {
                ((Gene)genes[i]).gValue =value[i];
            }
        }
    }
    // get and set the maximum value of each gene in a chromosome
    public int[] CMaxes
    {
        get
        {
            int[] x = new int[genes.Count];
            for (int i = 0; i < genes.Count; i++)
            {
                x[i] = ((Gene)genes[i]).gMax;
            }
            return x;
        }
        
    }
    public int CSum()
    {
        int s = 0;
        foreach (int i in CValues)
        {
            s += i;
        }
        return s;
    }

    /// Constructor
    public Chromosome(string[] f, string[] c, string[] u) 
    {
        // check not to exceed maxlength of genes in each chromsome
        CGenerate(f, c , u);
        length = f.Length + 2;
        features = f;
        User = u;
        Use_Case = c;
    }
    
    /// Generate a chromosome with specified features
    public void CGenerate(string[] f, string[] c, string[] u)
    {
        for (int i = 0; i < f.Length; i++ )
        {
            if (i == 0)
            {
                Gene g = new Gene(f[i], c, u);
                genes.Add(g);
                g = new Gene("User");
                genes.Add(g);
                g = new Gene("Use_Case");
                genes.Add(g);
            }
            else
            {
                Gene g = new Gene(f[i]);
                genes.Add(g);
            }
        }
        
    }

    /// Get string representation of the chromosome
	public override string ToString( )
	{
		String sb = "Test IF: ";
        
        foreach (Object o in genes)
        {
            sb += o.ToString() + " & ";
        }
        sb = sb.Substring(0, sb.Length - 2);
        
		return sb.ToString( );
	}
    
    /// crossover two parents 
    public virtual void Crossover(Chromosome pp)
    {
        // create a random index to start the crossover
        int crossOverPoint = rnd.Next(length - 1) + 1;
        // length of chromosome to be crossed
        int crossOverLength = length - crossOverPoint;
        // temporary array
        int[] temp = new int[crossOverLength];
        // copy part of first (this) chromosome to temp
        Array.Copy(this.CValues, crossOverPoint, temp, 0, crossOverLength);
        // copy part of second (pair) pp chromosome to the first
        Array.Copy(pp.CValues, crossOverPoint, this.CValues, crossOverPoint, crossOverLength);
        // copy temp to the second
        Array.Copy(temp, 0, pp.CValues, crossOverPoint, crossOverLength);

    }
    
    /// Evaluate chromosome with fitness function if pass (true) add it to the population
    public bool Fitness(ArrayList p)
    {
        foreach (object o in p)
        {
            if ((CompareTo((Chromosome)o))== true)
            {
                return false;// if repeated do not add it to population
            }
        }
        return true;// not repeated add it to population
    }

    /// Compare two chromosomes
    public bool CompareTo(Chromosome c)
    {
        // returns true if equal
        // this new chromosome
        // c each chromosome in population
        for (int i = 0; i < c.CValues.Length; i++ )
        {
            if (this.CValues[i] != c.CValues[i])
                return false;
        }
        return true;
    }

    /// returns a copy of the chromosome
    public Chromosome Clone()
    {
        return new Chromosome(this.features, this.Use_Case, this.User);
    }

    /// Mutation operator
    public virtual void Mutate()
    {
        // mutate one chromosome
        // get random index
        int i = rnd.Next(length);
        // randomize the gene
        ((Gene)genes[i]).gValue = rnd.Next(((Gene)genes[i]).gMax + 1);

    }

    // Create new random chromosome 
    public Chromosome CreateOffspring()
    {
        return new Chromosome(this.features, this.Use_Case, this.User);
    }


    //public Chromosome(Chromosome c)
    //{
    //    c.genes = this.genes;
    //    c.length = this.length;
    //    c.fitness = this.fitness;
    //    c.cValues = this.cValues;
    //    c.features = this.features;
    //    c.calcFitness(this);
    //}

    
    //public void calcFitness(Chromosome chromosome)
    //{
    //    // get chromosome's value and max value
    //    int[] val = chromosome.cValues;
    //    int[] max = chromosome.cMaxes;
    //    double[] result = new double[val.Length];
    //    // translate to optimization's funtion space
    //    //for (int i = 0; i < val.Length; i++)
    //    //{
    //    //    result[i] = val[i] * range.Length / max[i] + range.Min;
    //    //}
    //    double sum = 0;
    //    for (int i = 0; i < result.Length; i++)
    //    {
    //        sum += result[i];
    //    }
    //    chromosome.cFitness = sum;
    //}
}

