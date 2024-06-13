using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class TestsAnswer
{
    public int TestAnswerId { get; set; }

    public int TestQuestionId { get; set; }

    public string Answer { get; set; } = null!;

    public decimal Mark { get; set; }

    public virtual TestsQuestion TestQuestion { get; set; } = null!;
}
