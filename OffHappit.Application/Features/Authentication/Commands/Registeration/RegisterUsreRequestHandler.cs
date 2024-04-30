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

namespace OffHappit.Application.Features.Authentication.Commands.Registeration;

public class RegisterUsreRequestHandler : IRequestHandler<RegisterUserRequest, Guid>
{
    private readonly IAsyncRepository<UserCredentials> _authRepository;
    private readonly IAsyncRepository<UserProfile> _profileRepository;
    private readonly IAuthServices _authServices;
    private readonly IMapper _mapper;

    public RegisterUsreRequestHandler(IAsyncRepository<UserCredentials> authRepository, IAsyncRepository<UserProfile> profileRepository, IAuthServices authServices, IMapper mapper)
    {
        _authRepository = authRepository;
        _profileRepository = profileRepository;
        _authServices = authServices;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        //Validate all the user inputs
        var RegisterUserValidation = new RegisterUserValidator();
        var validationResult = await RegisterUserValidation.ValidateAsync(request);

        //If the validation fails, throw an exception and include the errors messages
        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        //Create a user Profile Entity
        var userProfile = _mapper.Map<UserProfile>(request);

        //Add the user profile to the database to get the user Id
        var userProfileEntity = await _profileRepository.AddAsync(userProfile);

        var salt = _authServices.CreateSalt();

        var userAuthEntity = new UserCredentials
        {
            UserId = userProfileEntity.UserId,
            Email = request.Email,
            PasswordSalt = salt,
            HashedPassword = _authServices.HashPassword(request.Password, salt)
        };

        await _authRepository.AddAsync(userAuthEntity);

        return userProfileEntity.UserId;
    }
}
