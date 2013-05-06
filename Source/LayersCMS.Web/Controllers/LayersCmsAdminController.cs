using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AttributeRouting;
using LayersCMS.Data.Domain.Core.Security;
using LayersCMS.Data.Persistence.Interfaces.Reads;

namespace LayersCMS.Web.Controllers
{
    [RouteArea("Admin", AreaUrl = "admin"), Authorize]
    public abstract class LayersCmsAdminController : Controller
    {
        private readonly ILayersCmsUserReads _userReads;

        protected LayersCmsAdminController(ILayersCmsUserReads userReads)
        {
            _userReads = userReads;
        }

        private LayersCmsUser _loggedInUser;
        public virtual LayersCmsUser LoggedInUser { 
            get
            {
                if (_loggedInUser == null && User != null)
                {
                    _loggedInUser = _userReads.GetByEmailAddress(User.Identity.Name);   
                }
                return _loggedInUser;
            }
        }

        #region Helper Methods

        /// <summary>
        /// Takes a date field and a time string (e.g. 04:52:00) and merges them together to a valid DateTime value
        /// </summary>
        /// <param name="date">A nullable DateTime value to take the date part from</param>
        /// <param name="time">A time string (e.g. 04:52:00)</param>
        public DateTime? MergeDateAndTime(DateTime? date, String time)
        {
            if (date.HasValue)
            {
                if (!String.IsNullOrWhiteSpace(time) && time.Contains(":"))
                {
                    try
                    {
                        IEnumerable<int> timeParts = time.Split(':').Select(int.Parse).ToArray();
                        date = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day,
                                            timeParts.ElementAtOrDefault(0),
                                            timeParts.ElementAtOrDefault(1),
                                            timeParts.ElementAtOrDefault(2));
                    }
                    catch (Exception)
                    {
                        return date;
                    }
                }
                return date;
            }
            return null;
        }

        #endregion

    }
}
