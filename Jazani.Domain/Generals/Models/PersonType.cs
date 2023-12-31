﻿using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Generals.Models;
public class PersonType: CoreModel<int>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}
