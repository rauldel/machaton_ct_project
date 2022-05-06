using myCT.Common;

using Newtonsoft.Json;

namespace myCT.Categories.UpdateActions
{
    /// <summary>
    /// Changing parents should not be done concurrently. Concurrent changes of parent categories might currently lead to corrupted ancestor lists (paths).
    /// </summary>
    /// <see href="http://dev.commercetools.com/http-api-projects-categories.html#change-parent"/>
    public class ChangeParentAction : UpdateAction
    {
        #region Properties

        /// <summary>
        /// Reference to a category
        /// </summary>
        [JsonProperty(PropertyName = "parent")]
        public Reference Parent { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:myCT.Categories.UpdateActions.ChangeParentAction"/> class.
        /// </summary>
        public ChangeParentAction()
        {
            this.Action = "changeParent";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parent">Reference to a category</param>
        public ChangeParentAction(Reference parent)
        {
            this.Action = "changeParent";
            this.Parent = parent;
        }

        #endregion
    }
}
