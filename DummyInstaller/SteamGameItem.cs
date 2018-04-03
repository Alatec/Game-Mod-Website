using System;

public class SteamGameItem
{
    public String gamePath;
    public bool isDefault = false;
	public SteamGameItem(String gamePath)
	{
        this.gamePath = gamePath;
	}

    public SteamGameItem()
    {
        gamePath = "\\My Game is not listed";
        isDefault = true;
    }

    public override string ToString()
    {
        return gamePath.Split('\\')[gamePath.Split('\\').Length -1];
    }
}
