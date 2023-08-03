using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using PhoneDictionary;

namespace Lab6.Helpers
{
    public static class PhonesHelper
    {
        public static MvcHtmlString AddPhoneForm(this HtmlHelper html)
        {
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("method", "post");
            form.MergeAttribute("action", "/dict/add");

            TagBuilder NameInputWrapper = new TagBuilder("div");
            TagBuilder NameInput = new TagBuilder("input");
            NameInput.MergeAttribute("type", "text");
            NameInput.MergeAttribute("name", "Name");
            NameInput.MergeAttribute("placeholder", "Name");
            NameInputWrapper.InnerHtml = NameInput.ToString();

            TagBuilder phoneInputWrapper = new TagBuilder("div");
            TagBuilder phoneInput = new TagBuilder("input");
            phoneInput.MergeAttribute("type", "text");
            phoneInput.MergeAttribute("name", "Phone_Number");
            phoneInput.MergeAttribute("placeholder", "Phone Number");
            phoneInputWrapper.InnerHtml = phoneInput.ToString();

            TagBuilder submitButtonWrapper = new TagBuilder("div");
            TagBuilder submitButton = new TagBuilder("button");
            submitButton.MergeAttribute("type", "submit");
            submitButton.SetInnerText("Add");
            submitButtonWrapper.InnerHtml = submitButton.ToString();

            form.InnerHtml = NameInputWrapper.ToString() + phoneInputWrapper.ToString() + submitButtonWrapper.ToString();
            return new MvcHtmlString(form.ToString());
        }

        public static MvcHtmlString UpdatePhoneForm(this HtmlHelper html, object newPhone)
        {
            Phone phone = newPhone as Phone;
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("method", "post");
            form.MergeAttribute("action", "/dict/update");

            TagBuilder idInput = new TagBuilder("input");
            idInput.MergeAttribute("type", "hidden");
            idInput.MergeAttribute("name", "Id");
            idInput.MergeAttribute("value", phone.Id.ToString());


            TagBuilder NameInputWrapper = new TagBuilder("div");
            TagBuilder NameInput = new TagBuilder("input");
            NameInput.MergeAttribute("type", "text");
            NameInput.MergeAttribute("name", "Name");
            NameInput.MergeAttribute("value", phone.Name);
            NameInput.MergeAttribute("placeholder", "Name");
            NameInputWrapper.InnerHtml = NameInput.ToString();

            TagBuilder phoneInputWrapper = new TagBuilder("div");
            TagBuilder phoneInput = new TagBuilder("input");
            phoneInput.MergeAttribute("type", "number");
            phoneInput.MergeAttribute("name", "Phone_Number");
            phoneInput.MergeAttribute("value", phone.Phone_Number.ToString());
            phoneInput.MergeAttribute("placeholder", "Phone Number");
            phoneInputWrapper.InnerHtml = phoneInput.ToString();

            TagBuilder submitButtonWrapper = new TagBuilder("div");
            TagBuilder submitButton = new TagBuilder("button");
            submitButton.MergeAttribute("type", "submit");
            submitButton.SetInnerText("Обновить");
            submitButtonWrapper.InnerHtml = submitButton.ToString();

            form.InnerHtml = idInput.ToString() + NameInputWrapper.ToString() + phoneInputWrapper.ToString() + submitButtonWrapper.ToString();
            return new MvcHtmlString(form.ToString());
        }

    }
}