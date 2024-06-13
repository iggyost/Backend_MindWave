using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class Characteristic
{
    public int CharacteristicId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TestsQuestion> TestsQuestions { get; set; } = new List<TestsQuestion>();

    public virtual ICollection<UsersResult> UsersResults { get; set; } = new List<UsersResult>();
}
