state("racman") {}

startup
{	
    settings.Add("EPISODE_1", true, "Episode 1");
    settings.SetToolTip("EPISODE_1", "Splits for Episode 1 category");

    settings.Add("EPISODE_2", false, "Episode 2");
    settings.SetToolTip("EPISODE_2", "Splits for Episode 2 category");
}

init
{
    System.IO.MemoryMappedFiles.MemoryMappedFile mmf = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("racman-autosplitter");
    System.IO.MemoryMappedFiles.MemoryMappedViewStream stream = mmf.CreateViewStream();
    vars.reader = new System.IO.BinaryReader(stream);
    
    vars.reader.BaseStream.Position = 0;

    vars.jobsEpisode1 = new List<int> {2117, 2360, 2261, 2314, 2199, 2170, 2382, 2218, 2448}
    vars.currentJob = 0;

    current.isLoading = vars.reader.ReadByte();
    current.currentJob = vars.reader.ReadUInt32();
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
}

start
{
    if (settings["EPISODE_1"])
    {
        return veniceStarted == 1;
    }
    
    return false;
}

split
{
    if (settings["EPISODE_1"])
    {
        if (old.currentJob == vars.jobsEpisode1[vars.currentJob] && current.currentJob != old.currentJob) {
            vars.currentJob++;
            return true;
        }
        if  (current.currentJob == 2448 && current.currentCheckpoint == 2516) {
            return true; // final split, Octavio defeated
        }
    }
    
    return false;
}

reset
{
    return current.veniceStarted == 0;
}