﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper,ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderUpdate == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }
            _mapper.Map(request,orderUpdate,typeof(UpdateOrderCommand),typeof(Order));
            await _orderRepository.UpdateAsync(_mapper.Map<Order>(request));
            _logger.LogInformation($"Order {orderUpdate.Id} is successfully updated.");
            return Unit.Value;
        }
    }
}
