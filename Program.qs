namespace HydrogenAtomSimulation {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Convert;

    operation EnergyLevel(n : Int) : Double {
        let energy = -13.6 / IntAsDouble (n * n);
        return energy;
    }

    @EntryPoint()
    operation main() : Unit {
        for n in 1..3 {
            Message($"Energy level {n}: {EnergyLevel(n)} eV");
        }
    }
}
