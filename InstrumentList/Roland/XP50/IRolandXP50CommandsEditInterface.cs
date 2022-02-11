namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //===============================  COMPLEX INTERFACES  ==============================
    public interface ISongListStorageSectionInterface : ISongListStoreData, ISongPresetName, IAdditionalSongTitle { }

    public interface IFastListStorageSectionInterface : IFastListStoreData, IFastPresetName { }

    public interface ISongListEditorSectionInterface : ISongCommandsEditInterface, IPerformancePartData, ISongPresetName, IPerformanceEditInterface, IAdditionalSongTitle { }

    public interface IFastListEditorSectionInterface : IFastCommandsEditInterface, IPerformancePartData, IFastPresetName { }

    //===============================  BASE INTERFACES  =================================
    // Interface for Song Edition data
    public interface ISongCommandsEditInterface
    {
        // Command EFXSource
        EFXSource GetCommandEFXSource(int comNumber);
        void SetCommandEFXSource(int comNumber, EFXSource src);
        // Command&Channel Local Switch
        LocalSwitch GetCommandLocalSwitch(int comNumber, int midichannel);
        void SetCommandLocalSwitch(int comNumber, int midichannel, LocalSwitch lcSw);
        // CallBack
        event SegmentDataReceivedHandler SongDataReceived;
    }

    // Interface for Fast Edition data
    public interface IFastCommandsEditInterface
    {
        // Command EFXSource
        EFXSource GetCommandEFXSource(int comNumber);
        void SetCommandEFXSource(int comNumber, EFXSource src);
        // Command&Channel Local Switch
        LocalSwitch GetCommandLocalSwitch(int comNumber, int midichannel);
        void SetCommandLocalSwitch(int comNumber, int midichannel, LocalSwitch lcSw);
        // CallBack
        event SegmentDataReceivedHandler FastDataReceived;
    }

    // Performance Part List Interface
    public interface IPerformancePartData
    {
        // Preset Receive Hold Parameter
        RecieveHold1Switch GetRecieveHold1Switch(int channel);
        void SetRecieveHold1Switch(int channel, RecieveHold1Switch hold);
        // Lower Key
        byte GetLowerKey(int channel);
        void SetLowerKey(int channel, byte key);
        // Upper Key
        byte GetUpperKey(int channel);
        void SetUpperKey(int channel, byte key);
        // Volume
        byte GetVolume(int channel);
        void SetVolume(int channel, byte val);
        // Pan
        byte GetPan(int channel);
        void SetPan(int channel, byte val);
        // Reverb
        byte GetReverb(int channel);
        void SetReverb(int channel, byte val);
        // Chorus
        byte GetChorus(int channel);
        void SetChorus(int channel, byte val);
        // Patch
        byte[] GetPatch(int channel);
        void SetPatch(int channel, byte[] data);
        // Octave
        byte GetOctaveShift(int channel);
        void SetOctaveShift(int channel, byte val);
        
    }

    // Interface for Storing SongList Data  (+)
    public interface ISongListStoreData
    {
        void SetSongData(byte[] data);
        byte[] GetSongData();
        void SetSongCommandSection(byte[] data);
        byte[] GetSongCommandSection();
    }

    // Interface for Storing FastList Data  (+)
    public interface IFastListStoreData
    {
        void SetFastData(byte[] data);
        byte[] GetFastData();
        void SetFastCommandSection(byte[] data);
        byte[] GetFastCommandSection();
    }

    // Song Preset and Commands name
    public interface ISongPresetName
    {
        // Preset or Song Name
        string PresetName { get; set; }
        // Command Name
        string GetCommandName(int comNumber);
        void SetCommandName(int comNumber, string name);
    }

    // Fast Preset and Commands name
    public interface IFastPresetName
    {
        // Preset or Song Name
        string PresetName { get; set; }
        // Command Name
        string GetCommandName(int comNumber);
        void SetCommandName(int comNumber, string name);
    }

    // Additional parameters for Edition Performance Common (Song Section)
    public interface IPerformanceEditInterface
    {
        string PerformanceTitle { get; set; }
        byte Tempo { get; set; }
    }

    // Addition Song Parameters for Song Section (Edit and Store)
    public interface IAdditionalSongTitle
    {
        // Singer or Athor name
        string Singer { get; set; }
        // Score Key
        string Key { get; set; }
    }
}

    
