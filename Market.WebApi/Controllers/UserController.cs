using Market.Application.Users.Commands.CreateUser;
using Market.Application.Users.Commands.DeleteUser;
using Market.Application.Users.Queries.GetUserDetails;
using Market.Application.Users.Queries.GetUserList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Market.Application.Users.Commands.AuthorizationUser;
using Market.Application.Users.Commands.RefreshToken;
using Market.Application.Users.Commands.RevokeRefreshToken;

namespace Market.WebApi.Controllers
{
    public class UserController : BaseController
    {
        /// <summary>
        /// Get the list of users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /User
        /// </remarks>
        /// <returns>Return UserListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var query = new GetUserListQuery();

            var vm = await Mediator.Send(query);
            
            return Ok(vm);
        }

        /// <summary>
        /// Get the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /User/B091E327-02F7-4EC8-A140-AA0052CF8565
        /// </remarks>
        /// <param name="id">User id (guid)</param>
        /// <returns>Return UserDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDetailsVm>> GetById(Guid id)
        {
            var query = new GetUserDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <remarks>
        /// POST /User/Refresh
        /// eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiZQWhTUrMZE
        /// </remarks>
        /// <param name="command">RefreshTokenCommand object</param>
        /// <returns>Access Token</returns>
        [HttpPost("Refresh")]
        public async Task<ActionResult<string>> RefreshToken(
            [FromBody] RefreshTokenCommand command
            )
        {
            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        /// <summary>
        /// Refresh token revoke
        /// </summary>
        /// <remarks>
        /// POST /User/Revoke
        /// {
        ///     "RefreshToken":"TGZKoIXM2kizt58WJYotSrP/hnqhz2vV"
        /// }
        /// </remarks>
        /// <param name="command">RevokeRefreshTokenCommand object</param>
        /// <returns></returns>
        [HttpPost("Revoke")]
        public async Task<ActionResult> RevokeRefreshToken(
            [FromBody] RevokeRefreshTokenCommand command)
        {
            await Mediator.Send(command);

            return Ok("Refresh token is revoked");
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /User/SignOut
        /// {
        ///     "username":"name",
        ///     "email":"sample.1@test.com"
        ///     "password":"12345"
        /// }
        /// </remarks>
        /// <param name="command">CreateUserCommad object</param>
        /// <returns>
        /// {
        ///     "token": "B091E327-02F7-4EC8-A140-AA0052CF8565",
        ///     "userId": "C257F261-02J7-4KC8-A140-BD4242NB8565"
        /// }   
        /// </returns>
        /// <response code="200">Success</response>
        [HttpPost("SignOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TokenUserVm>> Registration(
            [FromBody] CreateUserCommand command)
        {
            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        /// <summary>
        /// Authorization
        /// </summary>
        /// <remarks>
        /// POST /User/SignIn
        /// {
        ///     "email":"sample.1@test.com"
        ///     "password":"12345"
        /// }
        /// </remarks>
        /// <param name="command">AuthorizationUserCommand object</param>
        /// <returns>
        /// {
        ///     "token": "B091E327-02F7-4EC8-A140-AA0052CF8565",
        ///     "userId": "C257F261-02J7-4KC8-A140-BD4242NB8565"
        /// }  
        /// </returns>
        /// <response code="200">Success</response>
        [HttpPost("SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TokenUserVm>> Authorization(AuthorizationUserCommand command)
        {
            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        /// <summary>
        /// Delete the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /User
        /// </remarks>
        /// <returns>Returns NoContend</returns>
        /// 
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteById()
        {
            var command = new DeleteUserCommand
            {
                Id = UserId
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
