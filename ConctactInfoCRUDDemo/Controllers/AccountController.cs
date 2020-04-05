using AutoMapper;
using ConctactInfoCRUDDemo.Models;
using ContactInfo.BL.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConctactInfoCRUDDemo.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountBL _accountBL;
        public AccountController(IAccountBL accountBL)
        {
            _accountBL = accountBL;
        }

        [HttpPost]
        public LoginResponse SignUp([FromBody]UserDetailsModel userDetailsModel)
        {
            try
            {
                LoginResponse loginResponse = new LoginResponse();

                if (!ModelState.IsValid) {
                    loginResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                    loginResponse.Message = "Invalid data";
                    return loginResponse;
                }

                bool isUserNameExists = ValidateUserName(userDetailsModel.UserName);
                if(isUserNameExists)
                {
                    loginResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                    loginResponse.Message = "User name already exists";
                    return loginResponse;
                }

                bool isEmailExists = ValidateEmail(userDetailsModel.Email);
                if (isEmailExists)
                {
                    loginResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                    loginResponse.Message = "Email already exists";
                    return loginResponse;
                }

                var userDetails = Mapper.Map<UserDetailsModel, ContactInfo.DBEntities.Entities.UserDetail>(userDetailsModel);

                int id = _accountBL.SignUp(userDetails);

                if (id > 0)
                {
                    userDetailsModel.Id = id;
                    loginResponse.Data = userDetailsModel;
                    loginResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    loginResponse.Message = "Added successfully";
                }

                else
                {
                    loginResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    loginResponse.Message = "Error while adding";
                }

                return loginResponse;
            }
            catch (Exception ex)
            {
                LoginResponse loginResponse = new LoginResponse();
                loginResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                loginResponse.Message = "Error while adding";

                return loginResponse;
            }

        }

        private bool ValidateEmail(string email)
        {
            return _accountBL.GetAllUserDetails().Any(u => u.Email.ToLower() == email.ToLower());
        }

        private bool ValidateUserName(string userName)
        {
            return _accountBL.GetAllUserDetails().Any(u => u.UserName.ToLower() == userName.ToLower());
        }

        public LoginResponse SignIn([FromBody] UserDetailsModel userDetailsModel)
        {
            try
            {
                LoginResponse loginResponse = new LoginResponse();

                if (string.IsNullOrEmpty(userDetailsModel.UserName) || string.IsNullOrEmpty(userDetailsModel.Password))
                {
                    loginResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                    loginResponse.Message = "Username or Password can not be empty";
                    return loginResponse;
                }

                var userDetails = Mapper.Map<UserDetailsModel, ContactInfo.DBEntities.Entities.UserDetail>(userDetailsModel);

                bool status = _accountBL.SignIn(userDetails);

                if(status)
                {
                    loginResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    loginResponse.Message = "User logged in successfully";
                    return loginResponse;
                }
                else
                {
                    loginResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                    loginResponse.Message = "Invalid username or password";
                    return loginResponse;
                }

            }
            catch (Exception ex)
            {
                LoginResponse loginResponse = new LoginResponse();
                loginResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                loginResponse.Message = "Error while fetching data";

                return loginResponse;
            }
        }
    }
}
