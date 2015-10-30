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

        public override void HandleRequest()
        {
            switch(EventCommand.ToLower())      //Additional functinality due to overriding this method from the Base class. if it doesn't fall thru, it goes to the HandleRequest down there.
            {
                case "carlos":                   // Additional buttons into our model.
                    break;

                default:
                    break;
            }
            base.HandleRequest();
        }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();

            base.Init();
        }

        protected override void Save()
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

            base.Save();
        }

        protected override void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            //AddMode();
            base.Add();

        }

        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            // we're going to set the entity/member variable to hold the current product, this is the one we're going to bind to the input area, input form for the user.
            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            //EditMode();
            base.EditMode();
        }

        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);
            Get();

            //ListMode();
            base.Delete();
        }

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();

            base.ResetSearch();
        }

        // with addition of the HandleRequest, this method no longer needed to be public
        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);

            base.Get();
        }

    }
}
