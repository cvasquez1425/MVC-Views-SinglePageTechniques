using SinglePagePTC.Common;
using System;
using System.Collections.Generic;

namespace SinglePage.Entities
{
    /// <summary>
    /// View Model uses TrainingProductManager class for CRUD
    /// </summary>
    public class TrainingProductViewModel : ViewModelBase
    {
        public TrainingProductViewModel() : base()   // From the constructor in this view model called the constructor down in the view model base
        {

        }

        public TrainingProduct Entity         { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity   { get; set; }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();

            base.Init();
        }

        public void HandleRequest()
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

        private void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                // Add data to databas here
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;
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

        private void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            AddMode();

        }

        private void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            // we're going to set the entity/member variable to hold the current product, this is the one we're going to bind to the input area, input form for the user.
            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            EditMode();
        }

        private void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);
            Get();

            ListMode();
        }

        private void AddMode()
        {
            IsListAreaVisible   = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }

        private void EditMode()
        {
            IsListAreaVisible   = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Edit";
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        // with addition of the HandleRequest, this method no longer needed to be public
        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
        }

    }
}
