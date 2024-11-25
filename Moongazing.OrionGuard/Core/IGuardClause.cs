namespace Moongazing.OrionGuard.Core
{
    /// <summary>
    /// Represents a validation clause that can be executed.
    /// </summary>
    public interface IGuardClause
    {
        /// <summary>
        /// Executes the validation logic for this clause.
        /// </summary>
        void Validate();
    }
}
