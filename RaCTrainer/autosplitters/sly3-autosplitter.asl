state("SluMAN") {}

startup
{	
    settings.Add("EPISODE_1", true, "Episode 1");
    settings.Add("EPISODE_2", false, "Episode 2");
    settings.Add("EPISODE_3", false, "Episode 3");
    settings.Add("EPISODE_4", false, "Episode 4");
    settings.Add("EPISODE_5", false, "Episode 5");
    settings.Add("EPISODE_6", false, "Episode 6");
    settings.Add("ANY", false, "Any%");
}

init
{
    System.IO.MemoryMappedFiles.MemoryMappedFile mmf = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("racman-autosplitter");
    System.IO.MemoryMappedFiles.MemoryMappedViewStream stream = mmf.CreateViewStream();
    vars.reader = new System.IO.BinaryReader(stream);
    
    vars.reader.BaseStream.Position = 0;

    vars.jobsEpisode1 = new List<int> {2117, 2360, 2261, 2314, 2199, 2170, 2382, 2218, 2448};
    vars.currentJobIndex = 0;
    vars.splitPending = false;
    vars.splitPendingTime = DateTime.Now;
    vars.kaineStarted = false;
    vars.hollandStarted = false;

    current.isLoading = vars.reader.ReadByte();
    current.currentJob = vars.reader.ReadUInt32();
    current.currentCheckpoint = vars.reader.ReadUInt32();
    current.currentMap = vars.reader.ReadUInt32();
    current.gameSpeed = vars.reader.ReadSingle();
    current.slyCharacterPointer = vars.reader.ReadUInt32();
    current.activeCharacterPointer = vars.reader.ReadUInt32();
    current.cameraFov = vars.reader.ReadSingle();
    current.veniceStarted = vars.reader.ReadUInt32();
    current.outbackStarted = vars.reader.ReadUInt32();
    current.chinaStarted = vars.reader.ReadUInt32();
    current.pirateStarted = vars.reader.ReadUInt32();
}

update
{
    vars.reader.BaseStream.Position = 0;

    current.isLoading = vars.reader.ReadByte();
    current.currentJob = vars.reader.ReadUInt32();
    current.currentCheckpoint = vars.reader.ReadUInt32();
    current.currentMap = vars.reader.ReadUInt32();
    current.gameSpeed = vars.reader.ReadSingle();
    current.slyCharacterPointer = vars.reader.ReadUInt32();
    current.activeCharacterPointer = vars.reader.ReadUInt32();
    current.cameraFov = vars.reader.ReadSingle();
    current.veniceStarted = vars.reader.ReadUInt32();
    current.outbackStarted = vars.reader.ReadUInt32();
    current.chinaStarted = vars.reader.ReadUInt32();
    current.pirateStarted = vars.reader.ReadUInt32();
    print("" + current.currentCheckpoint);
}

start
{
    if (settings["ANY"] && vars.kaineStarted == false && current.currentMap == 35 && current.cameraFov == 1.06f && current.currentJob == 1798) 
    { 
        vars.kaineStarted = true;
        return true;
        
    }
    else if (settings["EPISODE_1"] && current.veniceStarted == 1 && old.veniceStarted == 0 && current.currentMap == 3 && current.isLoading == 3) { return true; }
    else if (settings["EPISODE_2"] && current.outbackStarted == 1 && old.outbackStarted == 0 && current.currentMap == 8 && current.isLoading == 3) { return true; }
    else if (settings["EPISODE_3"] && vars.hollandStarted == false && old.cameraFov == 0.95f && current.cameraFov != 0.95f && current.cameraFov != 1.0f && current.currentMap == 15) 
    { 
        vars.hollandStarted = true;
        return true; 
    }
    else if (settings["EPISODE_4"] && current.chinaStarted == 3 && old.chinaStarted == 1 && current.currentMap == 23 && current.isLoading == 3) { return true; }
    else if (settings["EPISODE_5"] && current.pirateStarted == 3 && old.pirateStarted == 1 && current.currentMap == 31 && current.isLoading == 3) { return true; }
    else if (settings["EPISODE_6"] && current.currentCheckpoint == 4369 && old.currentCheckpoint != 4369) { return true; }
    return false;
}

isLoading
{
    return current.isLoading != 3;
}

onReset
{
    vars.splitPending = false;
    vars.splitPendingTime = DateTime.Now;
    vars.kaineStarted = false;
    vars.hollandStarted = false;
}

