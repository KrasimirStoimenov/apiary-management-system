﻿namespace ApiaryManagementSystem.Domain.Models;

public sealed class ModelConstants
{
    public class Common
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 20;
    }

    public class Apiary
    {
        public const int LocationMinLength = 1;
        public const int LocationMaxLength = 50;
    }
}
