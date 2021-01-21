using System;
using BookingAutomated.Selenium.Tests.PageObject;
using BookingAutomated.Selenium.Tests.SeleniumCore.Base;
using NUnit.Framework;

namespace BookingAutomated.Selenium.Tests.Test.FunctionalTests
{
    public class Tests : InitializeTest
    {
        [TearDown]
        public void TestTearDown()
        {
            WebDriver.Quit();
        }

        [Test]
        public void Booking_PageIsOpened()
        {
            Assert.IsTrue(WebDriver.Url.Contains("https://www.booking.com/"));
        }

        [Test]
        public void Booking_GetDefaultText_PageSearchBox()
        {
            var page = new Booking();

            page.BookingSearchBoxGetSearchText();

            Assert.IsTrue(page.BookingSearchBoxGetSearchText().Contains("Where are you going?"));
        }

        [Test]
        public void Booking_SendText_PageSearchBox()
        {
            var page = new Booking();

            page.BookingSearchBoxSendSearchTerm("Test Text");

            Assert.AreNotEqual(page.BookingSearchBoxGetSearchText(), "Test Text");
        }

        [Test]
        public void Booking_Click_SetCheckInAndOutDate()
        {
            var page = new Booking();

            page.BookingSetVacationDate("August 2020", 0, 1);

            Assert.AreEqual(page.GetCheckInDate(), DateTime.Now.ToString("ddd dd MMM"));
        }

        [Test]
        public void Booking_Click_PageSetGuests()
        {
            var page = new Booking();

            page.BookingSetGuestCount();

            Assert.AreEqual(page.BookingSetGuestCount(), "2 adults  ·  0 children  ·  1 room");
        }

        [Test]
        public void Booking_Click_SearchButton()
        {
            var page = new Booking();

            page.BookingSearchBoxSendSearchTerm("Madrid");
            page.BookingSetVacationDate("January 2021", 0, 1);
            page.BookingSearchButton.Click();

            Assert.IsTrue(page.BookingSearchResults.IsVisible);
        }

        [Test]
        public void Booking_Click_PopularActivities_Sauna()
        {
            var page = new Booking();

            page.BookingSearchBoxSendSearchTerm("Limerick");
            page.BookingSetVacationDate("January 2021", 3, 1);

            page.FilterByPopularActivities();

            Assert.IsTrue(page.FindHotel("Limerick Strand Hotel"));
        }

        [Test]
        public void Booking_Click_StarRating_5Stars()
        {
            var page = new Booking();

            page.BookingSearchBoxSendSearchTerm("Limerick");
            page.BookingSetVacationDate("January 2021", 3, 1);

            page.BookingSearchButton.Click();

            if (page.BookingManageCookiesWindow.IsVisible) page.BookingManageCookiesAcceptButton.Click();
            page.BookingManageCookiesAcceptButton.WaitUntilVisibleElementIsNot();

            page.FilterByPopularStars("5 stars");

            Assert.IsTrue(page.FindHotel("The Savoy Hotel"));
        }
    }
}
