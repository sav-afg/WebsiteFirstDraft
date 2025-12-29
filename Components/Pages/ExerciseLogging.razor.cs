using WebsiteFirstDraft.Data.Models;

namespace WebsiteFirstDraft.Components.Pages
{
    public partial class ExerciseLogging
    {
        private void NavToHypertrophy()
        {
            NavigationManager.NavigateTo("hypertrophy");
        }

        private void NavToExerciseQuestionnaire()
        {
            NavigationManager.NavigateTo("exercisequestionnaire");
        }



        // Holds all ExerciseType records currently displayed in the UI
        // This list is typically bound to a table or list in the Razor markup
        List<ExerciseType> ExerciseTypes = [];

        // Temporary object used for creating a new ExerciseType
        // This is usually bound to a form input
        ExerciseType newExerciseType = new();

        protected override void OnInitialized()
        {
            // Called once when the component is first initialised
            // Loads all ExerciseTypes from the database into memory
            // so they can be displayed in the UI
            ExerciseTypes = Db.ExerciseTypes.ToList();
        }

        void Create()
        {
            // Adds the new exercise type to the database context
            Db.ExerciseTypes.Add(newExerciseType);

            // Persists the change to the database
            Db.SaveChanges();

            // Adds the newly created exercise type to the local list
            // This avoids reloading everything from the database
            ExerciseTypes.Add(newExerciseType);

            // Resets the form by creating a new empty object
            newExerciseType = new();
        }

        void Update(ExerciseType exerciseType)
        {
            // Marks the provided exerciseType as modified in the database context
            Db.ExerciseTypes.Update(exerciseType);

            // Saves the updated values to the database
            Db.SaveChanges();
        }

        void Delete(int id)
        {
            // Logs the deletion attempt (useful for debugging)
            Console.WriteLine($"Deleting {id}");

            // Finds the exercise type by primary key
            var exerciseType = Db.ExerciseTypes.Find(id);

            // If the record does not exist, exit safely
            if (exerciseType is null) return;

            // Removes the entity from the database
            Db.ExerciseTypes.Remove(exerciseType);
            Db.SaveChanges();

            // Removes the entity from the local list
            // so the UI updates immediately
            ExerciseTypes.Remove(exerciseType);
        }


        // Search functionality
        // Stores the user's search input
        private string searchText = "";

        // Holds the filtered search results
        // This is usually bound to a results list or table
        private List<ExerciseType> myresults = new();

        void Search()
        {
            // Queries the database for exercise types where
            // the ExerciseNames field contains the search text
            // and stores the results in myresults
            myresults = Db.ExerciseTypes
                .Where(e => e.ExerciseNames.Contains(searchText))
                .ToList();
        }

    }
}
