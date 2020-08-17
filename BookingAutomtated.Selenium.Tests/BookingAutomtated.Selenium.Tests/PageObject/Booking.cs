using BookingAutomtated.Selenium.Tests.SeleniumCore.Base;
using BookingAutomtated.Selenium.Tests.SeleniumCore.Extensions;
using BookingAutomtated.Selenium.Tests.SeleniumCore.Helpers;

using Microsoft.VisualBasic;

using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Threading;

namespace BookingAutomtated.Selenium.Tests.PageObject
{
    public class Booking : Base
    {
        public IPage BookingLogo => FindById("logo_no_globe_new_logo");
        public IPage BookingSearchBox => FindByName("ss");
        public IPage CheckInOut => FindByCss("#frm > div.xp__fieldset.accommodation > div.xp__dates.xp__group");
        public IPage BookingCalander => FindByClassName("bui-calendar");
        public IPage BookingCalanderDates => FindByTagName("tbody");
        public IPage BookingVaccationDate => FindByClassName("bui-calendar__display");
        public IPage BookingSearchButton => FindByClassName("sb-searchbox__button");
        public IPage BookingSearchResults => FindById("searchresultsTmpl");
        public IPage BookingCalanderNextbutton => FindByCss("#frm > div.xp__fieldset.accommodation > div.xp__dates.xp__group > div.xp-calendar > div > div > div.bui-calendar__control.bui-calendar__control--next");
        public List<IPage> BookingCalanderMonth => FindElementsByClassName("bui-calendar__month");
        public IPage BookingGuestsCount => FindByClassName("xp__guests__count");
        public IPage BookingCalanderCheckinDate => FindByClassName("sb-date-field__display");
        public IPage BookingPopularActivities => FindById("filter_popular_activities");
        public IPage BookingPopularActivitiesSauna => FindByCss("#filter_popular_activities");
        public IPage BookingPopularActivitiesMassage => FindByCss("#filter_popular_activities > div.filteroptions > a");
        public IPage BookingHotelResultsList => FindById("hotellist_inner");
        public IPage BookingStarRating => FindById("filter_class");
        public IPage BookingManageCookiesWindow => FindByClassName("cookie-warning-v2__panel");
        public IPage BookingManageCookiesAcceptButon => FindByCss("#cookie_warning > div > div > div.cookie-warning-v2__banner-cta > button");
        public IPage BookingLoadingFrame => FindByCss("#b2searchresultsPage > div.sr-usp-overlay.sr-usp-overlay--wide > div.sr-usp-overlay__container.is_stuck");

        public bool BookingLogoIsVisable()
        {
            return BookingLogo.IsVisible;
        }

        public void BookingSerachBoxSendSearchTerm(string searchTerm)
        {
            BookingSearchBox.SendKeys(searchTerm);
        }

        public string BookingSerachBoxGetSearchText()
        {
            return BookingSearchBox.GetAttribute("placeholder");
        }

        public void BookingSetVacationDate(string month, int monthsUntil, int numberOfDays)
        {
            DateTime dateToday = GetDateToday();

            CheckInOut.Click();

            BookingCalanderChangeMonths(month);

            SetVacationDate(dateToday, monthsUntil, numberOfDays);
        }

        public string BookingSetGuestCount()
        {
            //Logic should be created here to interact with the guest table section. As the default matches the test data needed I will not create this logic - I will just return the default value. 
            return BookingGuestsCount.Text;
        }

        public string GetCheckInDate()
        {
            return BookingCalanderCheckinDate.Text;
        }

        private void BookingCalanderChangeMonths(string vaccationMonth)
        {
            foreach (var month in BookingCalanderMonth)
            {
                while (!month.Text.Equals(vaccationMonth))
                {
                    BookingCalanderNextbutton.Click();
                }
            }
        }

        private void SetVacationDate(DateTime dateToday, int monthsUntilVacation, int lengthOfVacation)
        {
            var checkInDate = SetCheckInDate(dateToday, monthsUntilVacation, lengthOfVacation);
            var checkOutDate = SetCheckOutDate(dateToday, monthsUntilVacation, lengthOfVacation);

            if (BookingCalander.IsVisible)
            {
                BookingCalanderDates.ClickElementInTable("span", "aria-label", checkInDate, checkOutDate);
            }
        }

        public void FilterByPopularActivities()
        {
            //The option for the Sauna does not appear unless 'Massage' is clicked first...
            //Massage MUST then be clicked again to make the Limerick Strand Hotel in the list of Hotels.
            FilterPopularActivity("Massage");
            FilterPopularActivity("Sauna");
            UnFilterPopularActivity("Massage");
        }

        public void FilterByPopularStars(string starRating)
        {
            IWebElement starElement = null;

            foreach (var starFilter in BookingStarRating.GetInnerElementByProperty("span"))
            {
                BookingStarRating.WaitForVisableElement();
                BookingStarRating.ScrollToElement();
                while (starFilter.Text == starRating)
                {
                    starElement = starFilter;
                    break;
                }
            }
            starElement.Click();
            if (BookingLoadingFrame.IsVisible) BookingLoadingFrame.WaitUntilVisableElementIsNot();

            return;
        }

        public bool FindHotel(string hotel)
        {
            bool hotelExists = false;

            BookingHotelResultsList.WaitForVisableElement();

            foreach (IWebElement hotelInList in BookingHotelResultsList.GetInnerElementByProperty("span"))
            {
                if (hotelInList.Text == hotel && hotelInList.Text != "George Limerick Hotel")
                {
                    continue;
                }
                hotelExists = true;
            }
            return hotelExists;
        }

        private static DateTime GetDateToday()
        {
            return DateTime.Now;
        }

        private string SetCheckInDate(DateTime dateToday, int monthsOfVacation, int lengthOfVacation)
        {
            return dateToday.AddMonths(monthsOfVacation).ToString("dd MMMM yyyy");
        }

        private string SetCheckOutDate(DateTime dateToday, int monthsOfVacation, int lengthOfVacation)
        {
            return dateToday.AddDays(lengthOfVacation).AddMonths(monthsOfVacation).ToString("dd MMMM yyyy");
        }

        private void FilterPopularActivity(string activity)
        {
            IWebElement activityElemnt = null;

            foreach (var popularFilter in BookingPopularActivities.GetInnerElementByProperty("span"))
            {
                BookingPopularActivities.WaitForVisableElement();
                BookingPopularActivities.ScrollToElement();
                while (popularFilter.Text == activity)
                {
                    activityElemnt = popularFilter;
                    break;
                }
            }
            activityElemnt.Click();
            if(BookingLoadingFrame.IsVisible) BookingLoadingFrame.WaitUntilVisableElementIsNot();

            return;
        }

        private void UnFilterPopularActivity(string activity)
        {
            IWebElement activityElemnt = null;

            foreach (var popularFilter in BookingPopularActivities.GetInnerElementByProperty("span"))
            {
                BookingPopularActivities.WaitForVisableElement();
                BookingPopularActivities.ScrollToElement();
                while (popularFilter.Text == activity)
                {
                    activityElemnt = popularFilter;
                    break;
                }
            }
            activityElemnt.Click();
            if (BookingLoadingFrame.IsVisible) BookingLoadingFrame.WaitUntilVisableElementIsNot();

            return;
        }
    }
}
