﻿namespace Basket.API.Basket.GetBasket;

// public record GetBasketRequest(string UserName);

public record GetBasketResponse(ShoppingCart Cart);


public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baskets/{username}",
            async (string username, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(username));

                var response = result.Adapt<GetBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("GetBasket")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("GetBasket")
            .WithDescription("GetBasket");
    }
}