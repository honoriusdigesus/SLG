using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public class TokenMapper
    {
        //From TokenReq to Token
        public Login ToEntity(TokenReq tokenReq)
        {
            return new Domain.Entities.Login
            {
                Token = tokenReq.Token1,
                Expires = tokenReq.Expires,
                Created = tokenReq.Created,
                Revoked = tokenReq.Revoked,
                EmployeeId = tokenReq.EmployeeId
            };
        }

        //From Token to TokenRes
        public TokenRes ToResponse(Login login)
        {
            return new TokenRes
            {
                TokenId = login.TokenId,
                Token1 = login.Token,
                Expires = login.Expires,
                Created = login.Created,
                Revoked = login.Revoked,
                EmployeeId = login.EmployeeId
            };
        }
    }
}
