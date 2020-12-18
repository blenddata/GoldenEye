using System;
using Backend.DDD.Sample.Contracts.Issues;
using GoldenEye.Core.Entity;
using GoldenEye.Core.Objects.General;

namespace Backend.DDD.Sample.Issues
{
    internal class Issue: IEntity
    {
        public Issue()
        {
        }

        public Issue(Guid id, IssueType type, string title)
        {
            Id = id;
            Type = type;
            Title = title;
        }

        public Guid Id { get; set; }

        public IssueType Type { get; set; }

        public string Title { get; set;  }

        public string Description { get; set; }
        object IHaveId.Id => Id;
    }
}