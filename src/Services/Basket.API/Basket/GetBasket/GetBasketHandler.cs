﻿
namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCart Cart);

public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public GetBasketHandler()
    {
        
    }
    
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        return new GetBasketResult(new ShoppingCart("Test"));
;    }
}