using System;
using System.Collections.Generic;

namespace SinglePage.Entities
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
            Init();

            Products     = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity       = new TrainingProduct();
        }

        public TrainingProduct Entity         { get; set; }
        public string EventCommand            { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity   { get; set; }
        public bool   IsValid                 { get; set; }
        public string Mode                    { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        // Control Visibility
        public bool IsDetailAreaVisible       { get; set; }
        public bool IsListAreaVisible         { get; set; }
        public bool IsSearchAreaVisible       { get; set; }

        private void Init()
        {
            EventCommand = "List";

            ValidationErrors = new List<KeyValuePair<string, string>>();

            ListMode();
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
            }
        }

        private void ListMode()
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
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

        private void AddMode()
        {
            IsListAreaVisible   = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        // with addition of the HandleRequest, this method no longer needed to be public
        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
        }

    }
}
