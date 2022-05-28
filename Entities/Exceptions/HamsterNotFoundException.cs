﻿namespace Entities.Exceptions;

public class HamsterNotFoundException : NotFoundException
{
    public HamsterNotFoundException(int hamsterId)
        : base($"The hamster with id: {hamsterId} does not exist in the database.")
    {
    }
}
