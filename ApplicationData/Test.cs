using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class Test
{
    public int TestId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string CoverImage { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<TestsQuestion> TestsQuestions { get; set; } = new List<TestsQuestion>();

    public virtual ICollection<UsersTest> UsersTests { get; set; } = new List<UsersTest>();
}
