using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class TestsView
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int TestId { get; set; }

    public int TestQuestionId { get; set; }

    public string Question { get; set; } = null!;

    public int CharacteristicId { get; set; }

    public int TestAnswerId { get; set; }

    public string Answer { get; set; } = null!;

    public decimal Mark { get; set; }
}
