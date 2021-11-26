﻿namespace LitExplore.Repository.Entities;

public class Relation
{
    public Paper From { get; set; } = null!;
    public Paper To { get; set; } = null!;
}

public record RelationDTO(Paper from, Paper to);
