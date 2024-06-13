using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class UsersResult
{
    public int UserResultId { get; set; }

    public int UserId { get; set; }

    public int CharacteristicId { get; set; }

    public int Rating { get; set; }

    public virtual Characteristic Characteristic { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
