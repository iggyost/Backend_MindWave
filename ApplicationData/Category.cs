using System;
using System.Collections.Generic;

namespace Backend_MindWave.ApplicationData;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
