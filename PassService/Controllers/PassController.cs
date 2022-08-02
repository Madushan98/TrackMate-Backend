using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PassService.Services;

namespace PassService.Controllers;

[ApiController]
public class PassController
{
    private readonly IMapper _mapper;
    private readonly IPassServices _service;

    public PassController(IPassServices service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
}