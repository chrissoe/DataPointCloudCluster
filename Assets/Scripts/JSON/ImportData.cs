using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ImportData
{
    public int time { get; set; }

    [JsonProperty("time-content")]
    public TimeContent[] timecontent { get; set; }
}

public class TimeContent
{
    public int subtime { get; set; }
    [JsonProperty("subtime-content")]
    public SubtimeContent[] subtimecontent { get; set; }
}

public class SubtimeContent
{
    public string value1 { get; set; }
    public Content[] value2 { get; set; }
}

public class Content
{
    public string contentvalue1 { get; set; }
    public float contentvalue2 { get; set; }
    public float contentvalue3 { get; set; }
}



