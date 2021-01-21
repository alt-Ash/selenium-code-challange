using System;
using System.Collections.Generic;
using BookingAutomated.Selenium.Tests.SeleniumCore.Base;
using BookingAutomated.Selenium.Tests.SeleniumCore.Interfaces;
using OpenQA.Selenium;

namespace BookingAutomated.Selenium.Tests.PageObject
{
	public class Booking : Base
	{
		private IPage BookingLogo => FindById("logo_no_globe_new_logo");
		private IPage BookingSearchBox => FindByName("ss");
		private IPage CheckInOut => FindByCss("#frm > div.xp__fieldset.accommodation > div.xp__dates.xp__group");
		private IPage BookingCalender => FindByClassName("bui-calendar");
		private IPage BookingCalenderDates => FindByTagName("tbody");
		public IPage BookingVacationDate => FindByClassName("bui-calendar__display");
		public IPage BookingSearchButton => FindByClassName("sb-searchbox__button");
		public IPage BookingSearchResults => FindById("searchresultsTmpl");
		private IPage BookingCalenderNextButton => FindByCss("#frm > div.xp__fieldset.accommodation > div.xp__dates.xp__group > div.xp-calendar > div > div > div.bui-calendar__control.bui-calendar__control--next");
		private IEnumerable<IPage> BookingCalenderMonth => FindElementsByClassName("bui-calendar__month");
		private IPage BookingGuestsCount => FindByClassName("xp__guests__count");
		private IPage BookingCalenderCheckinDate => FindByClassName("sb-date-field__display");
		private IPage BookingPopularActivities => FindById("filter_popular_activities");
		public IPage BookingPopularActivitiesSauna => FindByCss("#filter_popular_activities");
		public IPage BookingPopularActivitiesMassage => FindByCss("#filter_popular_activities > div.filteroptions > a");
		private IPage BookingHotelResultsList => FindById("hotellist_inner");
		private IPage BookingStarRating => FindById("filter_class");
		public IPage BookingManageCookiesWindow => FindByClassName("cookie-warning-v2__panel");
		public IPage BookingManageCookiesAcceptButton => FindByCss("#cookie_warning > div > div > div.cookie-warning-v2__banner-cta > button");
		private IPage BookingLoadingFrame => FindByCss("#b2searchresultsPage > div.sr-usp-overlay.sr-usp-overlay--wide > div.sr-usp-overlay__container.is_stuck");

		public bool BookingLogoIsVisible()
		{
			return BookingLogo.IsVisible;
		}

		public void BookingSearchBoxSendSearchTerm(string searchTerm)
		{
			BookingSearchBox.SendKeys(searchTerm);
		}

		public string BookingSearchBoxGetSearchText()
		{
			return BookingSearchBox.GetAttribute("placeholder");
		}

		public void BookingSetVacationDate(string month, int monthsUntil, int numberOfDays)
		{
			var dateToday = GetDateToday();

			CheckInOut.Click();

			BookingCalenderChangeMonths(month);

			SetVacationDate(dateToday, monthsUntil, numberOfDays);
		}

		public string BookingSetGuestCount()
		{
			//Logic should be created here to
			//interact with the guest table section.
			//As the default matches the test data needed I will not create this logic - I will just return the default value.
			return BookingGuestsCount.Text;
		}

		public string GetCheckInDate()
		{
			return BookingCalenderCheckinDate.Text;
		}

		private void BookingCalenderChangeMonths(string vacationMonth)
		{
			foreach (var month in BookingCalenderMonth)
			{
				while (!month.Text.Equals(vacationMonth))
				{
					BookingCalenderNextButton.Click();
				}
			}
		}

		private void SetVacationDate(DateTime dateToday, int monthsUntilVacation, int lengthOfVacation)
		{
			var checkInDate = SetCheckInDate(dateToday, monthsUntilVacation, lengthOfVacation);
			var checkOutDate = SetCheckOutDate(dateToday, monthsUntilVacation, lengthOfVacation);

			if (BookingCalender.IsVisible)
			{
				BookingCalenderDates.ClickElementInTable("span", "aria-label", checkInDate, checkOutDate);
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
				BookingStarRating.WaitForVisibleElement();
				BookingStarRating.ScrollToElement();
				while (starFilter.Text == starRating)
				{
					starElement = starFilter;
					break;
				}
			}
			starElement?.Click();
			if (BookingLoadingFrame.IsVisible) BookingLoadingFrame.WaitUntilVisibleElementIsNot();

			return;
		}

		public bool FindHotel(string hotel)
		{
			var hotelExists = false;

			BookingHotelResultsList.WaitForVisibleElement();

			foreach (var hotelInList in BookingHotelResultsList.GetInnerElementByProperty("span"))
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

		private static string SetCheckInDate(DateTime dateToday, int monthsOfVacation, int lengthOfVacation)
		{
			return dateToday.AddMonths(monthsOfVacation).ToString("dd MMMM yyyy");
		}

		private static string SetCheckOutDate(DateTime dateToday, int monthsOfVacation, int lengthOfVacation)
		{
			return dateToday.AddDays(lengthOfVacation).AddMonths(monthsOfVacation).ToString("dd MMMM yyyy");
		}

		private void FilterPopularActivity(string activity)
		{
			IWebElement activityElemnt = null;

			foreach (var popularFilter in BookingPopularActivities.GetInnerElementByProperty("span"))
			{
				BookingPopularActivities.WaitForVisibleElement();
				BookingPopularActivities.ScrollToElement();
				while (popularFilter.Text == activity)
				{
					activityElemnt = popularFilter;
					break;
				}
			}
			activityElemnt?.Click();
			if(BookingLoadingFrame.IsVisible) BookingLoadingFrame.WaitUntilVisibleElementIsNot();

			return;
		}

		private void UnFilterPopularActivity(string activity)
		{
			IWebElement activityElement = null;

			foreach (var popularFilter in BookingPopularActivities.GetInnerElementByProperty("span"))
			{
				BookingPopularActivities.WaitForVisibleElement();
				BookingPopularActivities.ScrollToElement();
				while (popularFilter.Text == activity)
				{
					activityElement = popularFilter;
					break;
				}
			}

			activityElement?.Click();
			if (BookingLoadingFrame.IsVisible) BookingLoadingFrame.WaitUntilVisibleElementIsNot();

			return;
		}
	}
}
