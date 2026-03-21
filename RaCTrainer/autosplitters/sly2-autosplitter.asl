state("SluMAN") {}

startup
{	
    settings.Add("EPISODE_1", false, "Episode 1");
    settings.Add("EPISODE_2", false, "Episode 2");
    settings.Add("EPISODE_3", false, "Episode 3");
    settings.Add("EPISODE_4", false, "Episode 4");
    settings.Add("EPISODE_5", false, "Episode 5");
    settings.Add("EPISODE_6", false, "Episode 6");
    settings.Add("EPISODE_7", false, "Episode 7");
    settings.Add("EPISODE_8", false, "Episode 8");
    settings.Add("ANY", false, "Any%");
}

init
{
    System.IO.MemoryMappedFiles.MemoryMappedFile mmf = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting("racman-autosplitter");
    System.IO.MemoryMappedFiles.MemoryMappedViewStream stream = mmf.CreateViewStream();
    vars.reader = new System.IO.BinaryReader(stream);
    
    vars.reader.BaseStream.Position = 0;

    vars.splitPending = false;
    vars.splitPendingTime = DateTime.Now;

    vars.cairoStarted = false;

    current.isLoading = vars.reader.ReadByte();
    current.jobId = vars.reader.ReadUInt32();
    current.checkpointId = vars.reader.ReadUInt32();
    current.mapId = vars.reader.ReadUInt32();
    current.gameSpeed = vars.reader.ReadSingle();
    current.slyCharacterPointer = vars.reader.ReadUInt32();
    current.activeCharacterPointer = vars.reader.ReadUInt32();
    current.cameraFov = vars.reader.ReadSingle();
    current.cameraParameter = vars.reader.ReadSingle();
    current.pauseMenuState = vars.reader.ReadUInt32();
    current.parisStarted = vars.reader.ReadUInt32();
}

update
{
    vars.reader.BaseStream.Position = 0;

    current.isLoading = vars.reader.ReadByte();
    current.jobId = vars.reader.ReadUInt32();
    current.checkpointId = vars.reader.ReadUInt32();
    current.mapId = vars.reader.ReadUInt32();
    current.gameSpeed = vars.reader.ReadSingle();
    current.slyCharacterPointer = vars.reader.ReadUInt32();
    current.activeCharacterPointer = vars.reader.ReadUInt32();
    current.cameraFov = vars.reader.ReadSingle();
    current.cameraParameter = vars.reader.ReadSingle();
    current.pauseMenuState = vars.reader.ReadUInt32();
    current.parisStarted = vars.reader.ReadUInt32();
}

start
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

    if (settings["ANY"] && vars.cairoStarted == false && current.cameraParameter == 49.0f && current.jobId == 1696) 
    { 
        vars.cairoStarted = true;
        vars.splitPending = true;
        vars.splitPendingTime = DateTime.Now.AddMilliseconds(133);
        return false; 
    }
    if (settings["EPISODE_1"] && current.parisStarted == 0 && current.activeCharacterPointer != 0 && current.pauseMenuState == 0)
    {
        return true;
    }

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
    vars.cairoStarted = false;
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
        // Cairo Split and start episode splits come here
    }

    if (settings["EPISODE_1"] || settings["ANY"])
    { 
        if (current.checkpointId == 1793 && current.gameSpeed != old.gameSpeed)
        {
            // Satellite Sabotage
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1820 && old.activeCharacterPointer == 0 && current.activeCharacterPointer != 0 && current.gameSpeed == 0.0f)
        {
            // Breaking and Entering
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1632 && current.gameSpeed != old.gameSpeed)
        {
            // Bug Dimitri's Office
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1845 && current.gameSpeed != old.gameSpeed)
        {
            // Follow Dimitri
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1908 && current.gameSpeed == 0.0f && current.gameSpeed != old.gameSpeed)
        {
            // Waterpump Destruction
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1831 && old.checkpointsId != 1831)
        {
            // Silence the Alarms
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1881 && current.gameSpeed != old.gameSpeed)
        {
            // Moonlight Rendezvous
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1871 && current.gameSpeed != old.gameSpeed)
        {
            // Theater Pickpocketing
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1898 && current.gameSpeed != old.gameSpeed)
        {
            // Disco Demolitions
            vars.splitPending = true;
        }
        else if (current.checkpointId == 1953 && old.checkpointId != 1953)
        {
            // Operation: Thunderbeak
            return true;
        }
    }

    if (vars.splitPending == true) { vars.splitPendingTime = DateTime.Now.AddMilliseconds(1950);}
    
    return false;
}

reset
{

}