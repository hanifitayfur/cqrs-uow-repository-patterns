using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sample.Application.Interfaces;
using Sample.Application.Response;

namespace Sample.Application.Commands.SignIn
{
    public class SignInSmsCodeCommandHandler : IRequestHandler<SignInSmsCodeCommand, ServiceResponse<SignInUserCommandResult>>
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public SignInSmsCodeCommandHandler(IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public Task<ServiceResponse<SignInUserCommandResult>> Handle(SignInSmsCodeCommand request, CancellationToken cancellationToken)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddMinutes(int.Parse(_configuration["JwtExpiryInMinute"]));
           
            
           // User user = _userRepository.Table.Where(x => x.MobilePhoneNumber.Equals(request.MobilePhoneNumber)).Include()
            
            throw new System.NotImplementedException();
        }
    }
}