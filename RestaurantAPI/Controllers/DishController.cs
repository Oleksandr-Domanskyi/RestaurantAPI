﻿using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("swagger/restaurant/{restaurantId}/dish")]
    [ApiController]

    public class DishController  : ControllerBase
    {
        private readonly IDishService _dishService;
        public DishController(IDishService dishService) 
        {
            _dishService = dishService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute]int restaurantId,[FromBody] CreateDishDto dto)
        {
           var newDishId = _dishService.Create(restaurantId, dto);

            return Created($"api/{restaurantId}/dish/{newDishId}",null);
        }

    }
}