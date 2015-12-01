using System.Collections.Generic;

namespace SinglePagePTC.Common
{
    /// <summary>
    /// Move code that is generic into the Base Class, and keep things that are more specific to you view model, like a TrainingProductViewModel.
    /// The more things you can make virtual, and the more things you can override, the easier it makes more virtual methods down in your base class
    /// can be overriden which allows you to add on additional functionality beyond the CRUD logic. a new command, a new button etc.
    /// </summary>
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Init();
        }

        public string EventCommand   { get; set; }
        public bool IsValid          { get; set; }
        public string Mode           { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        // Primary Key holder
        public string EventArgument     { get; set; }

        // Control Visibility
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible   { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                case "edit":
                    //System.Diagnostics.Debugger.Break();  // stop and take a look at things.
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                default:
                    break;
            }
        }

        protected virtual void ListMode()    // changed from privagte to protected virtual. protected so that we can inherit from it, and  virtual to override it. in case we have additional property
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }

        protected virtual void ResetSearch()
        {

        }

        protected virtual void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }

        protected virtual void EditMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Edit";
        }

        protected virtual void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;

            ValidationErrors = new List<KeyValuePair<string, string>>();

            ListMode();
        }

        //You're going to want to, sometimes create methods that don't have anything for the sole purpose of being able to move a large chunk of code from the top level class down to the base class (ViewModelBase.cs)
        protected virtual void Get()
        {
                
        }

        protected virtual void Add()
        {
            AddMode();
        }

        protected virtual void Edit()
        {
            EditMode();
        }

        protected virtual void Delete()
        {
            ListMode();
        }

        protected virtual void Save()
        {   
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }

    }
}
