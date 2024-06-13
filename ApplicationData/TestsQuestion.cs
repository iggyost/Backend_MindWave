using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class TestsQuestion
{
    public int TestQuestionId { get; set; }

    public int TestId { get; set; }

    public string Question { get; set; } = null!;

    public int CharacteristicId { get; set; }

    public virtual Characteristic Characteristic { get; set; } = null!;

    public virtual Test Test { get; set; } = null!;

    public virtual ICollection<TestsAnswer> TestsAnswers { get; set; } = new List<TestsAnswer>();
}
