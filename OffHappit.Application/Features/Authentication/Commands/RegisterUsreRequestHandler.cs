using AutoMapper;
using MediatR;
using OffHappit.Application.Contracts;
using OffHappit.Application.Services;
using OffHappit.Domain.Entities;
using OffHappit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Features.Authentication.Commands;

public class RegisterUsreRequestHandler : IRequestHandler<RegisterUserRequest, Guid>
{
    private readonly IAsyncRepository<UserCredentials> _authRepository;
    private readonly IAsyncRepository<UserProfile> _profileRepository;
    private readonly IAuthServices _authServices;
    private readonly IMapper _mapper;
    public async Task<Guid> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        //Validate all the user inputs
        var RegisterUserValidation = new RegisterUserValidator();
        var validationResult = RegisterUserValidation.Validate(request);

        //If the validation fails, throw an exception and include the errors messages
        if (validationResult.Errors.Count > 0)
            throw new Exceptions.ValidationException(validationResult);

        //Create a user Profile Entity
        var userProfileEntity = _mapper.Map<UserProfile>(request);

        //Add the user profile to the database to get the user Id
        await _profileRepository.AddAsync(userProfileEntity);
        
        var salt = _authServices.CreateSalt();

        var userAuthEntity = new UserCredentials
        {
            UserId = userProfileEntity.UserId,
            Email = request.Email,
            HashedPassword = _authServices.HashPassword(request.Password, salt),
            PasswordSalt = salt
        };

        await _authRepository.AddAsync(userAuthEntity);

        return userProfileEntity.UserId;
    }
}
