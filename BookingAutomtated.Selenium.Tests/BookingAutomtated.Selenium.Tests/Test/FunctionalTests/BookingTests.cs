using BookingAutomtated.Selenium.Tests.PageObject;
using BookingAutomtated.Selenium.Tests.SeleniumCore.Base;

using NUnit.Framework;

using System;

namespace BookingAutomtated.Selenium.Tests.Test.FunctionalTests
{
    public class BookingTests : InitializeTest
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

            page.BookingSerachBoxGetSearchText();

            Assert.IsTrue(page.BookingSerachBoxGetSearchText().Contains("Where are you going?"));
        }

        [Test]
        public void Booking_SendText_PageSearchBox()
        {
            var page = new Booking();

            page.BookingSerachBoxSendSearchTerm("Test Text");

            Assert.AreNotEqual(page.BookingSerachBoxGetSearchText(), "Test Text");
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

            page.BookingSerachBoxSendSearchTerm("Madrird");
            page.BookingSetVacationDate("August 2020", 0, 1);
            page.BookingSearchButton.Click();

            Assert.IsTrue(page.BookingSearchResults.IsVisible);
        }

        [Test]
        public void Booking_Click_PopularActivities_Sauna()
        {
            var page = new Booking();

            page.BookingSerachBoxSendSearchTerm("Limerick");
            page.BookingSetVacationDate("November 2020", 3, 1);

           

            page.FilterByPopularActivities();

            Assert.IsTrue(page.FindHotel("Limerick Strand Hotel"));
        }

        [Test]
        public void Booking_Click_StarRating_5Stars()
        {
            var page = new Booking();

            page.BookingSerachBoxSendSearchTerm("Limerick");
            page.BookingSetVacationDate("November 2020", 3, 1);

            page.BookingSearchButton.Click();

            if (page.BookingManageCookiesWindow.IsVisible) page.BookingManageCookiesAcceptButon.Click();
            page.BookingManageCookiesAcceptButon.WaitUntilVisableElementIsNot();

            page.FilterByPopularStars("5 stars");

            Assert.IsTrue(page.FindHotel("The Savoy Hotel"));
        }
    }
}
