namespace SynthLiveMidiController.Instrument
{
    interface IInstrumentCommandInterface
    {
        byte[] Header { get; }
        byte Dt1Command { get; }
        byte RequestCommand { get; }
        int HeaderLength { get; }
    }
}
