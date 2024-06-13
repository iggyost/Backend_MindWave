using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class User
{
    public int UserId { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<UsersResult> UsersResults { get; set; } = new List<UsersResult>();

    public virtual ICollection<UsersTest> UsersTests { get; set; } = new List<UsersTest>();
}
