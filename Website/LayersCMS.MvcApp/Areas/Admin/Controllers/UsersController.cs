using System;
using System.Web.Security;
using AttributeRouting.Web.Mvc;
using LayersCMS.Data.Domain.Core.Security;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Data.Persistence.Interfaces.Writes;
using LayersCMS.MvcApp.Areas.Admin.Controllers.Base;
using System.Web.Mvc;
using LayersCMS.MvcApp.Areas.Admin.Models.Users;
using LayersCMS.Util.Security.Interfaces;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class UsersController : LayersCmsAdminController
    {
        #region Constructor and Dependencies

        private readonly ILayersCmsUserReads _userReads;
        private readonly ILayersCmsUserWrites _userWrites;
        private readonly IHashHelper _hashHelper;

        public UsersController(ILayersCmsUserReads userReads, 
                                ILayersCmsUserWrites userWrites,
                                IHashHelper hashHelper)
                                : base(userReads)
        {
            _userReads = userReads;
            _userWrites = userWrites;
            _hashHelper = hashHelper;
        }

        #endregion


        [GET("users")]
        public ActionResult List()
        {
            return View(_userReads.GetAll());
        }

        [GET("users/add")]
        public ActionResult Add()
        {
            return View();
        }

        [POST("users/add")]
        public ActionResult Add(AddUserModel model)
        {
            // Validate the model
            if (ModelState.IsValid)
            {
                // Check that another user doesn't already exist with the same password
                if (_userReads.GetByEmailAddress(model.EmailAddress) != null)
                {
                    ModelState.AddModelError("EmailAddress", "A user already exists with that email address");   
                }
                else
                {
                    // All validation passed, can add the user
                    _userWrites.Insert(new LayersCmsUser()
                        {
                            Active = true,
                            EmailAddress = model.EmailAddress,
                            Password = _hashHelper.HashString(model.Password)
                        });

                    // User added successfully
                    return RedirectToAction("List");
                }
            }

            // Validation failed, show the view again
            return View(model);
        }

        [GET("users/edit/{id}")]
        public ActionResult Edit(int id)
        {
            // Redirect to the current user edit action if the 
            // id matches that of the logged in user
            if (id == LoggedInUser.Id)
            {
                return RedirectToAction("EditCurrentUser");
            }

            // Retrieve the user to edit from the database
            LayersCmsUser user = _userReads.GetById(id);

            // If the user doesn't exist redirect to the list action
            if (user == null)
                return RedirectToAction("List");

            // Return the view pre-populated with the user data
            var model = new EditUserModel()
                {
                    Active = user.Active,
                    EmailAddress = user.EmailAddress,
                    Id = user.Id
                };

            return View(model);
        }

        [POST("users/edit/{id}")]
        public ActionResult Edit(int id, EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user to edit from the database
                LayersCmsUser editUser = _userReads.GetById(id);

                // Update the 'active' status for the user
                editUser.Active = model.Active;

                // If the email address has changed, check it's not already in use
                if (model.EmailAddress != editUser.EmailAddress)
                {
                    // Search the database for a different user with the new email address
                    LayersCmsUser otherUserMatchingEmailAddress = _userReads.GetByEmailAddress(model.EmailAddress, id);

                    // If no match has been found, update the email address, otherwise show an error
                    if (otherUserMatchingEmailAddress == null)
                    {
                        editUser.EmailAddress = model.EmailAddress;
                    }
                    else
                    {
                        ModelState.AddModelError("EmailAddress", "This email address is already used by another user");
                    }
                }

                // Check if the custom validation has been passed
                if (ModelState.IsValid)
                {
                    // Set the new password if one has been entered
                    if (model.BothPasswordsEntered)
                    {
                        editUser.Password = _hashHelper.HashString(model.Password);
                    }

                    // Save the changes to the user to the database
                    _userWrites.Update(editUser);

                    // Return to the list of users
                    return RedirectToAction("List");   
                }
            }

            // Validation failed, display the view again
            return View(model);
        }

        [GET("users/me")]
        public ActionResult EditCurrentUser()
        {
            var model = new CurrentUserModel()
                {
                    EmailAddress = LoggedInUser.EmailAddress
                };
            return View(model);
        }

        [POST("users/me")]
        public ActionResult EditCurrentUser(CurrentUserModel model)
        {
            if (ModelState.IsValid)
            {
                bool emailAddressChanged = false;

                // The user to edit is the logged in user
                LayersCmsUser editUser = LoggedInUser;

                // If the email address has changed, check it's not already in use
                if (model.EmailAddress != editUser.EmailAddress)
                {
                    // Search the database for a different user with the new email address
                    LayersCmsUser otherUserMatchingEmailAddress = _userReads.GetByEmailAddress(model.EmailAddress, editUser.Id);

                    // If no match has been found, update the email address, otherwise show an error
                    if (otherUserMatchingEmailAddress == null)
                    {
                        editUser.EmailAddress = model.EmailAddress;
                        emailAddressChanged = true;
                    }
                    else
                    {
                        ModelState.AddModelError("EmailAddress", "This email address is already used by another user");
                    }
                }

                // Check if the custom validation has been passed
                if (ModelState.IsValid)
                {
                    // Set the new password if one has been entered
                    if (model.BothPasswordsEntered)
                    {
                        editUser.Password = _hashHelper.HashString(model.Password);
                    }

                    // Save the changes to the user to the database
                    _userWrites.Update(editUser);

                    // If the email address for the current user has changed, the User.Identity.Name must change also,
                    // so the forms authentication cookie must be updated
                    if (emailAddressChanged)
                    {
                        FormsAuthentication.SetAuthCookie(editUser.EmailAddress, false);
                    }

                    // Return to the list of users
                    return RedirectToAction("List");
                }
            }

            // Validation failed, display the view again
            return View(model);
        }


    }
}