split
{
    if (vars.splitPending == true)
    {
        if (vars.splitPendingTime < DateTime.Now)
        {
            vars.splitPending = false;
            return true;
        }
        return false;
    }

    if (settings["ANY"])
    {
        // The Cooper Vault
        if (old.currentCheckpoint == 2029 && current.currentCheckpoint != 2029 && current.currentJob == 1798) 
        { 
            return true; 
        }

        // Hazard Room
        if (old.currentCheckpoint == 4618 && current.currentCheckpoint != 4618) { vars.splitPending = true; }

        // Start Episode
        if (current.veniceStarted == 1 && old.veniceStarted == 0 && current.currentMap == 3 && current.isLoading == 3) { return true; }
        if (current.outbackStarted == 1 && old.outbackStarted == 0 && current.currentMap == 8 && current.isLoading == 3) { return true; }
        if (vars.hollandStarted == false && old.cameraFov == 0.95f && current.cameraFov != 0.95f && current.cameraFov != 1.0f && current.currentMap == 15) 
        { 
            vars.hollandStarted = true;
            return true; 
        }
        if (current.chinaStarted == 3 && old.chinaStarted == 1 && current.currentMap == 23 && current.isLoading == 3) { return true; }
        if (current.pirateStarted == 3 && old.pirateStarted == 1 && current.currentMap == 31 && current.isLoading == 3) { return true; }
        if (current.currentCheckpoint == 4369 && old.currentCheckpoint != 4369) { return true; }

        // King of Fire
        if (old.currentCheckpoint == 3454 && current.currentCheckpoint != 3454) 
        { 
            return true;
        }
    }

    if (settings["EPISODE_1"] || settings["ANY"])
    { 
        // Splits that have a checkpoint value before Job Complete screen
        if (current.gameSpeed == 0 && old.gameSpeed == 1) 
        {
            if (current.currentCheckpoint == 2035) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2358) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2215) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2197) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2434) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2252) { vars.splitPending = true; }
        }

        // Final split
        else if (current.currentCheckpoint == 1820 && old.currentCheckpoint != 1820) { return true; }
        
        // Splits that change checkpoint value when Job Complete animation starts
        else 
        {
            if (current.currentCheckpoint == 2165 && old.currentCheckpoint != 2165) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2305 && old.currentCheckpoint != 2305) { vars.splitPending = true; }
        }
    }

    if (settings["EPISODE_2"] || settings["ANY"])
    {
        if (current.gameSpeed == 0 && old.gameSpeed == 1) 
        {
            if (current.currentCheckpoint == 2032) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2648) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2862) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2033) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2720) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2688) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2037) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2820) { vars.splitPending = true; }
        }

        // Final split
        else if (current.currentCheckpoint == 2944 && old.currentCheckpoint == 2942) {
            return true;
        }
        else if (current.currentCheckpoint == 2942 && old.currentCheckpoint == 2944) {
            return true;
        }
    }

    if (settings["EPISODE_3"] || settings["ANY"])
    {
        if (current.gameSpeed == 0 && old.gameSpeed == 1) 
        {
            if (current.currentCheckpoint == 3038) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 3175) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 3223) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2043) { vars.splitPending = true; }
        }

        // Final split
        else if (current.currentCheckpoint == 1822 && old.currentCheckpoint != 1822) {
            return true;
        }

        else 
        {
            if (current.currentCheckpoint == 3083 && old.currentCheckpoint != 3083) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 3123 && old.currentCheckpoint != 3123) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 3161 && old.currentCheckpoint != 3161) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 3181 && old.currentCheckpoint != 3181) { vars.splitPending = true; }
        }
    }

    if (settings["EPISODE_4"] || settings["ANY"])
    {
        if (current.gameSpeed == 0 && old.gameSpeed == 1) 
        {
            if (current.currentCheckpoint == 3554) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 3644) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2038) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 3729) { vars.splitPending = true; }
        }

        if (old.currentCheckpoint == 3525 && current.currentCheckpoint != 3525) { return true; }

        // Final split
        if (current.currentCheckpoint == 1823 && old.currentCheckpoint != 1823) 
        {
            return true;
        }

        if (current.currentCheckpoint == 3603 && old.currentCheckpoint != 3603) 
        { 
            vars.splitPending = true; 
        }
        else if (current.currentCheckpoint == 3704 && old.currentCheckpoint != 3704) 
        { 
            vars.splitPending = true; 
        }
    }

    if (settings["EPISODE_5"] || settings["ANY"])
    {
        if (current.gameSpeed == 0 && old.gameSpeed == 1) 
        {
            if (current.currentCheckpoint == 4083) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2040) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 2044) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 4132) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 4157) { vars.splitPending = true; }
        }

        // Final split
        else if (current.currentCheckpoint == 4221 && old.currentCheckpoint != 4221) 
        {
            return true;
        }

        else 
        {
            if (current.currentCheckpoint == 3923 && old.currentCheckpoint != 3923) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 4001 && old.currentCheckpoint != 4001) { vars.splitPending = true; }
        }
    }

    if (settings["EPISODE_6"] || settings["ANY"])
    {
        // Final split
        if (current.currentCheckpoint == 1825 && old.currentCheckpoint != 1825) 
        {
            return true;
        }

        else 
        {
            if (current.currentCheckpoint == 1843 && old.currentCheckpoint != 1843) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 1844 && old.currentCheckpoint != 1844) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 1845 && old.currentCheckpoint != 1845) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 1846 && old.currentCheckpoint != 1846) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 1847 && old.currentCheckpoint != 1847) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 1848 && old.currentCheckpoint != 1848) { vars.splitPending = true; }
            else if (current.currentCheckpoint == 1849 && old.currentCheckpoint != 1849) { vars.splitPending = true; }
        }
    }

    if (vars.splitPending == true) { vars.splitPendingTime = DateTime.Now.AddMilliseconds(1283);}
    
    return false;
}

reset
{
    if (settings["EPISODE_1"] && current.veniceStarted == 0 && current.currentMap == 3)
    {
        return true;
    }
    
    if (settings["EPISODE_2"] && current.outbackStarted == 0 && current.currentMap == 8 && current.isLoading == 3) 
    { 
        return true; 
    }

    if (settings["EPISODE_4"] && current.chinaStarted == 1 && current.currentMap == 23 && current.isLoading == 3) 
    { 
        return true; 
    }

    if (settings["EPISODE_5"] && current.pirateStarted == 1 && current.currentMap == 31 && current.isLoading == 3) 
    { 
        return true; 
    }

}