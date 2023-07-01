using System;
using ImageStreaming.Shared.Persistence.Entities;
using ImageStreaming.Shared.Persistence.Common.Interfaces.Services;
using AutoMapper;
using ImageStreaming.Shared.Persistence.Common.Interfaces.Repositories;

namespace ImageStreaming.Shared.Persistence.Services
{
	public class BaseService<TEntity> : IBaseService<TEntity>
		where TEntity : BaseEntity
	{
        protected readonly IMapper _mapper;
		protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(IMapper mapper, IBaseRepository<TEntity> repository)
		{
			_mapper = mapper;
			_repository = repository;
		}
	}
}

