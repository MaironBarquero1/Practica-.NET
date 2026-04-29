using System;
using Microsoft.VisualBasic;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto.user;
using StoreBackend.Exceptions;
using StoreBackend.Infrastructure.Repositories.user;

namespace StoreBackend.DomainService.user;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<List<User>> GetAllAsync()
    {
        return _userRepository.GetAllAsync();
    }
    public Task<User?> GetByIdAsync(Guid userId)
    {
        return _userRepository.GetByIdAsync(userId);
    }
    public async Task<User> AddAsync(CreateUserDto user)
    {
        if(await _userRepository.HasUserByUsernameAsync(user.Username))
        {
            throw new Exceptions.BadRequestResponseException("Username ir already taken");
        }
        if(await _userRepository.HasUserByEmailAsync(user.Email))
        {
            throw new Exceptions.BadRequestResponseException("Email is already taken");
        }

        var entity = new User
        {
            ExternalId = Guid.NewGuid(),
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
            Passwordhash = BCrypt.Net.BCrypt.HashPassword(user.Password) 
        };
        return await _userRepository.AddAsync(entity);
    }
    public async Task DeleteAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if(user == null) throw new ResourceNotFoundException();
        await _userRepository.DeleteAsync(user);
    }
}
