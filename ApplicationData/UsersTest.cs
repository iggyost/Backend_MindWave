using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class UsersTest
{
    public int UserTestId { get; set; }

    public int UserId { get; set; }

    public int TestId { get; set; }

    public virtual Test Test { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
