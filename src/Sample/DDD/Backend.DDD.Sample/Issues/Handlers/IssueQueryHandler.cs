using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.DDD.Sample.Contracts.Issues.Queries;
using GoldenEye.Backend.Core.DDD.Queries;
using GoldenEye.Backend.Core.Repositories;
using Marten;
using IssueViews = Backend.DDD.Sample.Contracts.Issues.Views;

namespace Backend.DDD.Sample.Issues.Handlers
{
    internal class IssueQueryHandler:
        IQueryHandler<GetIssues, IReadOnlyList<IssueViews.IssueView>>,
        IQueryHandler<GetIssue, IssueViews.IssueView>
    {
        private readonly IReadonlyRepository<Issue> repository;
        private readonly IConfigurationProvider configurationProvider;
        private readonly IMapper mapper;

        public IssueQueryHandler(
            IReadonlyRepository<Issue> repository,
            IConfigurationProvider configurationProvider,
            IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentException(nameof(repository));
            this.configurationProvider = configurationProvider ?? throw new ArgumentException(nameof(configurationProvider));
            this.mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public Task<IReadOnlyList<IssueViews.IssueView>> Handle(GetIssues message, CancellationToken cancellationToken)
        {
            return repository
                .Query()
                .ProjectTo<IssueViews.IssueView>(configurationProvider)
                .ToListAsync();
        }

        public async Task<IssueViews.IssueView> Handle(GetIssue message, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(message.Id);

            return mapper.Map<IssueViews.IssueView>(entity);
        }
    }
}
