using System.Collections.Generic;

public class TopData
{
    public string Name;
    public int Score;
    public string Time;

    public TopData()
    {
    }

    public TopData(string name, int score, string time)
    {
        Name = name;
        Score = score;
        Time = time;
    }
}

public class TopListData
{
    public List<TopData> List;
}
