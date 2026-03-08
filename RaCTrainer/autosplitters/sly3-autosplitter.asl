state("racman") {}

startup
{	
    settings.Add("EPISODE_1", true, "Episode 1");
}

init
{
    System.IO.MemoryMappedFiles.MemoryMappedFile mmf = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("racman-autosplitter");
    System.IO.MemoryMappedFiles.MemoryMappedViewStream stream = mmf.CreateViewStream();
    vars.reader = new System.IO.BinaryReader(stream);
    
    vars.reader.BaseStream.Position = 0;

    vars.jobsEpisode1 = new List<int> {2117, 2360, 2261, 2314, 2199, 2170, 2382, 2218, 2448};
    vars.currentJobIndex = 0;

    current.isLoading = vars.reader.ReadByte();
    current.currentJob = vars.reader.ReadUInt32();
    current.gameSpeed = vars.reader.ReadSingle();
    current.currentCheckpoint = vars.reader.ReadUInt32();
    current.currentMap = vars.reader.ReadUInt32();
    current.veniceStarted = vars.reader.ReadUInt32();
}

update
{
    vars.reader.BaseStream.Position = 0;

    current.isLoading = vars.reader.ReadByte();
    current.currentJob = vars.reader.ReadUInt32();
    current.currentCheckpoint = vars.reader.ReadUInt32();
    current.currentMap = vars.reader.ReadUInt32();
    current.veniceStarted = vars.reader.ReadUInt32();
    current.gameSpeed = vars.reader.ReadSingle();
}

start
{
    if (settings["EPISODE_1"])
    {
        return (current.veniceStarted == 1 && current.currentMap == 3);
    }
    
    return false;
}

isLoading
{
    if (current.isLoading == 3) {
        return false;
    }
    return true;
}

split
{
    if (settings["EPISODE_1"])
    {
        // Splits that have a checkpoint value before Job Complete screen
        if (current.gameSpeed == 0 && old.gameSpeed == 1) {
            if (current.currentCheckpoint == 2035) { return true; }
            if (current.currentCheckpoint == 2358) { return true; }
            if (current.currentCheckpoint == 2215) { return true; }
            if (current.currentCheckpoint == 2197) { return true; }
            if (current.currentCheckpoint == 2434) { return true; }
            if (current.currentCheckpoint == 2252) { return true; }
        }

        // Splits with checkpoint at Job Complete screen or other special splits
        if (current.currentCheckpoint == 2165 && old.currentCheckpoint != 2165) { return true; }
        if (current.currentCheckpoint == 2305 && old.currentCheckpoint != 2305) { return true; }
        if (current.currentCheckpoint == 1820 && old.currentCheckpoint != 1820) { return true; }
    }
    
    return false;
}

reset
{
    if (current.veniceStarted == 0 && current.currentMap == 3)
    {
        return true;
    }
}