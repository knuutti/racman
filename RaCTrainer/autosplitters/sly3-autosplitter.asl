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

    current.currentCharacter = vars.reader.ReadByte();
    current.isLoading = vars.reader.ReadByte();
    current.currentJob = vars.reader.ReadUInt32();
    current.currentCheckpoint = vars.reader.ReadUInt32();
    current.currentMap = vars.reader.ReadUInt32();
}

update
{
    vars.reader.BaseStream.Position = 0;

    current.currentCharacter = vars.reader.ReadByte();
    current.isLoading = vars.reader.ReadByte();
    current.currentJob = vars.reader.ReadUInt32();
    current.currentCheckpoint = vars.reader.ReadUInt32();
    current.currentMap = vars.reader.ReadUInt32();
}

start
{
    if (settings["EPISODE_1"])
    {
        return current.currentCharacter == 7;
    }
    
    if (settings["EPISODE_2"])
    {
        return current.currentJob == 4294967295; // -1 as uint32
    }
    
    return false;
}

split
{
    if (settings["EPISODE_1"])
    {
        // Episode 1 split condition
        if (current.currentCharacter == 8 && old.currentCharacter != 8)
        {
            return true;
        }
    }
    
    if (settings["EPISODE_2"])
    {
        // Episode 2 split conditions
        if (current.currentJob == 23 && old.currentJob != 23)
        {
            return true;
        }
        
        if (current.currentJob == 234 && old.currentJob != 234)
        {
            return true;
        }
    }
    
    return false;
}

reset
{
    return current.isLoading == 1;
}