using System;
using System.Collections;

/// Selection method interface
public interface ISelectionMethod
{
	/// Apply selection to the population
    void ApplySelection(ArrayList chromosomes);
}
