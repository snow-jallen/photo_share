﻿namespace Photos.Shared.Models;

public class Photo
{
    public long Id { get; set; }
    public string? Path { get; set; }
    public DateTime Taken { get; set; }
}
