/// Gene Interface
/// used to reperesent each feature to be tested
/// each feature has a range of accepted string values
/// but it will hold only one value
/// a gene is a test case
using System;

public interface IGene
{
	/// Gene type
    string gType { get; }
    /// Maximum value
	int gMax { get; }
   	/// Minimum value
	int gMin { get; }
    /// Get current value
    int gValue { get; set; }
    /// Clone the gene
    IGene Clone(IGene g);
    /// Creates new gene with specified type
    void Generate(string type);
    
    //IGene CreateNew( );
    ///// Creates new gene with certain type and minimum and maximum
    //IGene CreateNew(GeneType type, int min, int max);
}

